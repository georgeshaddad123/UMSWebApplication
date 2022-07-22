namespace UMS.Infrastructure.Abstraction.ChatHub;

public interface IChatHub
{
    Task SendMessage(string user, string message);
}