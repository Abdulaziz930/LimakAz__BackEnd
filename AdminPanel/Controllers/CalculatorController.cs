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
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILanguageService _languageService;

        public CalculatorController(ICalculatorService calculatorService, ILanguageService languageService)
        {
            _calculatorService = calculatorService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allCalculators = await _calculatorService.GetAllCalculatorContentsAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allCalculators.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var calculators = await _calculatorService.GetAllCalculatorContentsAsync(skipCount,5);
            if (calculators == null)
                return NotFound();

            return View(calculators);
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
        public async Task<IActionResult> Create(Calculator calculator, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(calculator);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            calculator.LanguageId = languageId.Value;

            await _calculatorService.AddAsync(calculator);

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

            var calculator = await _calculatorService.GetCalculatorAsync(id.Value);
            if (calculator == null)
                return NotFound();

            return View(calculator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Calculator calculator, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(calculator);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            await _calculatorService.UpdateAsync(calculator);

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

            var calculator = await _calculatorService.GetCalculatorWithLanguageAsync(id.Value);
            if (calculator == null)
                return NotFound();

            return View(calculator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var calculator = await _calculatorService.GetCalculatorAsync(id.Value);
            if (calculator == null)
                return NotFound();

            calculator.IsDeleted = true;

            await _calculatorService.UpdateAsync(calculator);

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

            var calculator = await _calculatorService.GetCalculatorWithLanguageAsync(id.Value);
            if (calculator == null)
                return NotFound();

            return View(calculator);
        }

        #endregion
    }
}
