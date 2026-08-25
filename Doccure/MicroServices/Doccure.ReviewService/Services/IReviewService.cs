using Doccure.ReviewService.Dtos.ReviewDto;

namespace Doccure.ReviewService.Services
{
    public interface IReviewService
    {
        Task<List<ResultReviewDto>> GetAllAsync();
        Task<GetByIdReviewDto> GetByIdAsync(string id);
        Task CreateAsync(CreateReviewDto dto);
        Task DeleteAsync(string id);
    }
}
