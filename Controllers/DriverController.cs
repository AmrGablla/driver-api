using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace driver_api.Controllers
{
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

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetAll()
        {
            try
            {
                return await _driverService.GetDrivers();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAll: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Driver driver)
        {
            try
            {
                await _driverService.UpdateDriver(driver);
                return Ok(driver);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Update: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool deleted = await _driverService.DeleteDriver(id);
                if (deleted)
                    return NoContent();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Delete: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] Driver driver)
        {
            try
            {
                await _driverService.AddDriver(driver);
                return Ok(driver);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Create: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("AddRandoms")]
        public IActionResult AddRandoms()
        {
            try
            {
                _driverService.Add10Randoms();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddRandoms: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetAlphabetizedDrivers")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetAlphabetizedDrivers()
        {
            try
            {
                return await _driverService.GetAlphabetizedDrivers();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAlphabetizedDrivers: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
