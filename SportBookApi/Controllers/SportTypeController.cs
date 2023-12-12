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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSportType(int id, [FromBody] SportTypeDTO sportTypeDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    SportType updatedSportType = await _repository.UpdateSportTypeAsync(id, sportTypeDto);

                    if (updatedSportType == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return CreatedAtAction(nameof(GetSportType), new { id = updatedSportType.Id }, updatedSportType);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
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
