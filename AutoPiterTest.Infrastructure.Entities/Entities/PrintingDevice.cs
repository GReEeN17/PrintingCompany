using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoPiterTest.Infrastructure.Entities.Abstractions;
using AutoPiterTest.Infrastructure.Entities.Enums;

namespace AutoPiterTest.Infrastructure.Entities.Entities;

public class PrintingDevice : Entity
{
    [Column("name")]
    [Required]
    [StringLength(128)]
    public string Name { get; set; }
    
    [Column("connection_type")]
    [Required]
    public ConnectionType ConnectionType { get; set; }
    
    List<PrintingDeviceMacAddress>? PrintingDevicesMacAddresses { get; set; }
}