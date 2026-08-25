using Doccure.ReviewService.Dtos.ReviewDto;
using Doccure.ReviewService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var values = await _reviewService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(string id)
        {
            var value = await _reviewService.GetByIdAsync(id);
            if (value == null)
                return NotFound("Review not found");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto dto)
        {
            await _reviewService.CreateAsync(dto);
            return Ok("Review başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            await _reviewService.DeleteAsync(id);
            return Ok("Review başarıyla silindi");
        }
    }
}
