using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoPiterTest.Infrastructure.Entities.Abstractions;

namespace AutoPiterTest.Infrastructure.Entities.Entities;

public class Branch : Entity
{
    [Column("name")]
    [Required]
    [StringLength(64)]
    public string Name { get; set; }
    
    [Column("location")]
    [Required]
    [StringLength(128)]
    public string Location { get; set; }
}