using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Models;

[Table("Character_Titles")]
[PrimaryKey("CharacterId","TitleId")]
public class CharacterTitle
{
    [Key]
    [Required]
    [Column("FK_charact")]
    [ForeignKey("Character")]
    public int CharacterId { get; set; }
  
    public Character Character { get; set; }
    
    [Key]
    [Required]
    [Column("FK_title")]
    [ForeignKey("Title")]
    public int TitleId { get; set; }
    
    public Title Title { get; set; }
    
    [Required]
    [Column("aquire_at")]
    public DateTime AquireAt { get; set; }
}