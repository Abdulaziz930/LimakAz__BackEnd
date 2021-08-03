using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IQuestionContentService
    {
        Task<QuestionContent> GetQuestionContentAsync(int id);

        Task<QuestionContent> GeQuestionContentAsync(string languageCode);

        Task<List<QuestionContent>> GetAllQuestionContentsAsync();

        Task<List<QuestionContent>> GetAlQuestionContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(QuestionContent questionContent);

        Task<bool> UpdateAsync(QuestionContent questionContent);

        Task<bool> DeleteAsync(int id);
    }
}
