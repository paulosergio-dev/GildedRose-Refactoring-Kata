using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRose_Refactoring_Kata.Model
{
    public class RegularItem : Item
    {
        public int Id { get; set; }

        public int MaxQuality = 50;
        public int MinQuality = 0;
        protected int DegradeSpeed = 1;

        //Atualiza o SellIn e a qualidade do item como se um dia tivesse passado
        public void UpdateProperties()
        {
            UpdateQuality();
            ValidateQuality();
            UpdateSellIn();
        }

        // verifica se a qualidade está dentro do intervalo mínimo / máximo e corrige de acordo
        protected virtual void ValidateQuality()
        {
            if (this.Quality < MinQuality)
                this.Quality = MinQuality;
            else if (this.Quality > MaxQuality)
                this.Quality = MaxQuality;
        }
        public RegularItem()
        {
            this.Name = "";
            this.Quality = MinQuality;
            this.SellIn = 0;
        }

        // Atualiza a qualidade de um item regular
        protected virtual void UpdateQuality()
        {
            if (this.SellIn > 0)
            {
                this.Quality -= DegradeSpeed;
            }
            else
            {
                this.Quality -= DegradeSpeed * 2;
            }
        }
        // Atualiza a venda de um item regular
        protected virtual void UpdateSellIn()
        {
            this.SellIn--;
        }
    }
}
