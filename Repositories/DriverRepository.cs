using Models;
using SQLite;

namespace Repositories
{
    public interface IDriverRepository
    {
        void AddDriver(Driver driver);
        void UpdateDriver(Driver driver);
        bool DeleteDriver(Driver driver);
        List<Driver> GetAlphabetizedDrivers();
        List<Driver> GetDrivers();
    }

    public class DriverRepository : IDriverRepository
    {
        private readonly IConfiguration _configuration;
        private SQLiteConnection _db;

        public DriverRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _db = new SQLiteConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        }
        public void AddDriver(Driver driver)
        {
            _db.Insert(driver);
        }

        public void UpdateDriver(Driver driver)
        {
            _db.Update(driver);
        }

        public bool DeleteDriver(Driver driver)
        {
            int numberOfRows = _db.Delete(driver);
            if (numberOfRows == 1) return true;
            else return false;
        }

        public List<Driver> GetDrivers()
        {
            return _db.Query<Driver>("SELECT * FROM Drivers");
        }

        public List<Driver> GetAlphabetizedDrivers()
        {
            return _db.Query<Driver>("SELECT * FROM Drivers").OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
        }
    }
}