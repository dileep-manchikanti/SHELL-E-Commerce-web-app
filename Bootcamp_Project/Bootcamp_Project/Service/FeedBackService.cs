using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Models.FeedBack;

namespace Bootcamp_Project.Service
{
    public class FeedBackService
    {
        private readonly EF_DataContext _context;
        private readonly ILogger _logger;

        public FeedBackService(EF_DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public ReviewSummary GetReviewSummary(int productId)
        {
            var feedbacks = _context.Feedbacks
                .Where(p => p.status == true && p.productId == productId)
                .OrderByDescending(p => p.createdDate)
                .ToList();

            List<string> reviews = feedbacks.Select(feedback => feedback.comments).ToList();
            float averageRating = (float) feedbacks.Average(feedback => feedback.rating);

            ReviewSummary reviewSummary = new ReviewSummary();
            reviewSummary.reviews = reviews;
            reviewSummary.averageRating = averageRating;
            return reviewSummary;
        }
    }
}
