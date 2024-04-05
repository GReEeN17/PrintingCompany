using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoPiterTest.Infrastructure.Entities.Abstractions;

namespace AutoPiterTest.Infrastructure.Entities.Entities;

public class PrintingTask : Entity
{
    [Column("name")]
    [Required]
    [StringLength(128)]
    public string Name { get; set; }
    
    [Column("employee_id")]
    [ForeignKey(nameof(Entities.Employee))]
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    [Column("serial_number")]
    [Required]
    public int SerialNumber { get; set; }
    
    [Column("number_of_pages")]
    [Required]
    public int NumberOfPages { get; set; }
    
    [Column("is_successful")]
    [Required]
    public bool IsSuccessful { get; set; }
}