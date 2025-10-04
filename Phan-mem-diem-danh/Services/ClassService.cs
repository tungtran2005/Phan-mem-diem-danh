using Phan_mem_diem_danh.Database.Entities;

namespace Phan_mem_diem_danh.Services;

public class ClassService
{
    private readonly Configuration _configuration;
    public ClassService(Configuration configuration)
    {
        _configuration = configuration;
    }
    public List<Class> GetClassListByAccountId(int accountId)
    {
        var accountClasses = _configuration.AccountClassRepository.List()
            .Where(ac => ac.AccountId == accountId)
            .ToList();
        var classList = new List<Class>();
        foreach (var accountClass in accountClasses)
        {
            var cls = _configuration.ClassRepository.Find(accountClass.ClassId);
            if (cls != null)
            {
                classList.Add(cls);
            }
        }
        return classList;
    }
}