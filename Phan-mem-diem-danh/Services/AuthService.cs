using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories;
using Phan_mem_diem_danh.Exceptions;

namespace Phan_mem_diem_danh.Services;

public class AuthService
{
    private AccountRepository accountRepository;

    public AuthService(Configuration configuration)
    {
        accountRepository = configuration.AccountRepository;
    }

    public void Login(string msv, string password)
    {
        Account? account = accountRepository.FindByMSVAndPassword(msv, password);
        
        bool isAccountValid = account != null && account.AccountRoles.Any();
        if (!isAccountValid)
        {
            throw new AppException("Sai MSV hoặc mật khẩu.");
        }

        LoggedInAccount.SetAccount(account);
    }
}