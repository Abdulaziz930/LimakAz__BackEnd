using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public async Task<bool> AddAsync(Question question)
        {
            await _questionDal.AddAsync(question);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _questionDal.DeleteAsync(new Question { Id = id });

            return true;
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _questionDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Question>> GetAllQuestionsAsync(string langaugeCode)
        {
            return await _questionDal.GetAllMultiLanguageQuestionsAsync(langaugeCode);
        }

        public async Task<List<Question>> GetAllQuestionsAsync(int skipCount, int takeCount)
        {
            return await _questionDal.GetQuestionsByCountAsync(skipCount, takeCount);
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _questionDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Question> GetQuestionWithLanguageAsync(int id)
        {
            return await _questionDal.GetQuestionWithInclude(id);
        }

        public async Task<bool> UpdateAsync(Question question)
        {
            await _questionDal.UpdateAsync(question);

            return true;
        }
    }
}
