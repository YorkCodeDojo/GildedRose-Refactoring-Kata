using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace csharp
{
    public class Tests
    {
        [Fact]
        public void Each_Day_The_SellIn_Decreases()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(9, Items.First().SellIn);
        }

        [Fact]
        public void Each_Day_The_Quality_Decreases()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(19, Items.First().Quality);
        }

        [Fact]
        public void Quality_Decreases_Twice_As_Fast_Once_The_Sell_By_Date_Has_Passed()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(18, Items.First().Quality);
        }


        [Fact]
        public void The_Quality_Of_An_Item_CanNot_Be_Negative()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(0, Items.First().Quality);
        }

        [Fact]
        public void Aged_Brie_Increases_In_Quality()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 20}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(21, Items.First().Quality);
        }

        [Fact]
        public void The_Quality_Of_An_Item_Cannot_Be_More_Than_50()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 50}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(50, Items.First().Quality);
        }

        [Fact]
        public void Sulfuras_Never_Change_Their_Quantity_Or_SellIn()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(80, Items.First().Quality);
            Assert.Equal(-1, Items.First().SellIn);
        }

        [Fact]
        public void The_Quality_Of_Backstage_Passes_Increases_By_2_When_Sellin_Is_Less_Than_10_and_Greater_Than_5()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(12, Items.First().Quality);
        }

        [Fact]
        public void The_Quality_Of_Backstage_Passes_Increases_By_3_When_Sellin_Is_Less_Than_5_and_Greater_Than_0()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(13, Items.First().Quality);
        }

        [Fact]
        public void The_Quality_Of_Backstage_Passes_Drops_To_0_When_The_Concert_Has_Passed()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(0, Items.First().Quality);
        }

        [Fact]
        public void The_Quality_Of_A_Conjured_Item_Drops_Twice_As_Fast_As_Normal_Items()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 10}
            };

            var app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(8, Items.First().Quality);
        }

    }
}
