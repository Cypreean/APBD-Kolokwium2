using kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolos2.Endpoints;
[ApiController]
[Route("api/characters/{id:int}")]
public class Endpoints : ControllerBase
{
    private readonly ICharacterService _characterService;
    private readonly IBackpackSlotsService _backpackSlotsService;
    
    
    
    public Endpoints(ICharacterService characterService, IBackpackSlotsService backpackSlotsService)
    {
        _characterService = characterService;
        _backpackSlotsService = backpackSlotsService;
    }
 
    
    [HttpGet]
    public async Task<IActionResult> GetCharacter(int id)
    {
        try
        {
            return Ok(await _characterService.GetCharacter(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("backpackslots")]
    public async Task<IActionResult> AddItemsToBackpack(int id, List<int> IDs)
    {
        try
        {
            return Ok(await _backpackSlotsService.AddItemsToBackpack(IDs, id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (OverweightException e)
        {
            return BadRequest(e.Message);
        }
    }
}