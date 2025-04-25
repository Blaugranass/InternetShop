namespace InternetShop.Domain.Entities;

public class ComputerHardware : Product
{
    public ComputerHardwareType? Type {get; set; }

    public Guid TypeHardwareId;

    public Dictionary<string, string> Components {get; set; } = [];

}