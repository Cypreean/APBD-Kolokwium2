using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Models;

[Table("Backpack_Slots")]
public class BackpackSlot
{
    [Key]
    [Required]
    [Column("PK")]
    public int BackpackSlotId { get; set; }
    
    [Required]
    [Column("FK_item")]
    [ForeignKey("Item")]
    public int ItemId { get; set; }
    
    public Item Item { get; set; }
    
    [Required]
    [Column("FK_character")]
    [ForeignKey("Character")]
    public int CharacterId { get; set; }
    
    public Character Character { get; set; }
}