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
    public class UnitsOfLengthController : Controller
    {
        private readonly IUnitsOfLengthService _unitsOfLengthService;
        private readonly ILanguageService _languageService;

        public UnitsOfLengthController(IUnitsOfLengthService unitsOfLengthService, ILanguageService languageService)
        {
            _unitsOfLengthService = unitsOfLengthService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allUnitsOfLengths = await _unitsOfLengthService.GetAllUnitsOfLengthAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allUnitsOfLengths.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var unitsOfLengths = await _unitsOfLengthService.GetAllUnitsOfLengthAsync(skipCount,5);
            if (unitsOfLengths == null)
                return NotFound();

            return View(unitsOfLengths);
        }

        #region Create

        public async Task<IActionResult> Create()
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitsOfLength unitsOfLength, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
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

            await _unitsOfLengthService.AddAsync(unitsOfLength);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            var unitsOfLength = await _unitsOfLengthService.GetUnitsOfLengthAsync(id.Value);
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

            var languages = await _languageService.GetAllLanguagesAsync();
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

            await _unitsOfLengthService.UpdateAsync(unitsOfLength);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var unitsOfLength = await _unitsOfLengthService.GetUnitsOfLengthWithLanguageAsync(id.Value);
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

            var unitsOfLength = await _unitsOfLengthService.GetUnitsOfLengthAsync(id.Value);
            if (unitsOfLength == null)
                return NotFound();

            unitsOfLength.IsDeleted = true;

            await _unitsOfLengthService.UpdateAsync(unitsOfLength);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var unitsOfLength = await _unitsOfLengthService.GetUnitsOfLengthWithLanguageAsync(id.Value);
            if (unitsOfLength == null)
                return NotFound();

            return View(unitsOfLength);
        }

        #endregion
    }
}
