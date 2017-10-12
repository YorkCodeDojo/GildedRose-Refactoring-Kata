using System;

namespace csharp
{
    public class FastDegrade : NormalItem
    {
        public FastDegrade(Item item) : base(item) { }

        public override void UpdateQuality(int previousSellin)
        {
            this.item.Quality -= 2;

            if (previousSellin <= 0)
                this.item.Quality -= 2;

            item.Quality = Math.Min(50, item.Quality);
        }
    }
}
