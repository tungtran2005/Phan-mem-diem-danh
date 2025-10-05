using Microsoft.Data.SqlClient;
using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Database.Repositories.Base;
using System.Data;
using System.Data.Common;

namespace Phan_mem_diem_danh.Database.Repositories;

public class ClassRepository : BaseRepository<Class, int>
{
    public override Class Create(Class t)
    {
        throw new NotImplementedException();
    }

    public override Class? Find(int id)
    {
        const string sql = "SELECT id, name, subject, department, start_date, end_date FROM class WHERE id = @id";
        using var cmd = new SqlCommand(sql, SqlConnection);
        cmd.Parameters.AddWithValue("@id", id);

        SqlConnection.Open();
        try
        {
            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            var c = new Class
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.IsDBNull(reader.GetOrdinal("name")) ? string.Empty : reader.GetString(reader.GetOrdinal("name")),
                Subject = reader.IsDBNull(reader.GetOrdinal("subject")) ? string.Empty : reader.GetString(reader.GetOrdinal("subject")),
                Department = reader.IsDBNull(reader.GetOrdinal("department")) ? string.Empty : reader.GetString(reader.GetOrdinal("department")),
                StartDate = reader.IsDBNull(reader.GetOrdinal("start_date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("start_date")),
                EndDate = reader.IsDBNull(reader.GetOrdinal("end_date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("end_date"))
            };

            return c;
        }
        finally
        {
            SqlConnection.Close();
        }
    }

    public override List<Class> List()
    {
        var classes = new List<Class>();

        const string sql = "SELECT id, name, subject, department, start_date, end_date FROM class";

        using (var cmd = new SqlCommand(sql, SqlConnection))
        {
            try
            {
                SqlConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = new Class
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader["name"]?.ToString(),
                            Subject = reader["subject"]?.ToString(),
                            Department = reader["department"]?.ToString(),
                            StartDate = reader.IsDBNull(reader.GetOrdinal("start_date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("start_date")),
                            EndDate = reader.IsDBNull(reader.GetOrdinal("end_date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("end_date"))
                        };

                        classes.Add(c);
                    }
                }
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                    SqlConnection.Close();
            }
        }

        return classes;
    }


    public override Class Update(Class t)
    {
        throw new NotImplementedException();
    }

    public override bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}