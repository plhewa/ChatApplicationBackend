using Assignment_Backend.Models;
using Assignment_Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.Repositories.RepositoryImplmentation
{
    public class MessageRepositoryImpl : IMessageRepository
    {
        private readonly MyDbContext _context;

        public MessageRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Message> AddMessageToDBAsync(Message message)
        {
            await _context.Message.AddAsync(message);
            await _context.SaveChangesAsync();

            return await _context.Message.Where(me => me.id == message.id).Include(me => me.user).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteMessageOfDBAsync(Message message)
        {
            int id = message.id;
            _context.Message.Remove(message);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<List<Message>> GetAllMessagesFromDBAsync()
        {
            return await _context.Message.Include(me => me.user).ToListAsync();
        }

        public async Task<Message> GetMessageByIdFromDBAsync(int id)
        {
            return await _context.Message.FindAsync(id);
        }

        public async Task<Message> UpdateMessageOfDBAsync(Message oldMessage, Message newMessage)
        {
            if (!newMessage.message.Equals(""))
            {
                oldMessage.message = newMessage.message;
            }

            await _context.SaveChangesAsync();

            return await _context.Message.Where(me => me.id == oldMessage.id).Include(me => me.user).FirstOrDefaultAsync();
        }
    }
}
