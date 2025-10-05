using Microsoft.Data.SqlClient;
using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories.Base;

namespace Phan_mem_diem_danh.Database.Repositories;

public class AccountClassRepository : BaseRepository<AccountClass, int>
{
    public override AccountClass Create(AccountClass t)
    {
        throw new NotImplementedException();
    }

    public override AccountClass? Find(int id)
    {
        throw new NotImplementedException();
    }

    public override List<AccountClass> List()
    {
        const string sql = "SELECT account_id, class_id, role FROM account_class";
        var result = new List<AccountClass>();

        using var cmd = new SqlCommand(sql, SqlConnection);
        SqlConnection.Open();
        try
        {
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ac = new AccountClass
                {
                    AccountId = reader.GetInt32(reader.GetOrdinal("account_id")),
                    ClassId = reader.GetInt32(reader.GetOrdinal("class_id")),
                    Role = reader.IsDBNull(reader.GetOrdinal("role")) ? string.Empty : reader.GetString(reader.GetOrdinal("role"))
                };

                result.Add(ac);
            }
        }
        finally
        {
            SqlConnection.Close();
        }

        return result;
    }

    public override AccountClass Update(AccountClass t)
    {
        throw new NotImplementedException();
    }

    public override bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}