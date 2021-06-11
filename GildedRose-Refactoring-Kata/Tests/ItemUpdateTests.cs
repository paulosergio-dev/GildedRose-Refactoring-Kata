using GildedRose_Refactoring_Kata.Factories;
using GildedRose_Refactoring_Kata.Model;
using GildedRose_Refactoring_Kata.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose_Refactoring_Kata.Tests
{
    public class ItemUpdateTests
    {
        [Test]
        public void TestItemValueDecrease()
        {
            //Final do dia, atualiza subtraindo a quantidade e venda de cada item.
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.Regular);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Regular Item", 100, 50);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 49);
                Assert.AreEqual(item.SellIn, 99);
            }
        }

        [Test]
        public void TestItemDegradesTwiceAsFast()
        {
            //Degrada 2 vezes mais rápido.
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.Regular);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Regular Item", 0, 48);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 46);
                Assert.AreEqual(item.SellIn, -1);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 44);
                Assert.AreEqual(item.SellIn, -2);
            }
        }

        [Test]
        public void TestItemQualityNotNegative()
        {
            //Quantidade de um item, nunca fica negativo.
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.Regular);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Regular Item", 0, 1);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 0);
                Assert.AreEqual(item.SellIn, -1);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 0);
                Assert.AreEqual(item.SellIn, -2);
            }
        }

        [Test]
        public void TestItemAgedBrie()
        {
            //"Aged Brie" aumenta em qualidade quando fica mais velho
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.Aged);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Aged Brie", 1, 1);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 2);
                Assert.AreEqual(item.SellIn, 0);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 4);
                Assert.AreEqual(item.SellIn, -1);
            }
        }

        [Test]
        public void TestItemQualityMax()
        {
            //A qualidade de um item nunca é superior a 50
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.Aged);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Aged Brie", 1, 48);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 49);
                Assert.AreEqual(item.SellIn, 0);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 50);
                Assert.AreEqual(item.SellIn, -1);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 50);
                Assert.AreEqual(item.SellIn, -2);
            }
        }

        [Test]
        public void TestItemSulfuras()
        {
            //"Sulfuras", sendo um item lendário, nunca precisa ser vendido ou diminui sua Qualidade
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.Legendary);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Sulfuras, Hand of Ragnaros", 100, 80);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 80);
                Assert.AreEqual(item.SellIn, 100);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 80);
                Assert.AreEqual(item.SellIn, 100);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 80);
                Assert.AreEqual(item.SellIn, 100);
            }
        }

        [Test]
        public void TestBackstagePassIncreaseBy2()
        {
            //"Backstage passes", aumenta em qualidade à medida que seu valor SellIn se aproxima;
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.BackstagePass);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Backstage passes to a TAFKAL80ETC concert", 12, 10);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 11);
                Assert.AreEqual(item.SellIn, 11);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 12);
                Assert.AreEqual(item.SellIn, 10);
            }
            app.UpdateQuality();
            //Quality aumenta em 2 quando há 10 dias ou menos
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 14);
                Assert.AreEqual(item.SellIn, 9);
            }
        }

        [Test]
        public void TestBackstagePassIncreaseBy3()
        {
            //"Backstage passes", como o brie envelhecido, aumenta em qualidade à medida que seu valor SellIn se aproxima;
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.BackstagePass);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Backstage passes to a TAFKAL80ETC concert", 5, 10);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            //Quality aumenta em 3 quando há 5 dias ou menos
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 13);
                Assert.AreEqual(item.SellIn, 4);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 16);
                Assert.AreEqual(item.SellIn, 3);
            }
        }

        [Test]
        public void TestBackstageDropTo0()
        {
            //Quality cai para 0 após o concerto
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.BackstagePass);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Backstage passes to a TAFKAL80ETC concert", 1, 10);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            //Quality aumenta em 3 quando há 5 dias ou menos
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 13);
                Assert.AreEqual(item.SellIn, 0);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 0);
                Assert.AreEqual(item.SellIn, -1);
            }
        }

        [Test]
        public void TestConjuredItem()
        {
            //"Conjured" itens degradam em qualidade duas vezes mais rápido que itens normais
            Item myItem = ItemFactory.CreateItemByType(ItemTypes.Conjured);
            (myItem.Name, myItem.SellIn, myItem.Quality) = ("Backstage passes to a TAFKAL80ETC concert", 5, 10);
            IList<Item> items = new List<Item> { myItem };
            ItemUpdaterService app = new(items);
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 8);
                Assert.AreEqual(item.SellIn, 4);
            }
            app.UpdateQuality();
            foreach (Item item in items)
            {
                Assert.AreEqual(item.Quality, 6);
                Assert.AreEqual(item.SellIn, 3);
            }
        }
    }
}
