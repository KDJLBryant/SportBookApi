using Microsoft.AspNetCore.Mvc;
using SportBookApi.Data.Interface;
using SportBookApi.Model.DTO;

namespace SportBookApi.Model
{
    [Route("api/Facilities")]
    [Controller]
    public class FacilityController : ControllerBase
    {
        private readonly IRepository _repository;

        public FacilityController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<FacilityDTO>>> GetFacilities()
        {
            try
            {
                return Ok(await _repository.GetFacilitiesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FacilityDTO>> GetFacility(int id)
        {
            try
            {
                FacilityDTO f = await _repository.GetFacilityAsync(id);

                if (f == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(f);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFacility([FromBody] FacilityDTO facilityDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Facility facility = await _repository.CreateFacilityAsync(facilityDto);
                    return CreatedAtAction(nameof(GetFacility), new { id = facility.Id }, facility);
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
        public async Task<IActionResult> UpdateFacility(int id, [FromBody] FacilityDTO facilityDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Facility updatedFacility = await _repository.UpdateFacilityAsync(id, facilityDto);

                    if (updatedFacility == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return CreatedAtAction(nameof(GetFacility), new { id = updatedFacility.Id }, updatedFacility);
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
        public async Task<ActionResult<Facility>> DeleteFacility(int id)
        {
            try
            {
                bool deletionSuccess = await _repository.DeleteFacilityAsync(id);

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
