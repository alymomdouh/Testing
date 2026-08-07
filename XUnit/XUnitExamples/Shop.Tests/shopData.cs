using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;
using Shouldly;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Shop.Tests
{
    public class PriceCalculatorTests
    {
        private readonly IClock _clock = Substitute.For<IClock>();
        private PriceCalculator Sut => new(_clock); // System Under Test

        [Fact]
        public void Calculate_throws_for_negative_price()
        {
            // Arrange
            _clock.UtcNow.Returns(new DateTimeOffset(2025, 3, 1, 0, 0, 0, TimeSpan.Zero)); // stable date

            // Act + Assert
            Should.Throw<ArgumentOutOfRangeException>(() => Sut.Calculate(-1, 0.1m));
        }

        [Theory]
        [InlineData(100, 0.00, 100)] // weekday, no discount
        [InlineData(100, 0.10, 90)] // weekday, 10%
        public void Weekday_cases(decimal basePrice, decimal discount, decimal expected)
        {
            _clock.UtcNow.Returns(new DateTimeOffset(2025, 3, 5, 0, 0, 0, TimeSpan.Zero)); // Wednesday
            var price = Sut.Calculate(basePrice, discount);
            price.ShouldBe(expected);
        }

        [Fact]
        public void Weekend_adds_extra_5_percent()
        {
            _clock.UtcNow.Returns(new DateTimeOffset(2025, 3, 1, 0, 0, 0, TimeSpan.Zero)); // Saturday
            var price = Sut.Calculate(100, 0.10m);
            price.ShouldBe(85); // 10% + 5%
        }

        [Fact]
        public void December_plus_weekend_caps_at_80_percent()
        {
            _clock.UtcNow.Returns(new DateTimeOffset(2025, 12, 7, 0, 0, 0, TimeSpan.Zero)); // Sunday in December
            var price = Sut.Calculate(100, 0.75m);            // 75 + 5 + 10 = 90 -> cap 80
            price.ShouldBe(20);
        }


//        Parameterized tests to cover more with less code
//Use[Theory] and[InlineData] when the rule is the same and only input/output changes.If your setup grows, switch to[MemberData] or a simple builder.
 
        public static IEnumerable<object[]> WeekendDates() =>
            [
                [new DateTimeOffset(2025, 3, 1, 0, 0, 0, TimeSpan.Zero)], // Sat
                [new DateTimeOffset(2025, 3, 2, 0, 0, 0, TimeSpan.Zero)], // Sun
            ];

        [Theory]
        [MemberData(nameof(WeekendDates))]
        public void Weekend_rule_triggers_on_both_days(DateTimeOffset when)
        {
            _clock.UtcNow.Returns(when);
            Sut.Calculate(100, 0.10m).ShouldBe(85m);
        }
    }
}
