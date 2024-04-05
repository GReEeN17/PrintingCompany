using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPiterTest.Infrastructure.Entities.Abstractions;

public abstract class Entity : IEntity
{
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("is_active")]
    [Required]
    public bool IsActive { get; set; }
    
    [Column("created_at")]
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    [Required]
    public DateTime UpdatedAt { get; set; }
}