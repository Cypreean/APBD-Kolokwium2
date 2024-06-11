using System.ComponentModel.DataAnnotations;
using kolos2.Models;

namespace kolos2.ResponseModels;

public class ResponseCharacterModel
{
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public int Money { get; set; }
    public List<BackpackSlots> BackpackSlots { get; set; }
    public List<Titlelist> Titles { get; set; }
}
public class BackpackSlots
{
    public int SlotId { get; set; }
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
    
}
public class Titlelist
{
    public string TitleName { get; set; }
    public DateTime AquireAt { get; set; }
}