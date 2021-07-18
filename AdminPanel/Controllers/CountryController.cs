using DataAccess.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class CountryController : Controller
    {
        private readonly IRepository<Country> _repository;
        private readonly IRepository<Language> _languageRepository;

        public CountryController(IRepository<Country> repository, IRepository<Language> languageRepository)
        {
            _repository = repository;
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allCountries = await _repository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.PageCount = Decimal.Ceiling((decimal)allCountries.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            var countries = await _repository.GetAll(x => x.IsDeleted == false, null)
                .OrderByDescending(x => x.Id).Skip((page - 1) * 5).Take(5).ToListAsync();
            if (countries == null)
                return NotFound();

            return View(countries);
        }

        #region Create

        public async Task<IActionResult> Create()
        {
            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country, int? languageId)
        {
            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(country);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            country.LanguageId = languageId.Value;

            await _repository.CreateAsync(country);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            var country = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (country == null)
                return NotFound();

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Country country, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(country);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            await _repository.UpdateAsync(country);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Language)
            };

            var country = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (country == null)
                return NotFound();

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var country = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (country == null)
                return NotFound();

            country.IsDeleted = true;

            await _repository.UpdateAsync(country);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Language)
            };

            var country = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (country == null)
                return NotFound();

            return View(country);
        }

        #endregion
    }
}
