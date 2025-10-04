using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories;

namespace Phan_mem_diem_danh.Services;

public class AuthService
{
    AccountRepository accountRepository;
    public AuthService(Configuration configuration) 
    {
        accountRepository = configuration.AccountRepository;
    }

    public Account? Login(string msv, string password)
    {
        try
        {
            Account? account = accountRepository.FindByMSVAndPassword(msv, password);
            bool isAccountValid = account != null && account.AccountRoles.Any();

            if (!isAccountValid)
            {
                throw new Exception("Sai MSV hoặc mật khẩu.");
            }
            LoggedInAccount.SetAccount(account);
            return account;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}