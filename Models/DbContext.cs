using Models;
using SQLite;

public class DbContext : IDisposable
{
    private readonly SQLiteAsyncConnection db;
    private readonly IConfiguration _configuration;

    public DbContext(IConfiguration configuration, SQLiteAsyncConnection? connection = null)
    {
        if (connection != null)
        {
            this.db = connection;
        }
        else
        {
            _configuration = configuration;

            this.db = new SQLiteAsyncConnection(_configuration["ConnectionStrings:DefaultConnection"],
                SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite);
        }

    }

    public SQLiteAsyncConnection Database => db;
    public AsyncTableQuery<Driver> Drivers => db.Table<Driver>();


    public async void Dispose()
    {
        await db.CloseAsync();
    }
}