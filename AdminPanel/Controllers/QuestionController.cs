using Buisness.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ILanguageService _languageService;

        public QuestionController(IQuestionService questionService, ILanguageService languageService)
        {
            _questionService = questionService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allQuestions = await _questionService.GetAllQuestionsAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allQuestions.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var questions = await _questionService.GetAllQuestionsAsync(skipCount, 5);

            return View(questions);
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
        public async Task<IActionResult> Create(Question question, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(question);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            question.CreationDate = DateTime.Now;
            question.LastModificationDate = DateTime.Now;

            question.LanguageId = languageId.Value;

            await _questionService.AddAsync(question);

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

            var question = await _questionService.GetQuestionAsync(id.Value);
            if (question == null)
                return NotFound();

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Question question, int? languageId)
        {
            if (id == null)
                return BadRequest();

            if (id != question.Id)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            var dbQuestion = await _questionService.GetQuestionWithLanguageAsync(id.Value);
            if (dbQuestion == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbQuestion);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            dbQuestion.Title = question.Title;
            dbQuestion.Content = question.Content;
            dbQuestion.LanguageId = languageId.Value;
            dbQuestion.LastModificationDate = DateTime.Now;

            await _questionService.UpdateAsync(dbQuestion);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var question = await _questionService.GetQuestionWithLanguageAsync(id.Value);
            if (question == null)
                return NotFound();

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAdvertisements(int? id)
        {
            if (id == null)
                return BadRequest();

            var question = await _questionService.GetQuestionAsync(id.Value);
            if (question == null)
                return NotFound();

            question.IsDeleted = true;

            await _questionService.UpdateAsync(question);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var question = await _questionService.GetQuestionWithLanguageAsync(id.Value);
            if (question == null)
                return NotFound();

            return View(question);
        }

        #endregion
    }
}
