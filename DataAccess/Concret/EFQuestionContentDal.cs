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
    public class EFQuestionContentDal : EFRepositoryBase<QuestionContent, AppDbContext>, IQuestionContentDal
    {
        public EFQuestionContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<QuestionContent> GetQuestionContentAsync(string languageCode)
        {
            return await Context.QuestionContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<QuestionContent>> GetQuestionContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.QuestionContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}
