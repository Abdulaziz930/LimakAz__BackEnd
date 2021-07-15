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
    public class LanguagesController : Controller
    {
        private readonly IRepository<Language> _repository;

        public LanguagesController(IRepository<Language> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allLanguages = await _repository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.PageCount = Decimal.Ceiling((decimal)allLanguages.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            var languages = await _repository.GetAll(x => x.IsDeleted == false, null)
                .OrderByDescending(x => x.Id).Skip((page - 1) * 5).Take(5).ToListAsync();

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

            var isExist = await _repository.GetAllAsync(x => (x.Name == language.Name || x.Code == language.Code) && x.IsDeleted == false);
            if (isExist)
            {
                ModelState.AddModelError("", "There is a language with this name or code");
                return View();
            }

            await _repository.CreateAsync(language);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();

            var language = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false,null);
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

            var isExist = await _repository.GetAllAsync(x => (x.Name == language.Name || x.Code == language.Code) 
                                                        && x.IsDeleted == false && x.Id != language.Id);
            if (isExist)
            {
                ModelState.AddModelError("", "There is a language with this name or code");
                return View();
            }

            var dbLanguage = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (dbLanguage == null)
                return NotFound();

            dbLanguage.Name = language.Name;
            dbLanguage.Code = language.Code;

            await _repository.UpdateAsync(dbLanguage);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var language = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
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

            var language = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (language == null)
                return NotFound();

            language.IsDeleted = true;

            await _repository.UpdateAsync(language);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var language = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (language == null)
                return NotFound();

            return View(language);
        }

        #endregion
    }
}
