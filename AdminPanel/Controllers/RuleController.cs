using Buisness.Abstract;
using DataAccess.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class RuleController : Controller
    {
        private readonly IRuleService _ruleService;
        private readonly ILanguageService _languageService;

        public RuleController(IRuleService ruleService, ILanguageService languageService)
        {
            _ruleService = ruleService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allRules = await _ruleService.GetAllRulesAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allRules.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var rules = await _ruleService.GetAllRulesAsync(skipCount, 5);

            return View(rules);
        }

        #region Create

        public async Task<IActionResult> Create()
        {
            var languages = await _languageService.GetAllLanguagesAsync(x => x.IsDeleted == false);
            ViewBag.Languages = languages;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rule rule, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(rule);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            rule.CreationDate = DateTime.Now;
            rule.LastModificationDate = DateTime.Now;

            rule.LanguageId = languageId.Value;

            await _ruleService.AddAsync(rule);

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

            var rule = await _ruleService.GetRuleWithLanguageAsync(id.Value);
            if (rule == null)
                return NotFound();

            return View(rule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Rule rule, int? languageId)
        {
            if (id == null)
                return BadRequest();

            if (id != rule.Id)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            var dbRule = await _ruleService.GetRuleWithLanguageAsync(id.Value);
            if (dbRule == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbRule);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View(dbRule);
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            dbRule.Title = rule.Title;
            dbRule.Content = rule.Content;
            dbRule.LanguageId = languageId.Value;
            dbRule.LastModificationDate = DateTime.Now;

            await _ruleService.UpdateAsync(dbRule);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var rule = await _ruleService.GetRuleWithLanguageAsync(id.Value);
            if (rule == null)
                return NotFound();

            return View(rule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRule(int? id)
        {
            if (id == null)
                return BadRequest();

            var rule = await _ruleService.GetRuleAsync(id.Value);
            if (rule == null)
                return NotFound();

            rule.IsDeleted = true;

            await _ruleService.UpdateAsync(rule);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var rule = await _ruleService.GetRuleWithLanguageAsync(id.Value);
            if (rule == null)
                return NotFound();

            return View(rule);
        }

        #endregion
    }
}
