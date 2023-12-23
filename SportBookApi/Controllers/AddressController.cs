using Microsoft.AspNetCore.Mvc;
using SportBookApi.Data.Interface;
using SportBookApi.Model.DTO;
// remove
namespace SportBookApi.Model
{
    [Route("api/Addresses")]
    [Controller]
    public class AddressController : ControllerBase
    {
        private readonly IRepository _repository;

        public AddressController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressDTO>>> GetAddresses()
        {
            try
            {
                return Ok(await _repository.GetAddressesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(int id)
        {
            try 
            {
                AddressDTO a = await _repository.GetAddressAsync(id);

                if (a == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(a);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressDTO addressDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Address address = await _repository.CreateAddressAsync(addressDto);
                    return CreatedAtAction(nameof(GetAddress), new { id = address.Id }, address);
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
        public async Task<IActionResult> UpdateAddress(int id, [FromBody]AddressDTO addressDto)
        {

            try
            {
                Address updatedAddress = await _repository.UpdateAddressAsync(id, addressDto);

                if (updatedAddress == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetAddress), new { id = updatedAddress.Id }, updatedAddress);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            try
            {
                bool deletionSuccess = await _repository.DeleteAddressAsync(id);

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
