namespace Shop
{
    public static class PriceEndpoints
    {
        public static IResult Calculate(PriceRequest req, PriceCalculator calc)
        {
            var amount = calc.Calculate(req.BasePrice, req.Discount);
            return TypedResults.Ok(new PriceResponse(amount));
        }
    }

    public sealed record PriceRequest(decimal BasePrice, decimal Discount);
    public sealed record PriceResponse(decimal Amount);
}
