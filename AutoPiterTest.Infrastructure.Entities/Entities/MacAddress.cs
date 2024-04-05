using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoPiterTest.Infrastructure.Entities.Abstractions;

namespace AutoPiterTest.Infrastructure.Entities.Entities;

public class MacAddress : Entity
{
    [Column("mac_address_name")]
    [Required]
    [StringLength(12)]
    public string MacAddressName { get; set; }
}