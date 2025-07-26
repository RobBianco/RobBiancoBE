using Microsoft.AspNetCore.Mvc;
using RobBiancoBE.Hardware;

namespace RobBiancoBE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HardwareController : ControllerBase
{
    private readonly HardwareMonitorService _monitorService;

    public HardwareController(HardwareMonitorService monitorService)
    {
        _monitorService = monitorService;
    }

    [HttpGet("sensors")]
    public IActionResult GetSensors()
    {
        var data = _monitorService.GetAllSensors();
        return Ok(data);
    }
}
