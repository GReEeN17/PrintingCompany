namespace AutoPiterTest.Application.Models.Models;

public class BranchPrintingDeviceModel
{
    public Guid Id { get; set; }
    public string BranchPrintingDeviceName { get; set; }
    public int SerialNumber { get; set; }
    public bool Default { get; set; }
    public BranchModel Branch { get; set; }
    public PrintingDeviceModel PrintingDevice { get; set; }
}