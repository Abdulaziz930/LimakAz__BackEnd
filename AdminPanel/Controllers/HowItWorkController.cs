using Buisness.Abstract;
using DataAccess.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class HowItWorkController : Controller
    {
        private readonly IHowItWorkService _howItWorkService;
        private readonly ILanguageService _languageService;

        public HowItWorkController(IHowItWorkService howItWorkService, ILanguageService languageService)
        {
            _howItWorkService = howItWorkService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allHowItWorks = await _howItWorkService.GetAllHowItWorksAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allHowItWorks.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var howItWorks = await _howItWorkService.GetAllHowItWorksAsync(skipCount,5);
            if (howItWorks == null)
                return NotFound();

            return View(howItWorks);
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
        public async Task<IActionResult> Create(HowItWork howItWorks, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(howItWorks);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            howItWorks.LanguageId = languageId.Value;

            await _howItWorkService.AddAsync(howItWorks);

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

            var howItWorks = await _howItWorkService.GetHowItWorkAsync(id.Value);
            if (howItWorks == null)
                return NotFound();

            return View(howItWorks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, HowItWork howItWorks, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(howItWorks);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            await _howItWorkService.UpdateAsync(howItWorks);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var howItWorks = await _howItWorkService.GetHowItWorkWithLanguageAsync(id.Value);
            if (howItWorks == null)
                return NotFound();

            return View(howItWorks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var howItWorks = await _howItWorkService.GetHowItWorkAsync(id.Value);
            if (howItWorks == null)
                return NotFound();

            howItWorks.IsDeleted = true;

            await _howItWorkService.UpdateAsync(howItWorks);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var howItWorks = await _howItWorkService.GetHowItWorkWithLanguageAsync(id.Value);
            if (howItWorks == null)
                return NotFound();

            return View(howItWorks);
        }

        #endregion
    }
}
