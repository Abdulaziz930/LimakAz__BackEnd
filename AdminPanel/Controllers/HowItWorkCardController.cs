using DataAccess.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace AdminPanel.Controllers
{
    public class HowItWorkCardController : Controller
    {
        private readonly IRepository<HowItWorkCard> _repository;
        private readonly IRepository<Language> _languageRepository;

        public HowItWorkCardController(IRepository<HowItWorkCard> repository, IRepository<Language> languageRepository)
        {
            _repository = repository;
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allHowItWorkCards = await _repository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.PageCount = Decimal.Ceiling((decimal)allHowItWorkCards.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            var howItWorkCards = await _repository.GetAll(x => x.IsDeleted == false, null)
                .OrderByDescending(x => x.Id).Skip((page - 1) * 5).Take(5).ToListAsync();
            if (howItWorkCards == null)
                return NotFound();

            return View(howItWorkCards);
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
        public async Task<IActionResult> Create(HowItWorkCard howItWorkCard, int? languageId)
        {
            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (howItWorkCard.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo field cannot be empty");
                return View();
            }

            if (!howItWorkCard.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not a picture");
                return View();
            }

            if (!howItWorkCard.Photo.IsSizeAllowed(3000))
            {
                ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                return View();
            }

            var fileName = await FileUtil.GenerateFileAsync(Constants.ImageFolderPath, howItWorkCard.Photo);

            howItWorkCard.Image = fileName;

            if (!ModelState.IsValid)
            {
                return View(howItWorkCard);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            howItWorkCard.LanguageId = languageId.Value;

            await _repository.CreateAsync(howItWorkCard);

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

            var howItWorkCard = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (howItWorkCard == null)
                return NotFound();

            return View(howItWorkCard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, HowItWorkCard howItWorkCard, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            var dbHowItWorkCard = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (dbHowItWorkCard == null)
                return NotFound();

            var fileName = dbHowItWorkCard.Image;

            if (howItWorkCard.Photo != null)
            {
                if (!howItWorkCard.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not a picture");
                    return View();
                }

                if (!howItWorkCard.Photo.IsSizeAllowed(3000))
                {
                    ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                    return View();
                }

                var path = Path.Combine(Constants.ImageFolderPath, dbHowItWorkCard.Image);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                fileName = await FileUtil.GenerateFileAsync(Constants.ImageFolderPath, howItWorkCard.Photo);
            }

            if (!ModelState.IsValid)
            {
                return View(howItWorkCard);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            howItWorkCard.Image = fileName;

            await _repository.UpdateAsync(howItWorkCard);

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

            var howItWorkCard = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (howItWorkCard == null)
                return NotFound();

            return View(howItWorkCard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var howItWorkCard = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (howItWorkCard == null)
                return NotFound();

            howItWorkCard.IsDeleted = true;

            await _repository.UpdateAsync(howItWorkCard);

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

            var howItWorkCard = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (howItWorkCard == null)
                return NotFound();

            return View(howItWorkCard);
        }

        #endregion
    }
}
