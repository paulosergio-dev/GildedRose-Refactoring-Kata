using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRose_Refactoring_Kata.Model
{
    public class BackstagePassItem : AgedItem
    {
        private const int QualityTwoIncreaseDays = 10;
        private const int QualityThreeIncreaseDays = 5;
        protected override void UpdateQuality()
        {
            if (this.SellIn == 0)
                this.Quality = MinQuality;
            else if (this.SellIn <= QualityThreeIncreaseDays)
                this.Quality += 3;
            else if (this.SellIn <= QualityTwoIncreaseDays)
                this.Quality += 2;
            else
                base.UpdateQuality();
        }
    }
}
