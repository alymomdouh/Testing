using NSubstitute;

namespace Shop.Tests
{
    public class OrderNotifierTests
    {
        [Fact]
        public async Task Sends_email_for_big_orders()
        {
            var email = Substitute.For<IEmailSender>();
            var sut = new OrderNotifier(email);

            await sut.NotifyAsync(1250);

            await email.Received(1)
                .SendAsync("ops@company.test", "Big order", Arg.Is<string>(b => b.Contains("1250")));
        }

        [Fact]
        public async Task Does_nothing_for_small_orders()
        {
            var email = Substitute.For<IEmailSender>();
            var sut = new OrderNotifier(email);

            await sut.NotifyAsync(99);

            await email.DidNotReceiveWithAnyArgs().SendAsync(default!, default!, default!);
        }
    }
} 
