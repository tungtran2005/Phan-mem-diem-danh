using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Exceptions;

namespace Phan_mem_diem_danh.Services;

public static class LoggedInAccount
{
    private static Account? _instance;

    public static void SetAccount(Account? account)
    {
        if (_instance != null)
        {
            throw new AppException("Đã có tài khoản được đăng nhập.");
        }
        _instance = account;
    }

    public static Account? GetAccount()
    {
        if (_instance == null)
        {
            throw new AppException("Chưa có tài khoản nào được đăng nhập.");
        }
        
        return _instance;
    }
    
    public static void ClearAccount()
    {
        _instance = null;
    }
    
    public static bool IsStudent()
    {
        return _instance != null && _instance.Roles.Any(r => r.Name == "Student");
    }
    
    public static bool IsTeacher()
    {
        return _instance != null && _instance.Roles.Any(r => r.Name == "Teacher");
    }
}