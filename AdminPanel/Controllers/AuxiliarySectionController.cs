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
    public class AuxiliarySectionController : Controller
    {
        private readonly IRepository<AuxiliarySection> _repository;
        private readonly IRepository<Language> _languageRepository;

        public AuxiliarySectionController(IRepository<AuxiliarySection> repository, IRepository<Language> languageRepository)
        {
            _repository = repository;
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allSections = await _repository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.PageCount = Decimal.Ceiling((decimal)allSections.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            var sections = await _repository.GetAll(x => x.IsDeleted == false, null)
                .OrderByDescending(x => x.Id).Skip((page - 1) * 5).Take(5).ToListAsync();
            if (sections == null)
                return NotFound();

            return View(sections);
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
        public async Task<IActionResult> Create(AuxiliarySection section, int? languageId)
        {
            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(section);
            }

            var isExist = await _repository.GetAllAsync(x => x.Name == section.Name && x.IsDeleted == false && x.LanguageId == languageId);
            if (isExist)
            {
                ModelState.AddModelError("", "There is a Auxiliary Section with this name");
                return View();
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            section.LanguageId = languageId.Value;

            await _repository.CreateAsync(section);

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

            var section = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (section == null)
                return NotFound();

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, AuxiliarySection section, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(section);
            }

            var isExist = await _repository.GetAllAsync(x => x.Name == section.Name && x.IsDeleted == false && x.LanguageId == languageId && x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("", "There is a Auxiliary Section with this name");
                return View();
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            var dbSection = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (dbSection == null)
                return NotFound();

            dbSection.LanguageId = languageId.Value;
            dbSection.Name = section.Name;
            dbSection.Url = section.Url;

            await _repository.UpdateAsync(dbSection);

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

            var section = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (section == null)
                return NotFound();

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var section = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (section == null)
                return NotFound();

            section.IsDeleted = true;

            await _repository.UpdateAsync(section);

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

            var section = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (section == null)
                return NotFound();

            return View(section);
        }

        #endregion
    }
}
