using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IQuestionDal : IRepository<Question>
    {
        Task<Question> GetQuestionWithInclude(int id);

        Task<List<Question>> GetAllMultiLanguageQuestionsAsync(string languageCode);

        Task<List<Question>> GetQuestionsByCountAsync(int skipCount, int takeCount);
    }
}
