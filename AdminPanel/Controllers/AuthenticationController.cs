using DataAccess.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRepository<Authentication> _repository;
        private readonly IRepository<Language> _languageRepository;

        public AuthenticationController(IRepository<Authentication> repository, IRepository<Language> languageRepository)
        {
            _repository = repository;
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allAuthentications = await _repository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.PageCount = Decimal.Ceiling((decimal)allAuthentications.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            var authentications = await _repository.GetAll(x => x.IsDeleted == false, null)
                .OrderByDescending(x => x.Id).Skip((page - 1) * 5).Take(5).ToListAsync();
            if (authentications == null)
                return NotFound();

            return View(authentications);
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
        public async Task<IActionResult> Create(Authentication authentication, int? languageId)
        {
            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(authentication);
            }

            var isExist = await _repository.GetAllAsync(x => x.Name == authentication.Name && x.IsDeleted == false && x.LanguageId == languageId);
            if (isExist)
            {
                ModelState.AddModelError("", "There is a Section with this name");
                return View();
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            authentication.LanguageId = languageId.Value;

            await _repository.CreateAsync(authentication);

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

            var authentication = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (authentication == null)
                return NotFound();

            return View(authentication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Authentication authentication, int? languageId)
        {
            if (id == null)
                return BadRequest();

            var languages = await _languageRepository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.Languages = languages;

            if (!ModelState.IsValid)
            {
                return View(authentication);
            }

            var isExist = await _repository.GetAllAsync(x => x.Name == authentication.Name && x.IsDeleted == false && x.LanguageId == languageId && x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("", "There is a Section with this name");
                return View();
            }

            if (languageId == null)
            {
                ModelState.AddModelError("", "Please select language.");
                return View();
            }

            if (languages.All(x => x.Id != languageId.Value))
                return BadRequest();

            var dbAuthentication = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (dbAuthentication == null)
                return NotFound();

            dbAuthentication.LanguageId = languageId.Value;
            dbAuthentication.Name = authentication.Name;
            dbAuthentication.Url = authentication.Url;

            await _repository.UpdateAsync(dbAuthentication);

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

            var authentication = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (authentication == null)
                return NotFound();

            return View(authentication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var authentication = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (authentication == null)
                return NotFound();

            authentication.IsDeleted = true;

            await _repository.UpdateAsync(authentication);

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

            var authentication = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (authentication == null)
                return NotFound();

            return View(authentication);
        }

        #endregion
    }
}
