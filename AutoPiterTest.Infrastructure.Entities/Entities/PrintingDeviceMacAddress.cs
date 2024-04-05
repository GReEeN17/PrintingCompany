using System.ComponentModel.DataAnnotations.Schema;
using AutoPiterTest.Infrastructure.Entities.Abstractions;

namespace AutoPiterTest.Infrastructure.Entities.Entities;

public class PrintingDeviceMacAddress : Entity
{
    [Column("printing_device_id")]
    [ForeignKey(nameof(Entities.PrintingDevice))]
    public Guid PrintingDeviceId { get; set; }
    public PrintingDevice PrintingDevice { get; set; }
    
    [Column("mac_address_id")]
    [ForeignKey(nameof(Entities.MacAddress))]
    public Guid MacAddressId { get; set; }
    public MacAddress MacAddress { get; set; }
}