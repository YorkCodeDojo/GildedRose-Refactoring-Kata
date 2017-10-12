using System;

namespace csharp
{
    public class NormalItem
    {
        protected readonly Item item;
        public NormalItem(Item item)
        {
            this.item = item;
        }

        public virtual void UpdateSellin()
        {
            this.item.SellIn--;
        }

        public virtual void UpdateQuality(int previousSellin)
        {
            this.item.Quality--;

            if (previousSellin <= 0)
                this.item.Quality--;

            item.Quality = Math.Min(50, item.Quality);
        }
    }
}
