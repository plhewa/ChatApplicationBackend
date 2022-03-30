using Assignment_Backend.IService;
using Assignment_Backend.Models;
using Assignment_Backend.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext,IMessageService messageService)
        {
            _hubContext = hubContext;
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] Message message)
        {

            var messageObject = await _messageService.CreateMessageAsync(message);

            if (messageObject == null)
            {
                return BadRequest("Something went wrong!");
            }

            await _hubContext.Clients.All.BroadcastMessage(messageObject);
            return Created("Message", messageObject);

        }

        [HttpGet]

        public async Task<IActionResult> GetMessages()
        {
            var messageList = await _messageService.GetAllMessagesAsync();
            return Ok(messageList);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMessageById(int id)
        {
            Message message = await _messageService.GetMessageByIdAsync(id);
            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id , [FromBody] Message newMessage)
        {
            Message oldMessage = await _messageService.GetMessageByIdAsync(id);

            if(oldMessage == null)
            {
                return NotFound("Message could not find !");
            }

            var modifiedMessage = await _messageService.UpdateMessageAsync(oldMessage, newMessage);

            if (modifiedMessage == null)
            {
                return BadRequest("Something went wrong");
            }

            await _hubContext.Clients.All.BroadcastMessage(modifiedMessage);
            return Ok(modifiedMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            Message message = await _messageService.GetMessageByIdAsync(id);

            if (message == null )
            {
                return NotFound("Message not found !");
            }

            int deletedMessageId = await _messageService.DeleteMessageAsync(message);

            if(deletedMessageId == null)
            {
                return BadRequest("Some thing went wrong !");
            }
            await _hubContext.Clients.All.BroadcastMessage(message);
            return Ok(deletedMessageId);
        }
    }
}
