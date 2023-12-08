using Microsoft.AspNetCore.Mvc;
using SportBookApi.Data.Interface;
using SportBookApi.Model.DTO;
// remove
namespace SportBookApi.Model
{
    [Route("api/SportTypes")]
    [Controller]
    public class SportTypeController : ControllerBase
    {
        private readonly IRepository _repository;

        public SportTypeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SportTypeDTO>>> GetSportTypes()
        {
            try
            {
                return Ok(await _repository.GetSportTypesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SportTypeDTO>> GetSportType(int id)
        {
            try
            {
                SportTypeDTO s = await _repository.GetSportTypeAsync(id);

                if (s == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(s);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateASportType([FromBody] SportTypeDTO sportTypeDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SportType sportType = await _repository.CreateSportTypeAsync(sportTypeDto);
                    return CreatedAtAction(nameof(GetSportType), new { id = sportType.Id }, sportType);
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<SportType>> DeleteSportType(int id)
        {
            try
            {
                bool deletionSuccess = await _repository.DeleteSportTypeAsync(id);

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
