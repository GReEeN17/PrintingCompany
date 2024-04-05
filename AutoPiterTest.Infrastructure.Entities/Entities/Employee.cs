using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoPiterTest.Infrastructure.Entities.Abstractions;

namespace AutoPiterTest.Infrastructure.Entities.Entities;

public class Employee : Entity
{
    [Column("name")]
    [Required]
    [StringLength(128)]
    public string Name { get; set; }
    
    [Column("branch_id")]
    [ForeignKey(nameof(Entities.Branch))]
    public Guid BranchId { get; set; }
    public Branch Branch { get; set; }
}