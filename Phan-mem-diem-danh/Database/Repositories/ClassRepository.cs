using Microsoft.Data.SqlClient;
using System.Data;
using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories.Base;

namespace Phan_mem_diem_danh.Database.Repositories;

public class ClassRepository : BaseRepository<Class, int>
{
    public override Class Create(Class c)
    {
        const string sql = @"
        INSERT INTO class (name, subject, department, start_date, end_date)
        OUTPUT INSERTED.id
        VALUES (@Name, @Subject, @Department, @Start, @End);";

        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@Name", c.Name, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Subject", c.Subject, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Department", c.Department, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Start", c.StartDate == default ? null : c.StartDate, SqlDbType.Date));
        cmd.Parameters.Add(P("@End", c.EndDate == default ? null : c.EndDate, SqlDbType.Date));
        conn.Open();
        c.Id = (int)cmd.ExecuteScalar()!;
        return c;
    }

    public override Class? Find(int id)
    {
        const string sql = @"SELECT id, name, subject, department, start_date, end_date FROM class WHERE id=@Id;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@Id", id, SqlDbType.Int));
        conn.Open();
        using var r = cmd.ExecuteReader();
        return r.Read() ? Map(r) : null;
    }

    public override List<Class> List()
    {
        const string sql = @"SELECT id, name, subject, department, start_date, end_date FROM class ORDER BY id ASC;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        conn.Open();
        using var r = cmd.ExecuteReader();
        var list = new List<Class>();
        while (r.Read()) list.Add(Map(r));
        return list;
    }

    public override Class Update(Class c)
    {
        const string sql = @"
UPDATE class SET
  name=@Name, subject=@Subject, department=@Department, start_date=@Start, end_date=@End
WHERE id=@Id;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@Name", c.Name, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Subject", c.Subject, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Department", c.Department, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Start", c.StartDate == default ? null : c.StartDate, SqlDbType.Date));
        cmd.Parameters.Add(P("@End", c.EndDate == default ? null : c.EndDate, SqlDbType.Date));
        cmd.Parameters.Add(P("@Id", c.Id, SqlDbType.Int));
        conn.Open();
        cmd.ExecuteNonQuery();
        return c;
    }

    public override bool Delete(int id)
    {
        const string sql = @"DELETE FROM class WHERE id=@Id;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@Id", id, SqlDbType.Int));
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }

    private static Class Map(SqlDataReader r) => new Class
    {
        Id = r.GetInt32(r.GetOrdinal("id")),
        Name = r["name"] as string ?? "",
        Subject = r["subject"] as string ?? "",
        Department = r["department"] as string ?? "",
        StartDate = r["start_date"] is DBNull ? DateTime.MinValue : (DateTime)r["start_date"],
        EndDate = r["end_date"] is DBNull ? DateTime.MinValue : (DateTime)r["end_date"],
    };

    public Class? FindByNameAndSubject(string name, string subject)
    {
        const string sql = @"SELECT id, name, subject, department, start_date, end_date
                         FROM class WHERE name=@Name AND subject=@Subject;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@Name", name, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Subject", subject, SqlDbType.NVarChar));
        conn.Open();
        using var r = cmd.ExecuteReader();
        return r.Read() ? Map(r) : null;
    }

    public Class UpsertByNameAndSubject(Class c)
    {
        var existed = FindByNameAndSubject(c.Name, c.Subject);
        if (existed == null) return Create(c);
        c.Id = existed.Id;
        return Update(c);
    }

    public bool DeleteByNameAndSubject(string name, string subject)
    {
        const string sql = @"DELETE FROM class WHERE name=@Name AND subject=@Subject;";
        using var conn = CreateConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(P("@Name", name, SqlDbType.NVarChar));
        cmd.Parameters.Add(P("@Subject", subject, SqlDbType.NVarChar));
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }
}
