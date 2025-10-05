using System.Data;
using Microsoft.Data.SqlClient;
using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories.Base;

namespace Phan_mem_diem_danh.Database.Repositories;

public class AccountRepository : BaseRepository<Account, int>
{
    public override Account Create(Account t)
    {
        throw new NotImplementedException();
    }

    public override Account? Find(int id)
    {
        throw new NotImplementedException();
    }

    public override List<Account> List()
    {
        throw new NotImplementedException();
    }

    // Tối thiểu: cập nhật Password theo Id để phục vụ đổi mật khẩu
    public override Account Update(Account t)
    {
        const string sql = @"UPDATE Accounts SET Password = @Password WHERE Id = @Id";

        using var cmd = new SqlCommand(sql, SqlConnection);
        cmd.Parameters.AddWithValue("@Password", t.Password ?? string.Empty);
        cmd.Parameters.AddWithValue("@Id", t.Id);

        var shouldClose = false;
        if (SqlConnection.State != ConnectionState.Open)
        {
            SqlConnection.Open();
            shouldClose = true;
        }

        try
        {
            var affected = cmd.ExecuteNonQuery();
            if (affected == 0)
                throw new InvalidOperationException("Không tìm thấy tài khoản để cập nhật.");

            return t;
        }
        finally
        {
            if (shouldClose)
                SqlConnection.Close();
        }
    }

    public override bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}