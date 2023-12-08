using Microsoft.AspNetCore.Mvc;
using SportBookApi.Data.Interface;
using SportBookApi.Model.DTO;
// remove
namespace SportBookApi.Model
{
    [Route("api/Reviews")]
    [Controller]
    public class ReviewController : ControllerBase
    {
        private readonly IRepository _repository;

        public ReviewController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewDTO>>> GetReviews()
        {
            try
            {
                return Ok(await _repository.GetReviewsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReview(int id)
        {
            try
            {
                ReviewDTO r = await _repository.GetReviewAsync(id);

                if (r == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(r);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewDTO reviewDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Review review = await _repository.CreateReviewAsync(reviewDto);
                    return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
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
        public async Task<ActionResult<Review>> DeleteReview(int id)
        {
            try
            {
                bool deletionSuccess = await _repository.DeleteReviewAsync(id);

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
