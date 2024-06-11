using System.ComponentModel.DataAnnotations;

namespace kolos2.RequestModel;

public class RequestBackpackSlotsModel
{
    [Required]
    public List<int> IdItems { get; set; }
}