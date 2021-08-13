using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IForgotPasswordContentDal : IRepository<ForgotPasswordContent>
    {
        Task<ForgotPasswordContent> GetForgotPasswordContentAsync(string languageCode);

        Task<List<ForgotPasswordContent>> GetForgotPasswordContentsByCountAsync(int skipCount, int takeCount);
    }
}
