using Phan_mem_diem_danh.Database.Entities;

namespace Phan_mem_diem_danh.Services;

public class AuthService
{
    private readonly Configuration _configuration;

    public AuthService(Configuration configuration) 
    {
        _configuration = configuration;
    }

    // Tài khoản đang đăng nhập (hãy set khi đăng nhập thành công)
    public Account? CurrentAccount { get; private set; }

    public void SetCurrentAccount(Account? account)
    {
        CurrentAccount = account;
    }

    // Kiểm tra mật khẩu hiện tại có khớp với tài khoản đang đăng nhập
    public bool VerifyCurrentPassword(string currentPassword)
    {
        if (CurrentAccount is null) return false;

        // TODO: Nếu dùng hash, thay thế bằng so sánh hash an toàn
        return string.Equals(CurrentAccount.Password, currentPassword);
    }
}