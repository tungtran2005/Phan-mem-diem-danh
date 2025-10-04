using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phan_mem_diem_danh.Database.Entities;

namespace Phan_mem_diem_danh.Services
{
    public static class LoggedInAccount
    {
        public static Account _account;

        public static void SetAccount(Account account)
        {
            _account = account;
        }   
        public static Account GetAccount()
        {
            return _account;
        }
    }

}
