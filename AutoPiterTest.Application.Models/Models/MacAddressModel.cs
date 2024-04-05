namespace AutoPiterTest.Application.Models.Models;

public class MacAddressModel
{
    public Guid Id { get; set; }
    public string MacAddressName { get; set; }
    public List<PrintingDeviceMacAddressModel>? PrintingDeviceMacAddresses { get; set; }
}