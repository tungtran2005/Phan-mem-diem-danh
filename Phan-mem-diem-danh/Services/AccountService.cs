using Phan_mem_diem_danh.Database.Entities;

namespace Phan_mem_diem_danh.Services;

public class AccountService
{
    private readonly Configuration _configuration;
    public AccountService(Configuration configuration)
    {
        _configuration = configuration;
    }

    public List<Account> GetAccountListByClassId(int classId)
    {
        List<AccountClass> list = _configuration.AccountClassRepository.List()
            .Where(accountclass => accountclass.ClassId == classId)
            .ToList();

        List<Account> accountList = new List<Account>();
        foreach (var ac in list)
        {
            if (ac.Role == "Student")
            {
                var account = _configuration.AccountRepository.Find(ac.AccountId);
                if (account != null)
                {
                    accountList.Add(account);
                }
            }
        }
       
        return accountList;
    }

}