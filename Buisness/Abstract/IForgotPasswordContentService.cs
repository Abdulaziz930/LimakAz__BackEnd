using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IForgotPasswordContentService
    {
        Task<ForgotPasswordContent> GetForgotPasswordContentAsync(int id);

        Task<ForgotPasswordContent> GetForgotPasswordContentAsync(string languageCode);

        Task<List<ForgotPasswordContent>> GetAllForgotPasswordContentsAsync();

        Task<List<ForgotPasswordContent>> GetAllForgotPasswordContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(ForgotPasswordContent forgotPasswordContent);

        Task<bool> UpdateAsync(ForgotPasswordContent forgotPasswordContent);

        Task<bool> DeleteAsync(int id);
    }
}
