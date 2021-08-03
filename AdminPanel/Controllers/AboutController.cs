using Buisness.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace AdminPanel.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILanguageService _languageService;

        public AboutController(IAboutService aboutService, ILanguageService languageService)
        {
            _aboutService = aboutService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allAbouts = await _aboutService.GetAllAboutsAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allAbouts.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var abouts = await _aboutService.GetAllAboutsAsync(skipCount, 5);

            return View(abouts);
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
        public async Task<IActionResult> Create(About about, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (about.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo field cannot be empty");
                return View();
            }

            if (!about.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not a picture");
                return View();
            }

            if (!about.Photo.IsSizeAllowed(3000))
            {
                ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                return View();
            }

            var folderList = new List<string>
            {
                Constants.ImageFolderPath,
                @"D:\Programming\CodeAcademy\FrontEnd\FinalProject\limak-az--front-end\public\images"
            };

            var fileName = await FileUtil.GenerateFileAsync(folderList, about.Photo);

            about.Image = fileName;

            if (!ModelState.IsValid)
            {
                return View(about);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            about.LanguageId = languageId.Value;

            await _aboutService.AddAsync(about);

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

            var about = await _aboutService.GetAboutWithLanguageAsync(id.Value);
            if (about == null)
                return NotFound();

            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, About about, int? languageId)
        {
            if (id == null)
                return BadRequest();

            if (id != about.Id)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            var dbAbout = await _aboutService.GetAboutWithLanguageAsync(id.Value);
            if (dbAbout == null)
                return NotFound();

            var fileName = dbAbout.Image;

            if (about.Photo != null)
            {
                if (!about.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not a picture");
                    return View();
                }

                if (!about.Photo.IsSizeAllowed(3000))
                {
                    ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                    return View();
                }

                var path = Path.Combine(Constants.ImageFolderPath, dbAbout.Image);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                fileName = await FileUtil.GenerateFileAsync(Constants.ImageFolderPath, about.Photo);
            }

            if (!ModelState.IsValid)
            {
                return View(dbAbout);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            dbAbout.Description = about.Description;
            dbAbout.Image = fileName;
            dbAbout.AboutTitle = about.AboutTitle;
            dbAbout.LanguageId = languageId.Value;

            await _aboutService.UpdateAsync(dbAbout);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var about = await _aboutService.GetAboutWithLanguageAsync(id.Value);
            if (about == null)
                return NotFound();

            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAdvertisements(int? id)
        {
            if (id == null)
                return BadRequest();

            var about = await _aboutService.GetAboutAsync(id.Value);
            if (about == null)
                return NotFound();

            about.IsDeleted = true;
            await _aboutService.UpdateAsync(about);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var about = await _aboutService.GetAboutWithLanguageAsync(id.Value);
            if (about == null)
                return NotFound();

            return View(about);
        }

        #endregion
    }
}
