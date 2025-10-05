using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories;
using Phan_mem_diem_danh.Exceptions;

using System.Text.RegularExpressions;
using Phan_mem_diem_danh.Database.Entities;

namespace Phan_mem_diem_danh.Services;

public class AuthService
{
    private readonly AccountRepository accountRepository;

    public AuthService(Configuration configuration)
    private readonly Configuration _configuration;

    public AuthService(Configuration configuration)
    {
        accountRepository = configuration.AccountRepository;
    }

    public void Login(string msv, string password)
    {
        Account? account = accountRepository.FindByMSVAndPassword(msv, password);
        
        bool isAccountValid = account != null && account.Roles.Any();
        if (!isAccountValid)
        {
            throw new AppException("Sai MSV hoặc mật khẩu.");
        }

        LoggedInAccount.SetAccount(account);
        _configuration = configuration;
    }

    // Tài khoản đang đăng nhập (set sau khi login thành công)
    public Account? CurrentAccount { get; private set; }

    public void SetCurrentAccount(Account account) => CurrentAccount = account;

    // - Mật khẩu cũ phải đúng
    // - Mật khẩu mới đúng định dạng (>=8, có chữ hoa, chữ thường, số, ký tự đặc biệt)
    // - Mật khẩu mới không trùng mật khẩu cũ
    // - Cập nhật vào database
    public (bool Success, string Message) ChangePassword(string oldPassword, string newPassword, string confirmPassword)
    {
        if (CurrentAccount is null)
            return (false, "Chưa xác thực người dùng.");

        if (string.IsNullOrWhiteSpace(oldPassword) ||
            string.IsNullOrWhiteSpace(newPassword) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            return (false, "Vui lòng nhập đầy đủ thông tin.");
        }

        if (!string.Equals(oldPassword, CurrentAccount.Password, StringComparison.Ordinal))
            return (false, "Mật khẩu cũ không đúng.");

        if (!string.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            return (false, "Xác nhận mật khẩu không khớp.");

        if (string.Equals(oldPassword, newPassword, StringComparison.Ordinal))
            return (false, "Mật khẩu mới không được trùng mật khẩu cũ.");

        if (!IsPasswordValid(newPassword, out var reason))
            return (false, reason);

        try
        {
            // Cập nhật DB (tối thiểu chỉ cập nhật Password theo Id)
            var updated = new Account
            {
                Id = CurrentAccount.Id,
                Password = newPassword
            };
            _configuration.AccountRepository.Update(updated);

            // Cập nhật in-memory
            CurrentAccount.Password = newPassword;

            return (true, "Đổi mật khẩu thành công.");
        }
        catch (Exception ex)
        {
            return (false, $"Không thể cập nhật mật khẩu: {ex.Message}");
        }
    }

    private static bool IsPasswordValid(string password, out string error)
    {
        // >=8, có chữ hoa, chữ thường, số, ký tự đặc biệt
        if (password.Length < 8)
        {
            error = "Mật khẩu phải có ít nhất 8 ký tự.";
            return false;
        }
        if (!Regex.IsMatch(password, "[A-Z]"))
        {
            error = "Mật khẩu phải chứa ít nhất 1 chữ hoa.";
            return false;
        }
        if (!Regex.IsMatch(password, "[a-z]"))
        {
            error = "Mật khẩu phải chứa ít nhất 1 chữ thường.";
            return false;
        }
        if (!Regex.IsMatch(password, "[0-9]"))
        {
            error = "Mật khẩu phải chứa ít nhất 1 chữ số.";
            return false;
        }
        if (!Regex.IsMatch(password, "[^a-zA-Z0-9]"))
        {
            error = "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt.";
            return false;
        }

        error = string.Empty;
        return true;
    }
}