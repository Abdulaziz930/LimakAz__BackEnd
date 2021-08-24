using Buisness.Abstract;
using DataAccess.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace AdminPanel.Controllers
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class PrivacyController : Controller
    {
        private readonly IPrivacyService _privacyService;
        private readonly ILanguageService _languageService;

        public PrivacyController(IPrivacyService privacyService, ILanguageService languageService)
        {
            _privacyService = privacyService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allPrivacies = await _privacyService.GetAllPrivaciesAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allPrivacies.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var abouts = await _privacyService.GetAllPrivaciesAsync(skipCount, 5);

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
        public async Task<IActionResult> Create(Privacy privacy, int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (privacy.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo field cannot be empty");
                return View();
            }

            if (!privacy.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not a picture");
                return View();
            }

            if (!privacy.Photo.IsSizeAllowed(3000))
            {
                ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                return View();
            }

            var folderList = new List<string>
            {
                Constants.ImageFolderPath,
                @"D:\Programming\CodeAcademy\FrontEnd\FinalProject\limak-az--front-end\public\images"
            };

            var fileName = await FileUtil.GenerateFileAsync(folderList, privacy.Photo);

            privacy.Image = fileName;

            if (!ModelState.IsValid)
            {
                return View(privacy);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            privacy.LanguageId = languageId.Value;

            await _privacyService.AddAsync(privacy);

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

            var privacy = await _privacyService.GetPrivacyWithLanguageAsync(id.Value);
            if (privacy == null)
                return NotFound();

            return View(privacy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Privacy privacy, int? languageId)
        {
            if (id == null)
                return BadRequest();

            if (id != privacy.Id)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            var dbPrivacy = await _privacyService.GetPrivacyWithLanguageAsync(id.Value);
            if (dbPrivacy == null)
                return NotFound();

            var fileName = dbPrivacy.Image;

            if (privacy.Photo != null)
            {
                if (!privacy.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not a picture");
                    return View();
                }

                if (!privacy.Photo.IsSizeAllowed(3000))
                {
                    ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                    return View();
                }

                var path = Path.Combine(Constants.ImageFolderPath, dbPrivacy.Image);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                fileName = await FileUtil.GenerateFileAsync(Constants.ImageFolderPath, privacy.Photo);
            }

            if (!ModelState.IsValid)
            {
                return View(privacy);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            dbPrivacy.Description = privacy.Description;
            dbPrivacy.Image = fileName;
            dbPrivacy.PrivacyTitle = privacy.PrivacyTitle;
            dbPrivacy.LanguageId = languageId.Value;

            await _privacyService.UpdateAsync(dbPrivacy);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var about = await _privacyService.GetPrivacyWithLanguageAsync(id.Value);
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

            var privacy = await _privacyService.GetPrivacyAsync(id.Value);
            if (privacy == null)
                return NotFound();

            privacy.IsDeleted = true;
            await _privacyService.UpdateAsync(privacy);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var privacy = await _privacyService.GetPrivacyWithLanguageAsync(id.Value);
            if (privacy == null)
                return NotFound();

            return View(privacy);
        }

        #endregion
    }
}
