using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos2.Models;

[Table("Characters")]
public class Character
{
    [Key]
    [Required]
    [Column("PK")]
    public int CharacterId { get; set; }
    
    [Required]
    [Column("first_name")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [Column("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [Column("current_weig")]
    public int CurrentWeight { get; set; }
    
    [Required]
    [Column("max_weight")]
    public int MaxWeight { get; set; }
    
    [Required]
    [Column("money")]
    public int Money { get; set; }
    
    public ICollection<BackpackSlot> BackpackSlots { get; set; }
    
    public ICollection<CharacterTitle> CharacterTitles { get; set; }
}