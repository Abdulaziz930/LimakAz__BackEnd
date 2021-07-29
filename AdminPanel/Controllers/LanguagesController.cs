using Buisness.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allLanguages = await _languageService.GetAllLanguagesAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allLanguages.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var languages = await _languageService.GetAllLanguagesAsync(skipCount,5);

            return View(languages);
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Language language)
        {
            if (!ModelState.IsValid)
            {
                return View(language);
            }

            var isExist = await _languageService.LanguagesAnyAsync(x => (x.Name == language.Name || x.Code == language.Code) 
                                                                    && x.IsDeleted == false);
            if (isExist)
            {
                ModelState.AddModelError("", "There is a language with this name or code");
                return View();
            }

            await _languageService.AddAsync(language);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();

            var language = await _languageService.GetLanguageAsync(id.Value);
            if (language == null)
                return NotFound();

            return View(language);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,Language language)
        {
            if (id == null)
                return BadRequest();

            if (id != language.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(language);
            }

            var isExist = await _languageService.LanguagesAnyAsync(x => (x.Name == language.Name || x.Code == language.Code)
                                                                    && x.IsDeleted == false && x.Id != language.Id);
            if (isExist)
            {
                ModelState.AddModelError("", "There is a language with this name or code");
                return View();
            }

            var dbLanguage = await _languageService.GetLanguageAsync(id.Value);
            if (dbLanguage == null)
                return NotFound();

            dbLanguage.Name = language.Name;
            dbLanguage.Code = language.Code;

            await _languageService.UpdateAsync(dbLanguage);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var language = await _languageService.GetLanguageAsync(id.Value);
            if (language == null)
                return NotFound();

            return View(language);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteLanguage(int? id)
        {
            if (id == null)
                return BadRequest();

            var language = await _languageService.GetLanguageAsync(id.Value);
            if (language == null)
                return NotFound();

            language.IsDeleted = true;

            await _languageService.UpdateAsync(language);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var language = await _languageService.GetLanguageAsync(id.Value);
            if (language == null)
                return NotFound();

            return View(language);
        }

        #endregion
    }
}
