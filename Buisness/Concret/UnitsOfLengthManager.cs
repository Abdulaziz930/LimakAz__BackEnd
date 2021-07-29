using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class UnitsOfLengthManager : IUnitsOfLengthService
    {
        private readonly IUnitsOfLengthDal _unitsOfLengthDal;

        public UnitsOfLengthManager(IUnitsOfLengthDal unitsOfLengthDal)
        {
            _unitsOfLengthDal = unitsOfLengthDal;
        }

        public async Task<bool> AddAsync(UnitsOfLength unitsOfLength)
        {
            await _unitsOfLengthDal.AddAsync(unitsOfLength);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitsOfLengthDal.DeleteAsync(new UnitsOfLength { Id = id });

            return true;
        }

        public async Task<List<UnitsOfLength>> GetAllUnitsOfLengthAsync()
        {
            return await _unitsOfLengthDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<UnitsOfLength>> GetAllUnitsOfLengthAsync(string languageCode)
        {
            return await _unitsOfLengthDal.GetAllMultiLanguageUnitsOfLengthAsync(languageCode);
        }

        public async Task<List<UnitsOfLength>> GetAllUnitsOfLengthAsync(int skipCount, int takeCount)
        {
            return await _unitsOfLengthDal.GetUnitsOfLengthByCountAsync(skipCount, takeCount);
        }

        public async Task<UnitsOfLength> GetUnitsOfLengthAsync(int id)
        {
            return await _unitsOfLengthDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<UnitsOfLength> GetUnitsOfLengthWithLanguageAsync(int id)
        {
            return await _unitsOfLengthDal.GetUnitsOfLengthWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(UnitsOfLength unitsOfLength)
        {
            await _unitsOfLengthDal.UpdateAsync(unitsOfLength);

            return true;
        }
    }
}
