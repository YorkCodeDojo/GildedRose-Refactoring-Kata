using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItem(Items[i]);
            }
        }

        private void UpdateItem(Item item)
        {
            var strategy = SelectItemStrategy(item);
            var previousSellin = item.SellIn;
            strategy.UpdateSellin();
            strategy.UpdateQuality(previousSellin);

            item.Quality = Math.Max(0, item.Quality);
        }

        private static NormalItem SelectItemStrategy(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new IncreasingItem(item);

                case "Sulfuras, Hand of Ragnaros":
                    return new StaticItem(item);

                case "Backstage passes to a TAFKAL80ETC concert":
                    return new UrgentItem(item);

                case "Conjured Mana Cake":
                    return new FastDegrade(item);

                default:
                    return new NormalItem(item);
            }
        }
    }
}
