namespace Shop
{
    public interface IEmailSender { Task SendAsync(string to, string subject, string body); }

    public sealed class OrderNotifier(IEmailSender email)
    {
        public async Task NotifyAsync(decimal total)
        {
            if (total >= 1000)
                await email.SendAsync("ops@company.test", "Big order", $"Total: {total}");
        }
    }
}
