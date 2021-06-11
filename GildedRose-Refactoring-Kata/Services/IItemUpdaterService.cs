using GildedRose_Refactoring_Kata.Factories;
using GildedRose_Refactoring_Kata.Model;
using GildedRose_Refactoring_Kata.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRose_Refactoring_Kata.Services
{
    public interface IItemUpdaterService
    {
        void UpdateQuality();
        Item Find(int id);
        RegularItem Add(Item item, ItemTypes type);
        IList<Item> GetAll();
    }
}
