using System.Data;
using Microsoft.Data.SqlClient;
using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories.Base;

namespace Phan_mem_diem_danh.Database.Repositories;

public class AccountClassRepository : BaseRepository<AccountClass, int>
{
    // Không dùng các hàm interface chung
    public override AccountClass Create(AccountClass t) => throw new NotImplementedException();
    public override AccountClass? Find(int id) => throw new NotImplementedException();
    public override List<AccountClass> List() => throw new NotImplementedException();
    public override AccountClass Update(AccountClass t) => throw new NotImplementedException();
    public override bool Delete(int id) => throw new NotImplementedException();

    private int? GetAccountIdByMSV(SqlConnection conn, string msv)
    {
        const string sql = "SELECT id FROM account WHERE MSV=@MSV;";
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@MSV", msv, SqlDbType.NVarChar));
        var o = cmd.ExecuteScalar();
        return o == null ? null : (int?)Convert.ToInt32(o);
    }

    public List<(string MSV, string FirstName, string LastName, string Role)> ListMembersByClass(int classId)
    {
        const string sql = @"
        SELECT a.MSV, a.first_name, a.last_name, ac.role
        FROM account_class ac
        JOIN account a ON a.id = ac.account_id
        WHERE ac.class_id = @C
        ORDER BY a.last_name, a.first_name;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@C", classId, SqlDbType.Int));
        conn.Open();
        using var r = cmd.ExecuteReader();
        var list = new List<(string, string, string, string)>();
        while (r.Read())
            list.Add((r["MSV"] as string ?? "", r["first_name"] as string ?? "", r["last_name"] as string ?? "", r["role"] as string ?? ""));
        return list;
    }

    public bool AddMemberByMSV(int classId, string msv, string role)
    {
        using var conn = CreateConnection();
        conn.Open();
        var accountId = GetAccountIdByMSV(conn, msv) ?? throw new InvalidOperationException($"Không tìm thấy MSV '{msv}'.");

        // tránh trùng
        const string chk = "SELECT 1 FROM account_class WHERE account_id=@A AND class_id=@C;";
        using (var c1 = new SqlCommand(chk, conn))
        {
            c1.Parameters.Add(P("@A", accountId, SqlDbType.Int));
            c1.Parameters.Add(P("@C", classId, SqlDbType.Int));
            if (c1.ExecuteScalar() != null) return false;
        }

        const string ins = "INSERT INTO account_class(account_id, class_id, role) VALUES(@A,@C,@R);";
        using var cmd = new SqlCommand(ins, conn);
        cmd.Parameters.Add(P("@A", accountId, SqlDbType.Int));
        cmd.Parameters.Add(P("@C", classId, SqlDbType.Int));
        cmd.Parameters.Add(P("@R", role, SqlDbType.NVarChar));
        return cmd.ExecuteNonQuery() > 0;
    }

    public bool UpdateRoleByMSV(int classId, string msv, string role)
    {
        using var conn = CreateConnection();
        conn.Open();
        var accountId = GetAccountIdByMSV(conn, msv);
        if (accountId == null) return false;

        const string upd = "UPDATE account_class SET role=@R WHERE account_id=@A AND class_id=@C;";
        using var cmd = new SqlCommand(upd, conn);
        cmd.Parameters.Add(P("@R", role, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@A", accountId, SqlDbType.Int));
        cmd.Parameters.Add(P("@C", classId, SqlDbType.Int));
        return cmd.ExecuteNonQuery() > 0;
    }

    public bool RemoveMemberByMSV(int classId, string msv)
    {
        using var conn = CreateConnection();
        conn.Open();
        var accountId = GetAccountIdByMSV(conn, msv);
        if (accountId == null) return false;

        const string del = "DELETE FROM account_class WHERE account_id=@A AND class_id=@C;";
        using var cmd = new SqlCommand(del, conn);
        cmd.Parameters.Add(P("@A", accountId, SqlDbType.Int));
        cmd.Parameters.Add(P("@C", classId, SqlDbType.Int));
        return cmd.ExecuteNonQuery() > 0;
    }
    public List<AccountClass> GetAllAccountClass()
    {
        const string sql = @"
        SELECT account_id, class_id, role
        FROM account_class
        ORDER BY account_id, class_id;";

        var list = new List<AccountClass>();

        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        conn.Open();

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new AccountClass
            {
                AccountId = reader.GetInt32(reader.GetOrdinal("account_id")),
                ClassId = reader.GetInt32(reader.GetOrdinal("class_id")),
                Role = reader.IsDBNull(reader.GetOrdinal("role")) ? string.Empty : reader.GetString(reader.GetOrdinal("role"))
            });
        }

        return list;
    }

}