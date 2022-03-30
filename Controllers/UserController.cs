using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_Backend.IService;
using Assignment_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var userObject = await _userService.CreateUserAsync(user);

            if (userObject == null)
            {
                return BadRequest("Something went wrong!");
            }

            return Created("User", userObject);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = await _userService.GetAllUsersAsync();
            return Ok(userList);
        }
    }
}
