namespace csharp
{
    public class StaticItem : NormalItem
    {
        public StaticItem(Item item) : base(item) { }

        public override void UpdateSellin()
        {
            // Sulfuras don't change
        }

        public override void UpdateQuality(int previousSellin)
        {
            // Sulfuras don't change
        }
    }
}
