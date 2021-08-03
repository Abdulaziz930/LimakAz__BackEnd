using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IQuestionService
    {
        Task<Question> GetQuestionAsync(int id);

        Task<Question> GetQuestionWithLanguageAsync(int id);

        Task<List<Question>> GetAllQuestionsAsync();

        Task<List<Question>> GetAllQuestionsAsync(string langaugeCode);

        Task<List<Question>> GetAllQuestionsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(Question question);

        Task<bool> UpdateAsync(Question question);

        Task<bool> DeleteAsync(int id);
    }
}
