using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IQuestionContentDal : IRepository<QuestionContent>
    {
        Task<QuestionContent> GetQuestionContentAsync(string languageCode);

        Task<List<QuestionContent>> GetQuestionContentsByCountAsync(int skipCount, int takeCount);
    }
}
