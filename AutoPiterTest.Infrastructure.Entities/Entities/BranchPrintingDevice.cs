using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoPiterTest.Infrastructure.Entities.Abstractions;

namespace AutoPiterTest.Infrastructure.Entities.Entities;

public class BranchPrintingDevice : Entity
{
    [Column("branch_printing_device_name")]
    [Required]
    [StringLength(128)]
    public string BranchPrintingDeviceName { get; set; }
    
    [Column("serial_number")]
    [Required]
    public int SerialNumber { get; set; }
    
    [Column("default")]
    [Required]
    public bool Default { get; set; }
    
    [Column("branch_id")]
    [ForeignKey(nameof(Entities.Branch))]
    public Guid BranchId { get; set; }
    public Branch Branch { get; set; }
    
    [Column("printing_device_id")]
    [ForeignKey(nameof(Entities.PrintingDevice))]
    public Guid PrintingDeviceId { get; set; }
    public PrintingDevice PrintingDevice { get; set; }
}