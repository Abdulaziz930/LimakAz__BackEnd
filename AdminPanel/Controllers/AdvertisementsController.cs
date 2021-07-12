using AutoMapper;
using DataAccess;
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
    public class AdvertisementsController : Controller
    {
        private readonly IRepository<Advertisement> _repository;

        public AdvertisementsController(IRepository<Advertisement> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allAdvertisements = await _repository.GetAllAsync(x => x.IsDeleted == false, null);
            ViewBag.PageCount = Decimal.Ceiling((decimal)allAdvertisements.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            var advertisements = await _repository.GetAll(x => x.IsDeleted == false, null)
                .OrderByDescending(x => x.LastModificationDate).Skip((page - 1) * 5).Take(5).ToListAsync();

            return View(advertisements);
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Advertisement advertisement)
        {
            if (advertisement.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo field cannot be empty");
                return View();
            }

            if (!advertisement.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not a picture");
                return View();
            }

            if (!advertisement.Photo.IsSizeAllowed(3000))
            {
                ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                return View();
            }

            var fileName = await FileUtil.GenerateFileAsync(Constants.ImageFolderPath, advertisement.Photo);

            advertisement.Image = fileName;

            if (!ModelState.IsValid)
            {
                return View(advertisement);
            }

            advertisement.CreationDate = DateTime.Now;
            advertisement.LastModificationDate = DateTime.Now;

            await _repository.CreateAsync(advertisement,advertisement.AdvertisementDetail);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Advertisement.AdvertisementDetail)
            };

            var advertisement = await _repository.GetAsync(x => x.Id == id.Value && x.IsDeleted == false,includedProperties);
            if (advertisement == null)
                return NotFound();

            return View(advertisement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,Advertisement advertisement)
        {
            if (id == null)
                return BadRequest();

            if (id != advertisement.Id)
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Advertisement.AdvertisementDetail)
            };

            var dbAdvertisement = await _repository.GetAsync(x => x.Id == id && x.IsDeleted == false, includedProperties);
            if (dbAdvertisement == null)
                return NotFound();

            var fileName = dbAdvertisement.Image;

            if (advertisement.Photo != null)
            {
                if (!advertisement.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not a picture");
                    return View();
                }

                if (!advertisement.Photo.IsSizeAllowed(3000))
                {
                    ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                    return View();
                }

                var path = Path.Combine(Constants.ImageFolderPath, dbAdvertisement.Image);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                fileName = await FileUtil.GenerateFileAsync(Constants.ImageFolderPath, advertisement.Photo);
            }

            if (!ModelState.IsValid)
            {
                return View(dbAdvertisement);
            }

            dbAdvertisement.Title = advertisement.Title;
            dbAdvertisement.Image = fileName;
            dbAdvertisement.AdvertisementDetail.Description = advertisement.AdvertisementDetail.Description;
            dbAdvertisement.LastModificationDate = DateTime.Now;

            await _repository.UpdateAsync(dbAdvertisement);

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
                nameof(Advertisement.AdvertisementDetail)
            };

            var advertisements = await _repository.GetAsync(x => x.IsDeleted == false && x.Id == id, includedProperties);
            if (advertisements == null)
                return NotFound();

            return View(advertisements);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAdvertisements(int? id)
        {
            if (id == null)
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Advertisement.AdvertisementDetail)
            };

            var advertisements = await _repository.GetAsync(x => x.IsDeleted == false && x.Id == id, includedProperties);
            if (advertisements == null)
                return NotFound();

            advertisements.IsDeleted = true;
            advertisements.AdvertisementDetail.IsDeleted = true;
            await _repository.UpdateAsync(advertisements);

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
                nameof(Advertisement.AdvertisementDetail)
            };

            var advertisements = await _repository.GetAsync(x => x.IsDeleted == false && x.Id == id, includedProperties);
            if (advertisements == null)
                return NotFound();

            return View(advertisements);
        }

        #endregion
    }
}
