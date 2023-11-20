using Models;
using SQLite;

namespace Repositories
{
    public interface IDriverRepository
    {
        Task AddDriver(Driver driver);
        Task UpdateDriver(Driver driver);
        Task<bool> DeleteDriver(Driver driver);
        Task<List<Driver>> GetAlphabetizedDrivers();
        Task<List<Driver>> GetDrivers();
    }


    public class DriverRepository : IDriverRepository
    {
        private DbContext _db;

        public DriverRepository(DbContext db)
        {
            _db = db;
        }
        public async Task AddDriver(Driver driver)
        {
            await _db.Database.InsertAsync(driver);
        }

        public async Task UpdateDriver(Driver driver)
        {
            await _db.Database.UpdateAsync(driver);
        }

        public async Task<bool> DeleteDriver(Driver driver)
        {
            await _db.Database.DeleteAsync(driver);
            return true;
        }

        public async Task<List<Driver>> GetDrivers()
        {
            return await _db.Drivers.ToListAsync();
        }

        public async Task<List<Driver>> GetAlphabetizedDrivers()
        {
            return await _db.Drivers.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToListAsync();
        }
    }
}