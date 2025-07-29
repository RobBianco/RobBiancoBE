using Microsoft.AspNetCore.Mvc;
using RobBiancoBE.DTOs;
using RobBiancoBE.Hardware;

namespace RobBiancoBE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HardwareController : ControllerBase
{
    private readonly ILogger<HardwareController> _logger;

    public HardwareController(ILogger<HardwareController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sensors")]
    public IEnumerable<HardwareSensorDto> Get()
    {
        var data = new HardwareMonitorService().GetAllSensors();
        return data;
    }
}
