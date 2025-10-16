using Microsoft.Data.SqlClient;
using System.Data;

namespace Phan_mem_diem_danh.Database.Repositories.Base;

public abstract class BaseRepository<T, ID>
{
    // Gợi ý: sau có thể lấy từ SettingScreen
    private const string ConnectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=PMDDDB;Trusted_Connection=True;TrustServerCertificate=True;";

    protected SqlConnection CreateConnection() => new SqlConnection(ConnectionString);
    
    protected readonly SqlConnection SqlConnection = new SqlConnection(ConnectionString);

    protected static SqlParameter P(string name, object? value, SqlDbType type)
    {
        var p = new SqlParameter(name, type) { Value = value ?? DBNull.Value };
        return p;
    }

    public abstract T Create(T t);
    public abstract T? Find(ID id);
    public abstract List<T> List();
    public abstract T Update(T t);
    public abstract bool Delete(ID id);
}
