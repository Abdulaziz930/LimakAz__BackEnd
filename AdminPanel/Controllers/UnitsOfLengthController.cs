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
    public class UnitsOfLengthController : Controller
    {
        private readonly IRepository<UnitsOfLength> _repository;
        private readonly IRepository<Language> _languageRepository;

        public UnitsOfLengthController(IRepository<UnitsOfLength> repository, IRepository<Language> languageRepository)
        {
            _repository = repository;
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allUnitsOfLengths = await _repository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.PageCount = Decimal.Ceiling((decimal)allUnitsOfLengths.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            var unitsOfLengths = await _repository.GetAll(x => x.IsDeleted == false, null)
                .OrderByDescending(x => x.Id).Skip((page - 1) * 5).Take(5).ToListAsync();
            if (unitsOfLengths == null)
                return NotFound();

            return View(unitsOfLengths);
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
        public async Task<IActionResult> Create(UnitsOfLength unitsOfLength, int? languageId)
        {
            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(unitsOfLength);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            unitsOfLength.LanguageId = languageId.Value;

            await _repository.CreateAsync(unitsOfLength);

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

            var unitsOfLength = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (unitsOfLength == null)
                return NotFound();

            return View(unitsOfLength);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, UnitsOfLength unitsOfLength, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(unitsOfLength);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            await _repository.UpdateAsync(unitsOfLength);

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

            var unitsOfLength = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (unitsOfLength == null)
                return NotFound();

            return View(unitsOfLength);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var unitsOfLength = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (unitsOfLength == null)
                return NotFound();

            unitsOfLength.IsDeleted = true;

            await _repository.UpdateAsync(unitsOfLength);

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

            var unitsOfLength = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (unitsOfLength == null)
                return NotFound();

            return View(unitsOfLength);
        }

        #endregion
    }
}
