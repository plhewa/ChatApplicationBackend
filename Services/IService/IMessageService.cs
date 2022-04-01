using Assignment_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.IService
{
    public interface IMessageService
    {
        Task<Message> CreateMessageAsync(Message message);
        Task<List<Message>> GetAllMessagesAsync();
        Task<Message> GetMessageByIdAsync(int id);
        Task<Message> UpdateMessageAsync(Message oldMessage , Message newMessage);
        Task<int> DeleteMessageAsync(Message message);

    }
}
