using Repositories;
using Models;
using Helpers;

namespace Services
{
    public interface IDriverService
    {
        Task AddDriver(Driver driver);
        Task UpdateDriver(Driver driver);
        Task<bool> DeleteDriver(int id);
        Task<List<Driver>> GetDrivers();
        Task<List<Driver>> GetAlphabetizedDrivers();
        Task Add10Randoms();
    }


    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task AddDriver(Driver driver)
        {
            await _driverRepository.AddDriver(driver);
        }

        public async Task UpdateDriver(Driver driver)
        {
            await _driverRepository.UpdateDriver(driver);
        }

        public Task<bool> DeleteDriver(int id)
        {
            Driver driver = new Driver();
            driver.Id = id;
            return _driverRepository.DeleteDriver(driver);
        }

        public async Task<List<Driver>> GetDrivers()
        {
            return await _driverRepository.GetDrivers();
        }

        public Task<List<Driver>> GetAlphabetizedDrivers()
        {
            return _driverRepository.GetAlphabetizedDrivers();
        }

        public async Task Add10Randoms()
        {
            for (int i = 0; i < 10; i++)
            {
                Driver driver = new Driver
                {
                    FirstName = DriverRandoms.GetRandomName(),
                    LastName = DriverRandoms.GetRandomName(),
                    Email = DriverRandoms.GetRandomEmail(),
                    PhoneNumber = DriverRandoms.GetRandomPhoneNumber()
                };

                await AddDriver(driver);
            }
        }
    }
}