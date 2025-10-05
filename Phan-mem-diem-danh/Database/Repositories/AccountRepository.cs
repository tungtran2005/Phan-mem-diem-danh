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

    public Account? FindByMSVAndPassword(string msv, string password)
    {
        Account? account = null;
        string query = @"
            SELECT a.id, a.MSV, a.password, r.id, r.name
            FROM account a
            JOIN account_role ar ON a.id = ar.account_id
            JOIN Role r ON ar.role_id = r.id
            WHERE a.MSV = @msv AND a.password = @password";

        using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
        {
            cmd.Parameters.AddWithValue("@msv", msv);
            cmd.Parameters.AddWithValue("@password", password);

            SqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (account == null)
                    {
                        account = new Account
                        {
                            Id = reader.GetInt32(0),
                            MSV = reader.GetString(1),                          
                            Password = reader.GetString(2),
                            Roles = new List<Role>()
                        };
                    }
                    Role role = new Role
                    {
                        Id = reader.GetInt32(3),
                        Name = reader.GetString(4)
                    };
                    account.Roles.Add(role);
                }
            }
            SqlConnection.Close();
        }
        return account;
    }
}