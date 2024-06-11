using kolos2.Conext;
using kolos2.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Services;

public interface ICharacterService
{
    public Task<ResponseCharacterModel> GetCharacter(int id);
}
public class CharacterService(DatabaseContext context): ICharacterService
{
    public async Task<ResponseCharacterModel> GetCharacter(int id)
    {
        var result = await context.Characters
            .Where(e => e.CharacterId == id)
            .Select(e => new ResponseCharacterModel
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                CurrentWeight = e.CurrentWeight,
                MaxWeight = e.MaxWeight,
                Money = e.Money,
                BackpackSlots = e.BackpackSlots.Select(e => new BackpackSlots
                {
                    SlotId = e.BackpackSlotId,
                    ItemName = e.Item.Name,
                    ItemWeight = e.Item.Weight
                }).ToList(),
                Titles = e.CharacterTitles.Select(e => new Titlelist
                {
                    TitleName = e.Title.Nam,
                    AquireAt = e.AquireAt
                }).ToList() 
            }).FirstOrDefaultAsync();
        if (result is null)
        {
            throw new NotFoundException($"Character with id:{id} does not exist");
        }
        return result;
    }
}
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}