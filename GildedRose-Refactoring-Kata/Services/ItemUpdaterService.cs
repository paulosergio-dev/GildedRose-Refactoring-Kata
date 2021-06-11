using GildedRose_Refactoring_Kata.Factories;
using GildedRose_Refactoring_Kata.Model;
using GildedRose_Refactoring_Kata.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose_Refactoring_Kata.Services
{
    public class ItemUpdaterService : IItemUpdaterService
    {
        IList<Item> Items;
        RegularItemContext _context;
        public ItemUpdaterService(RegularItemContext context)
        {
            this._context = context;
            Items = new List<Item>();
            foreach (var item in context.RegularItems.ToList())
            {
                Items.Add(item);
            }
        }

        public ItemUpdaterService(IList<Item> Items)
        {
            this.Items = Items;
        }

        public RegularItem Add(Item item, ItemTypes type)
        {
            var actualItem = ItemFactory.CreateItemByType(type);
            actualItem.Name = item.Name;
            actualItem.SellIn = item.SellIn;
            actualItem.Quality = item.Quality;
            _context.RegularItems.Add(actualItem);
            _context.SaveChanges();
            return actualItem;
        }

        public Item Find(int id)
        {
            return this.Items.Where((item) => { return id == (item as RegularItem).Id; }).FirstOrDefault();
        }

        public IList<Item> GetAll()
        {
            return this.Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items) // Atualiza cada item
            {
                if (item is RegularItem) // Verifica o item
                    (item as RegularItem).UpdateProperties();
            }
            if (_context != null)
                _context.SaveChanges();
        }
    }
}

