using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Shouldly;

namespace Shop.Tests
{
    public class PriceEndpointsTests
    {
        [Fact]
        public void Handler_returns_200_with_amount()
        {
            // Arrange
            var clock = Substitute.For<IClock>();
            clock.UtcNow.Returns(new DateTimeOffset(2025, 3, 5, 0, 0, 0, TimeSpan.Zero));
            var calc = new PriceCalculator(clock);

            // Act
            var result = PriceEndpoints.Calculate(new PriceRequest(100, 0.10m), calc);

            // Assert
            var ok = result.ShouldBeOfType<Ok<PriceResponse>>();
            ok.Value!.Amount.ShouldBe(90m);
        }
    }
}
