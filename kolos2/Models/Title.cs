using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos2.Models;

[Table("Titles")]
public class Title
{
    [Key]
    [Required]
    [Column("PK")]
    public int TitleId { get; set; }
    
    [Required]
    [Column("nam")]
    [MaxLength(100)]
    public string Nam { get; set; }
    
    public ICollection<CharacterTitle> CharacterTitles { get; set; }
}