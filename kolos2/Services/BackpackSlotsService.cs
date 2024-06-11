using kolos2.Conext;
using kolos2.Models;
using kolos2.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Services;

public interface IBackpackSlotsService
{
    public Task<List<ResponseBackpackSlotsModel>> AddItemsToBackpack(List<int> IDs,int id);
}

public class BackpackSlotsService(DatabaseContext context): IBackpackSlotsService
{
    public async Task<List<ResponseBackpackSlotsModel>> AddItemsToBackpack(List<int> IDs, int id)
    {
        using var transaction = context.Database.BeginTransaction();

        try
        {
           
            var uniqueIDs = IDs.Distinct().ToList();

            var items = await context.Items.Where(i => uniqueIDs.Contains(i.ItemId)).ToListAsync();
            if (items.Count != uniqueIDs.Count)
            {
                throw new NotFoundException("Some items do not exist in the database");
            }

         
            var character = await context.Characters.Include(c => c.BackpackSlots).ThenInclude(bs => bs.Item).FirstOrDefaultAsync(c => c.CharacterId == id);
            if (character == null)
            {
                throw new NotFoundException("Character does not exist");
            }

            var totalWeight = IDs.Select(id => items.First(i => i.ItemId == id).Weight).Sum();
            var currentWeight = character.BackpackSlots.Sum(bs => bs.Item.Weight);
            if (currentWeight + totalWeight > character.MaxWeight)
            {
                throw new OverweightException("Character does not have enough carrying capacity");
            }

            foreach (var itemId in IDs)
            {
                var item = items.First(i => i.ItemId == itemId);
                character.BackpackSlots.Add(new BackpackSlot { ItemId = item.ItemId, CharacterId = character.CharacterId });
            }
            character.CurrentWeight += totalWeight;
            await context.SaveChangesAsync();
           
            
            transaction.Commit();
            var result = await context.BackpackSlots
                .Where(bs => bs.CharacterId == id)
                .OrderByDescending(bs => bs.BackpackSlotId)
                .Take(IDs.Count)
                .Select(bs => new ResponseBackpackSlotsModel
                {
                    SlotID = bs.BackpackSlotId,
                    ItemID = bs.ItemId,
                    CharacterID = bs.CharacterId
                })
                .ToListAsync();
            

            return result;
           
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
        }

        

    }
public class OverweightException : Exception
{
    public OverweightException(string message) : base(message)
    {
    }
}

    

