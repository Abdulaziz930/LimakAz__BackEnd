using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISocialMediaDal : IRepository<SocialMedia>
    {
        Task<List<SocialMedia>> GetSocialMediasByCountAsync(int skipCount, int takeCount);
    }
}
