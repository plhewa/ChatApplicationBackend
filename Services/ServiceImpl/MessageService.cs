using Assignment_Backend.IService;
using Assignment_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_Backend.Repositories.IRepositories;

namespace Assignment_Backend.ServiceImpl
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<Message> CreateMessageAsync(Message message)
        {
            return await _messageRepository.AddMessageToDBAsync(message);
        }

        public async Task<int> DeleteMessageAsync(Message message)
        {
            return await _messageRepository.DeleteMessageOfDBAsync(message);
        }

        public async Task<List<Message>> GetAllMessagesAsync()
        {
            return await _messageRepository.GetAllMessagesFromDBAsync();
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _messageRepository.GetMessageByIdFromDBAsync(id);
        }

        public async Task<Message> UpdateMessageAsync(Message oldMessage , Message newMessage)
        {
            return await _messageRepository.UpdateMessageOfDBAsync(oldMessage, newMessage);

        }

    }
}
