using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GildedRose_Refactoring_Kata.Model;
using GildedRose_Refactoring_Kata.Model.Context;

namespace GildedRose_Refactoring_Kata.Factories
{
    public enum ItemTypes
    {
        Regular,
        Aged,
        Legendary,
        BackstagePass,
        Conjured
    }
    public class ItemFactory
    {
        public static RegularItem CreateItemByType(ItemTypes type)
        {
            return type switch
            {
                ItemTypes.Regular => new RegularItem(),
                ItemTypes.Aged => new AgedItem(),
                ItemTypes.Legendary => new LegendaryItem(),
                ItemTypes.BackstagePass => new BackstagePassItem(),
                ItemTypes.Conjured => new ConjuredItem(),
                _ => new RegularItem(),
            };
        }
    }
}
