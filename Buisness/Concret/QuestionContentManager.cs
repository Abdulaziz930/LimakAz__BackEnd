using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class QuestionContentManager : IQuestionContentService
    {
        private readonly IQuestionContentDal _questionContentDal;

        public QuestionContentManager(IQuestionContentDal questionContentDal)
        {
            _questionContentDal = questionContentDal;
        }

        public async Task<bool> AddAsync(QuestionContent questionContent)
        {
            await _questionContentDal.AddAsync(questionContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _questionContentDal.DeleteAsync(new QuestionContent { Id = id });

            return true;
        }

        public async Task<QuestionContent> GeQuestionContentAsync(string languageCode)
        {
            return await _questionContentDal.GetQuestionContentAsync(languageCode);
        }

        public async Task<List<QuestionContent>> GetAllQuestionContentsAsync()
        {
            return await _questionContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<QuestionContent>> GetAlQuestionContentsAsync(int skipCount, int takeCount)
        {
            return await _questionContentDal.GetQuestionContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<QuestionContent> GetQuestionContentAsync(int id)
        {
            return await _questionContentDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<bool> UpdateAsync(QuestionContent questionContent)
        {
            await _questionContentDal.UpdateAsync(questionContent);

            return true;
        }
    }
}
