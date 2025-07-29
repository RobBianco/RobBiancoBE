using LibreHardwareMonitor.Hardware;
using RobBiancoBE.DTOs;

namespace RobBiancoBE.Hardware;

public class HardwareMonitorService
{
    private readonly Computer _computer;

    public HardwareMonitorService()
    {
        _computer = new Computer
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMemoryEnabled = true,
            IsMotherboardEnabled = true,
            IsControllerEnabled = true,
            IsNetworkEnabled = true,
            IsStorageEnabled = true
        };
        _computer.Open();
    }

    public List<HardwareSensorDto> GetAllSensors()
    {
        var sensors = new List<HardwareSensorDto>();

        _computer.Accept(new UpdateVisitor());

        foreach (var hardware in _computer.Hardware)
        {
            CollectSensors(hardware, sensors);
        }

        return sensors;
    }

    private void CollectSensors(IHardware hardware, List<HardwareSensorDto> sensors)
    {
        foreach (var sensor in hardware.Sensors)
        {
            if (!(sensor?.Value != null))
                continue;

            sensors.Add(new HardwareSensorDto
            {
                Hardware = hardware.Name,
                SensorName = sensor.Name,
                SensorType = sensor.SensorType.ToString(),
                Value = sensor.Value.Value.ToString("F2") ?? "???"
            });
        }

        foreach (var sub in hardware.SubHardware)
        {
            CollectSensors(sub, sensors);
        }
    }
}
