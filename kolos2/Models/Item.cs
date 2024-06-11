using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos2.Models;

[Table("Items")]
public class Item
{
    [Key]
    [Required]
    [Column("PK")]
    public int ItemId { get; set; }
    
    [Required]
    [Column("name")]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [Column("weig")]
    public int Weight { get; set; }
    
    public ICollection<BackpackSlot> BackpackSlots { get; set; }
}