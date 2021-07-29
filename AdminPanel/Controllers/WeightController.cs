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
    public class WeightController : Controller
    {
        private readonly IWeightService _weightService;
        private readonly ILanguageService _languageService;

        public WeightController(IWeightService weightService, ILanguageService languageService)
        {
            _weightService = weightService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allWeights = await _weightService.GetAllWeightsAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allWeights.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var weights = await _weightService.GetAllWeightsAsync(skipCount,5);
            if (weights == null)
                return NotFound();

            return View(weights);
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
        public async Task<IActionResult> Create(Weight weight, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(weight);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            weight.LanguageId = languageId.Value;

            await _weightService.AddAsync(weight);

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

            var weight = await _weightService.GetWeightAsync(id.Value);
            if (weight == null)
                return NotFound();

            return View(weight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Weight weight, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(weight);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            await _weightService.UpdateAsync(weight);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var weight = await _weightService.GetWeightWithLanguageAsync(id.Value);
            if (weight == null)
                return NotFound();

            return View(weight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var weight = await _weightService.GetWeightAsync(id.Value);
            if (weight == null)
                return NotFound();

            weight.IsDeleted = true;

            await _weightService.UpdateAsync(weight);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var weight = await _weightService.GetWeightWithLanguageAsync(id.Value);
            if (weight == null)
                return NotFound();

            return View(weight);
        }

        #endregion
    }
}
