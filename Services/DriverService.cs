using Repositories;
using Models;
using Helpers;

namespace Services
{
    public interface IDriverService
    {
        void AddDriver(Driver driver);
        void UpdateDriver(Driver driver);
        bool DeleteDriver(int id);
        List<Driver> GetDrivers();
        List<Driver> GetAlphabetizedDrivers();
        void Add10Randoms();
    }


    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public void AddDriver(Driver driver)
        {
            _driverRepository.AddDriver(driver);
        }

        public void UpdateDriver(Driver driver)
        {
            _driverRepository.UpdateDriver(driver);
        }

        public bool DeleteDriver(int id)
        {
            Driver driver = new Driver();
            driver.Id = id;
            return _driverRepository.DeleteDriver(driver);
        }

        public List<Driver> GetDrivers()
        {
            return _driverRepository.GetDrivers();
        }

        public List<Driver> GetAlphabetizedDrivers()
        {
            return _driverRepository.GetAlphabetizedDrivers();
        }

        public void Add10Randoms()
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

                AddDriver(driver);
            }
        }
    }
}