
using Xunit;
using Moq;
using Repositories;
using Models;


namespace Services
{
    public class DriverServiceTest
    {

        [Fact]
        public async Task AddDriver_ShouldCallRepositoryAddDriver()
        {
            var mockRepo = new Mock<IDriverRepository>();
            var service = new DriverService(mockRepo.Object);
            var driver = new Driver();

            await service.AddDriver(driver);

            mockRepo.Verify(repo => repo.AddDriver(driver), Times.Once);
        }

        [Fact]
        public async Task UpdateDriver_ShouldCallRepositoryUpdateDriver()
        {
            var mockRepo = new Mock<IDriverRepository>();
            var service = new DriverService(mockRepo.Object);
            var driver = new Driver();

            await service.UpdateDriver(driver);

            mockRepo.Verify(repo => repo.UpdateDriver(driver), Times.Once);
        }

        [Fact]
        public async Task DeleteDriver_ShouldCallRepositoryDeleteDriver()
        {

            var mockRepo = new Mock<IDriverRepository>();
            var service = new DriverService(mockRepo.Object);
            var driverId = 1;

            await service.DeleteDriver(driverId);

            mockRepo.Verify(repo => repo.DeleteDriver(It.Is<Driver>(d => d.Id == driverId)), Times.Once);
        }

        [Fact]
        public async Task GetDrivers_ShouldCallRepositoryGetDrivers()
        {

            var mockRepo = new Mock<IDriverRepository>();
            var service = new DriverService(mockRepo.Object);

            await service.GetDrivers();

            mockRepo.Verify(repo => repo.GetDrivers(), Times.Once);
        }

        [Fact]
        public async Task GetAlphabetizedDrivers_ShouldCallRepositoryGetAlphabetizedDrivers()
        {

            var mockRepo = new Mock<IDriverRepository>();
            var service = new DriverService(mockRepo.Object);

            await service.GetAlphabetizedDrivers();

            mockRepo.Verify(repo => repo.GetAlphabetizedDrivers(), Times.Once);
        }

        [Fact]
        public async Task Add10Randoms_ShouldCallAddDriverTenTimes()
        {
            var mockRepo = new Mock<IDriverRepository>();
            var service = new DriverService(mockRepo.Object);

            await service.Add10Randoms();

            mockRepo.Verify(repo => repo.AddDriver(It.IsAny<Driver>()), Times.Exactly(10));
        }
    }
}