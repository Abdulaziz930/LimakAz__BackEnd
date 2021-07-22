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
    public class CertifcateContentController : Controller
    {
        private readonly IRepository<CertifcateContent> _repository;

        public CertifcateContentController(IRepository<CertifcateContent> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var certifcateContents = await _repository.GetAll(x => x.IsDeleted == false, null)
                .OrderByDescending(x => x.Id).ToListAsync();

            return View(certifcateContents);
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CertifcateContent certifcateContent)
        {
            if (certifcateContent.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo field cannot be empty");
                return View();
            }

            if (!certifcateContent.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not a picture");
                return View();
            }

            if (!certifcateContent.Photo.IsSizeAllowed(3000))
            {
                ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                return View();
            }

            var fileName = await FileUtil.GenerateFileAsync(Constants.ImageFolderPath, certifcateContent.Photo);

            certifcateContent.Image = fileName;

            if (!ModelState.IsValid)
            {
                return View(certifcateContent);
            }

            await _repository.CreateAsync(certifcateContent);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();

            var certifcateContent = await _repository.GetAsync(x => x.Id == id.Value && x.IsDeleted == false, null);
            if (certifcateContent == null)
                return NotFound();

            return View(certifcateContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CertifcateContent certifcateContent)
        {
            if (id == null)
                return BadRequest();

            if (id != certifcateContent.Id)
                return BadRequest();

            var dbCertifcateContent = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, null);
            if (dbCertifcateContent == null)
                return NotFound();

            var fileName = dbCertifcateContent.Image;

            if (certifcateContent.Photo != null)
            {
                if (!certifcateContent.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not a picture");
                    return View();
                }

                if (!certifcateContent.Photo.IsSizeAllowed(3000))
                {
                    ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                    return View();
                }

                var path = Path.Combine(Constants.ImageFolderPath, dbCertifcateContent.Image);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                fileName = await FileUtil.GenerateFileAsync(Constants.ImageFolderPath, certifcateContent.Photo);
            }

            if (!ModelState.IsValid)
            {
                return View(dbCertifcateContent);
            }

            dbCertifcateContent.Image = fileName;

            await _repository.UpdateAsync(dbCertifcateContent);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var certifcateContent = await _repository.GetAsync(x => x.IsDeleted == false && x.Id == id, null);
            if (certifcateContent == null)
                return NotFound();

            return View(certifcateContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAdvertisements(int? id)
        {
            if (id == null)
                return BadRequest();

            var certifcateContent = await _repository.GetAsync(x => x.IsDeleted == false && x.Id == id, null);
            if (certifcateContent == null)
                return NotFound();

            certifcateContent.IsDeleted = true;
            await _repository.UpdateAsync(certifcateContent);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var certifcateContent = await _repository.GetAsync(x => x.IsDeleted == false && x.Id == id, null);
            if (certifcateContent == null)
                return NotFound();

            return View(certifcateContent);
        }

        #endregion
    }
}
