using System;

namespace csharp
{
    public class UrgentItem : NormalItem
    {
        public UrgentItem(Item item) : base(item) { }

        public override void UpdateQuality(int previousSellin)
        {
            if (previousSellin <= 0) item.Quality = 0;
            if (previousSellin >= 1 && previousSellin <= 5) item.Quality = item.Quality + 3;
            if (previousSellin > 5 && previousSellin <= 10) item.Quality = item.Quality + 2;
            if (previousSellin > 10) item.Quality = item.Quality + 1;

            item.Quality = Math.Min(50, item.Quality);
        }
    }
}
