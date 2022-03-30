using Assignment_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.SignalR
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(Message message);
    }
}
