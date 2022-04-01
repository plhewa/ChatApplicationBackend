using Assignment_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.Repositories.IRepositories
{
    public interface IMessageRepository
    {
        Task<Models.Message> AddMessageToDBAsync(Message message);
        Task<List<Message>> GetAllMessagesFromDBAsync();
        Task<Message> GetMessageByIdFromDBAsync(int id);
        Task<Message> UpdateMessageOfDBAsync(Message oldMessage, Message newMessage);
        Task<int> DeleteMessageOfDBAsync(Message message);
    }
}
