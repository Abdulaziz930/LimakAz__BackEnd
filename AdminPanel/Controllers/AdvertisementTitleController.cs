using Buisness.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class AdvertisementTitleController : Controller
    {
        private readonly IAdvertisementTitleService _advertisementTitleService;
        private readonly ILanguageService _languageService;

        public AdvertisementTitleController(IAdvertisementTitleService advertisementTitleService, ILanguageService languageService)
        {
            _advertisementTitleService = advertisementTitleService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allCities = await _advertisementTitleService.GetAllAdvertisementTitlesAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allCities.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var advertisimentTitles = await _advertisementTitleService.GetAllAdvertisementTitlesAsync(skipCount,5);
            if (advertisimentTitles == null)
                return NotFound();

            return View(advertisimentTitles);
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
        public async Task<IActionResult> Create(AdvertisimentTitle advertisimentTitle, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(advertisimentTitle);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            advertisimentTitle.LanguageId = languageId.Value;

            await _advertisementTitleService.AddAsync(advertisimentTitle);

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

            var advertisimentTitle = await _advertisementTitleService.GetAdvertisementTitleAsync(id.Value);
            if (advertisimentTitle == null)
                return NotFound();

            return View(advertisimentTitle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, AdvertisimentTitle advertisimentTitle, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(advertisimentTitle);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            await _advertisementTitleService.UpdateAsync(advertisimentTitle);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var advertisimentTitle = await _advertisementTitleService.GetAdvertisementTitleAsync(id.Value);
            if (advertisimentTitle == null)
                return NotFound();

            return View(advertisimentTitle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var advertisimentTitle = await _advertisementTitleService.GetAdvertisementTitleAsync(id.Value);
            if (advertisimentTitle == null)
                return NotFound();

            advertisimentTitle.IsDeleted = true;

            await _advertisementTitleService.UpdateAsync(advertisimentTitle);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var advertisimentTitle = await _advertisementTitleService.GetAdvertisementTitleAsync(id.Value);
            if (advertisimentTitle == null)
                return NotFound();

            return View(advertisimentTitle);
        }

        #endregion
    }
}
