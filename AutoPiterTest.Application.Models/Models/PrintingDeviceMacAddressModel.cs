namespace AutoPiterTest.Application.Models.Models;

public class PrintingDeviceMacAddressModel
{
    public Guid Id { get; set; }
    public PrintingDeviceModel PrintingDevice { get; set; }
    public MacAddressModel MacAddressId { get; set; }
}