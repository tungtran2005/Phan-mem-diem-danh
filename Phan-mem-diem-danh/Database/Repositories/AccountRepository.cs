using System.Data;
using Microsoft.Data.SqlClient;
using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories.Base;

namespace Phan_mem_diem_danh.Database.Repositories;

public class AccountRepository : BaseRepository<Account, int>
{
    // ====== CRUD theo Id (tiện nếu chỗ khác cần) ======
    public override Account Create(Account a)
    {
        const string sql = @"
INSERT INTO account (MSV, first_name, last_name, birth, password)
OUTPUT INSERTED.id
VALUES (@MSV, @First, @Last, @Birth, @Pwd);";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@MSV", a.MSV, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@First", a.FirstName, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Last", a.LastName, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Birth", a.Birth == default ? null : a.Birth, SqlDbType.Date));
        cmd.Parameters.Add(P("@Pwd", a.Password, SqlDbType.NVarChar));
        conn.Open();
        a.Id = (int)cmd.ExecuteScalar()!;
        return a;
    }

    public override Account? Find(int id)
    {
        const string sql = "select Id,MSV,first_name, last_name,birth from Account where Id = @Id";
        SqlCommand cmd = new SqlCommand(sql, SqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        SqlConnection.Open();
        try
        {
            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            return new Account
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                MSV = reader.IsDBNull(reader.GetOrdinal("MSV")) ? string.Empty : reader.GetString(reader.GetOrdinal("MSV")),
                FirstName = reader.IsDBNull(reader.GetOrdinal("first_name")) ? string.Empty : reader.GetString(reader.GetOrdinal("first_name")),
                LastName = reader.IsDBNull(reader.GetOrdinal("last_name")) ? string.Empty : reader.GetString(reader.GetOrdinal("last_name")),
                Birth = reader.IsDBNull(reader.GetOrdinal("birth")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("birth"))
            };
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            SqlConnection.Close();
        }


    }

    public override List<Account> List()
    {
        const string sql = @"SELECT id, MSV, first_name, last_name, birth, password FROM account ORDER BY id DESC;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        conn.Open();
        using var r = cmd.ExecuteReader();
        var list = new List<Account>();
        while (r.Read()) list.Add(Map(r));
        return list;
    }

    public override Account Update(Account a)
    {
        const string sql = @"
UPDATE account
SET MSV=@MSV, first_name=@First, last_name=@Last, birth=@Birth, password=@Pwd
WHERE id=@Id;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@MSV", a.MSV, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@First", a.FirstName, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Last", a.LastName, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Birth", a.Birth == default ? null : a.Birth, SqlDbType.Date));
        cmd.Parameters.Add(P("@Pwd", a.Password, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Id", a.Id, SqlDbType.Int));
        conn.Open();
        cmd.ExecuteNonQuery();
        return a;
    }

    public override bool Delete(int id)
    {
        const string sql = @"DELETE FROM account WHERE id=@Id;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@Id", id, SqlDbType.Int));
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }

    private static Account Map(SqlDataReader r) => new Account
    {
        Id = r.GetInt32(r.GetOrdinal("id")),
        MSV = r["MSV"] as string ?? "",
        FirstName = r["first_name"] as string ?? "",
        LastName = r["last_name"] as string ?? "",
        Birth = r["birth"] is DBNull ? DateTime.MinValue : (DateTime)r["birth"],
        Password = r["password"] as string ?? ""
    };

    // ====== API theo MSV (phần bạn cần) ======
    public Account? FindByMSV(string msv)
    {
        const string sql = @"SELECT id, MSV, first_name, last_name, birth, password FROM account WHERE MSV=@MSV;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@MSV", msv, SqlDbType.NVarChar));
        conn.Open();
        using var r = cmd.ExecuteReader();
        return r.Read() ? Map(r) : null;
    }

    public Account UpsertByMSV(Account a)
    {
        var existed = FindByMSV(a.MSV);
        if (existed == null)
        {
            return Create(a);
        }
        else
        {
            a.Id = existed.Id;
            return Update(a);
        }
    }

    public bool DeleteByMSV(string msv)
    {
        const string sql = @"DELETE FROM account WHERE MSV=@MSV;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@MSV", msv, SqlDbType.NVarChar));
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }

    public Account? FindByMSVAndPassword(string msv, string password)
    {
        const string sql = @"SELECT id, MSV, first_name, last_name, birth, password
                         FROM account WHERE MSV=@MSV AND password=@Pwd;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@MSV", msv, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Pwd", password, SqlDbType.NVarChar));
        conn.Open();
        using var r = cmd.ExecuteReader();
        return r.Read() ? new Account
        {
            Id = r.GetInt32(r.GetOrdinal("id")),
            MSV = r["MSV"] as string ?? "",
            FirstName = r["first_name"] as string ?? "",
            LastName = r["last_name"] as string ?? "",
            Birth = r["birth"] is DBNull ? DateTime.MinValue : (DateTime)r["birth"],
            Password = r["password"] as string ?? ""
        } : null;
    }
}