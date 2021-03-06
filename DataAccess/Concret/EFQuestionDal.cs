using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFQuestionDal : EFRepositoryBase<Question, AppDbContext>, IQuestionDal
    {
        public EFQuestionDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Question>> GetAllMultiLanguageQuestionsAsync(string languageCode)
        {
            return await Context.Questions
                .Include(x => x.Language)
                .Where(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode)
                .OrderByDescending(x => x.LastModificationDate).ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Questions.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.LastModificationDate).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<Question> GetQuestionWithInclude(int id)
        {
            return await Context.Questions.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}
