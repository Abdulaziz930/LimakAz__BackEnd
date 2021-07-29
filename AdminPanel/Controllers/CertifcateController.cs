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
    public class CertifcateController : Controller
    {
        private readonly ICertificateService _certicateService;
        private readonly ILanguageService _languageService;

        public CertifcateController(ICertificateService certificateService, ILanguageService languageService)
        {
            _certicateService = certificateService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allCertifcates = await _certicateService.GetAllCertificateContentsAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allCertifcates.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var certifcates = await _certicateService.GetAllCertificateContentsAsync(skipCount,5);

            return View(certifcates);
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
        public async Task<IActionResult> Create(Certificate certificate,int? languageId)
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(certificate);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            certificate.LanguageId = languageId.Value;

            await _certicateService.AddAsync(certificate);

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

            var certifcateContent = await _certicateService.GetCertificateAsync(id.Value);
            if (certifcateContent == null)
                return NotFound();

            return View(certifcateContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Certificate certificate, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageService.GetAllLanguagesAsync();
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(certificate);
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            await _certicateService.UpdateAsync(certificate);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var certificate = await _certicateService.GetCertificateWithLanguageAsync(id.Value);
            if (certificate == null)
                return NotFound();

            return View(certificate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var certificate = await _certicateService.GetCertificateAsync(id.Value);
            if (certificate == null)
                return NotFound();

            certificate.IsDeleted = true;

            await _certicateService.UpdateAsync(certificate);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var certificate = await _certicateService.GetCertificateWithLanguageAsync(id.Value);
            if (certificate == null)
                return NotFound();

            return View(certificate);
        }

        #endregion
    }
}
