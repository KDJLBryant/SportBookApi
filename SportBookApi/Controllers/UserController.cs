using Microsoft.AspNetCore.Mvc;
using SportBookApi.Data.Interface;
using SportBookApi.Model.DTO;

namespace SportBookApi.Model
{
    [Route("api/Users")]
    [Controller]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingDTO>>> GetUsers()
        {
            try
            {
                return Ok(await _repository.GetUsersAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            try
            {
                UserDTO u = await _repository.GetUserAsync(id);

                if (u == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(u);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await _repository.CreateUserAsync(userDto);
                    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
        {

            try
            {
                User updatedUser = await _repository.UpdateUserAsync(id, userDto);

                if (updatedUser == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetUser), new { id = updatedUser.Id }, updatedUser);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                bool deletionSuccess = await _repository.DeleteUserAsync(id);

                if (deletionSuccess)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
