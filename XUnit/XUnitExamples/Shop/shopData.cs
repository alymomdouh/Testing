namespace Shop
{
    public interface IClock
    {
        DateTimeOffset UtcNow { get; }
    }

    public sealed class SystemClock : IClock
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }

    public sealed class PriceCalculator(IClock clock)
    {
        public decimal Calculate(decimal basePrice, decimal discount)
        {
            if (basePrice < 0) throw new ArgumentOutOfRangeException(nameof(basePrice));
            if (discount is < 0 or > 1) throw new ArgumentOutOfRangeException(nameof(discount));

            var now = clock.UtcNow;
            var weekend = now.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
            var december = now.Month == 12;

            var finalDiscount = discount;
            if (weekend) finalDiscount += 0.05m;
            if (december) finalDiscount += 0.10m;

            finalDiscount = Math.Min(finalDiscount, 0.80m);

            var price = basePrice * (1 - finalDiscount);
            return Math.Round(price, 2, MidpointRounding.AwayFromZero);
        }
    }
}
