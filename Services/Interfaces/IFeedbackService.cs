namespace SupplySyncBackend.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackResponseDto>> GetAllFeedbacks();
        Task<FeedbackResponseDto?> GetFeedbackById(int id);
        Task<FeedbackDto> AddFeedback(FeedbackDto feedbackDto);
        Task<bool> UpdateFeedback(int id, FeedbackDto feedbackDto);
        Task<bool> DeleteFeedback(int id);
    }
}
