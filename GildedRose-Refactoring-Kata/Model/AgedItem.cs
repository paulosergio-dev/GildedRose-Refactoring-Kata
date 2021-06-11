using GildedRose_Refactoring_Kata.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRose_Refactoring_Kata.Model
{
    public class AgedItem : RegularItem
    {
        //Itens envelhecidos aumentam em qualidade com o tempo
        public AgedItem()
        {
            this.DegradeSpeed = -1;
        }
    }
}
