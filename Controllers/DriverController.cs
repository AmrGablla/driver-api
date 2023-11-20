using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace driver_api.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _driverService;
    private readonly ILogger<DriverController> _logger;

    public DriverController(ILogger<DriverController> logger, IDriverService driverService)
    {
        _logger = logger;
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<IEnumerable<Driver>> GetAll()
    {
        return await _driverService.GetDrivers();
    }

    [HttpPut]
    public IActionResult Update([FromBody] Driver driver)
    {
        _driverService.UpdateDriver(driver);
        return Ok(driver);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _driverService.DeleteDriver(id);
        if (deleted)
            return NoContent();
        else return NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Driver driver)
    {
        _driverService.AddDriver(driver);
        return Ok(driver);
    }

    [HttpPost("AddRandoms")]
    public IActionResult AddRandoms()
    {
        _driverService.Add10Randoms();
        return NoContent();
    }

    [HttpGet("GetAlphabetizedDrivers")]
    public async Task<IEnumerable<Driver>> GetAlphabetizedDrivers()
    {
        return await _driverService.GetAlphabetizedDrivers();
    }
}
