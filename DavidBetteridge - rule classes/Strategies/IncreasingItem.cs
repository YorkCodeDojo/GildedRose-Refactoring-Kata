using System;

namespace csharp
{
    public class IncreasingItem : NormalItem
    {
        public IncreasingItem(Item item) : base(item) { }

        public override void UpdateQuality(int previousSellin)
        {
            this.item.Quality++;

            if (previousSellin <= 0)
                this.item.Quality++;

            item.Quality = Math.Min(50, item.Quality);
        }
    }
}
