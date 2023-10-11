using Domain.Entities;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            return Created(string.Empty, await _userService.AddNewUserAsync(user));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            if (user.Id == default)
                return BadRequest();

            return Ok(await _userService.UpdateUserAsync(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _userService.DeleteUserAsync(id));
        }
    }
}
