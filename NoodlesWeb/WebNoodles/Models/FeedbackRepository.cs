using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNoodles.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext dbContext;

        public FeedbackRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            dbContext.Feedbacks.Add(feedback);
        }

        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            return dbContext.Feedbacks;
        }

    }
}
