using GildedRose_Refactoring_Kata.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRose_Refactoring_Kata.Model
{
    public class ConjuredItem : RegularItem
    {
        public ConjuredItem()
        {
            this.DegradeSpeed *= 2;
        }
    }
}
