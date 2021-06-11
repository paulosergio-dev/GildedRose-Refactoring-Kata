using GildedRose_Refactoring_Kata.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRose_Refactoring_Kata.Model
{
    public class LegendaryItem : RegularItem
    {
        public LegendaryItem() // Qualidade fixa
        {
            this.MaxQuality = 80;
        }
        protected override void UpdateQuality()
        {
        }
        protected override void UpdateSellIn()
        {
        }
    }
}
