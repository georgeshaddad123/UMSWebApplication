﻿using Microsoft.AspNetCore.SignalR;
using UMS.Infrastructure.Abstraction.ChatHub;

namespace UMS.Infrastructure.Services;

public class ChatHub : Hub, IChatHub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}