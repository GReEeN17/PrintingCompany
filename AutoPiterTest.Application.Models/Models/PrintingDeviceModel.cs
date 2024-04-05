using AutoPiterTest.Infrastructure.Entities.Enums;

namespace AutoPiterTest.Application.Models.Models;

public class PrintingDeviceModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ConnectionType ConnectionType { get; set; }
    List<PrintingDeviceMacAddressModel>? PrintingDevicesMacAddresses { get; set; }
}