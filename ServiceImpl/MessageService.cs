using Assignment_Backend.IService;
using Assignment_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Backend.ServiceImpl
{
    public class MessageService : IMessageService
    {
        private readonly MyDbContext _context;
        
        public MessageService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Message> CreateMessageAsync(Message message)
        {
            await _context.Message.AddAsync(message);
            await _context.SaveChangesAsync();

            return await _context.Message.Where(me => me.id == message.id).Include(me => me.user).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteMessageAsync(Message message)
        {
            int id = message.id;
            _context.Message.Remove(message);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<List<Message>> GetAllMessagesAsync()
        {
            return await _context.Message.Include(me => me.user).ToListAsync();
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _context.Message.FindAsync(id);
        }

        public async Task<Message> UpdateMessageAsync(Message oldMessage , Message newMessage)
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
