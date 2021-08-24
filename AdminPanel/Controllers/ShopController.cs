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
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        private readonly ICountryService _countryService;

        public ShopController(IShopService shopService, ICountryService countryService)
        {
            _shopService = shopService;
            _countryService = countryService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allShops = await _shopService.GetAllShopsAsync();
            ViewBag.PageCount = Decimal.Ceiling((decimal)allShops.Count / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var shops = await _shopService.GetAllShopsAsync(skipCount, 5);

            return View(shops);
        }

        #region Create

        public async Task<IActionResult> Create()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            ViewBag.Countries = countries;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shop shop, int[] countryId, bool isRecommended)
        {
            var countries = await _countryService.GetAllCountriesAsync();
            ViewBag.Countries = countries;

            if (shop.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo field cannot be empty");
                return View();
            }

            if (!shop.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not a picture");
                return View();
            }

            if (!shop.Photo.IsSizeAllowed(3000))
            {
                ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                return View();
            }

            var folderList = new List<string>
            {
                Constants.ImageFolderPath,
                @"D:\Programming\CodeAcademy\FrontEnd\FinalProject\limak-az--front-end\public\images"
            };

            var fileName = await FileUtil.GenerateFileAsync(folderList, shop.Photo);

            shop.Image = fileName;

            if (!ModelState.IsValid)
            {
                return View(shop);
            }

            if (countryId.Length == 0 || countryId == null)
            {
                ModelState.AddModelError("", "Please select country.");
                return View();
            }

            foreach (var item in countryId)
            {
                if (countries.All(x => x.Id != (int)item))
                    return BadRequest();
            }

            var shopCountryList = new List<ShopCountry>();
            foreach (var item in countryId)
            {
                var shopCountry = new ShopCountry
                {
                    CountryId = (int)item,
                    ShopId = shop.Id
                };
                shopCountryList.Add(shopCountry);
            }
            shop.ShopCountries = shopCountryList;

            shop.IsRecommended = isRecommended;
            shop.CreationDate = DateTime.Now;
            shop.LastModificationDate = DateTime.Now;

            await _shopService.AddAsync(shop);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();

            var countries = await _countryService.GetAllCountriesAsync();
            ViewBag.Countries = countries;

            var shop = await _shopService.GetShopAsync(id.Value);
            if (shop == null)
                return NotFound();

            return View(shop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Shop shop, int[] countryId, bool isRecommended)
        {
            if (id == null)
                return BadRequest();

            if (id != shop.Id)
                return BadRequest();

            var countries = await _countryService.GetAllCountriesAsync();
            ViewBag.Countries = countries;

            var dbShop = await _shopService.GetShopAsync(id.Value);
            if (dbShop == null)
                return NotFound();

            var fileName = dbShop.Image;

            if (shop.Photo != null)
            {
                if (!shop.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not a picture");
                    return View();
                }

                if (!shop.Photo.IsSizeAllowed(3000))
                {
                    ModelState.AddModelError("Photo", "The size of the image you uploaded is 3 MB higher.");
                    return View();
                }

                var folderList = new List<string>
                {
                    Path.Combine(Constants.ImageFolderPath, dbShop.Image),
                    @"D:\Programming\CodeAcademy\FrontEnd\FinalProject\limak-az--front-end\public\images\" + dbShop.Image
                };

                var secondFolderList = new List<string>
                {
                    Constants.ImageFolderPath,
                    @"D:\Programming\CodeAcademy\FrontEnd\FinalProject\limak-az--front-end\public\images"
                };

                fileName = await FileUtil.UpdateFileAsync(folderList, secondFolderList, shop.Photo);
            }

            if (!ModelState.IsValid)
            {
                return View(dbShop);
            }

            if (countryId.Length == 0 || countryId == null)
            {
                ModelState.AddModelError("", "Please select country.");
                return View();
            }

            foreach (var item in countryId)
            {
                if (countries.All(x => x.Id != (int)item))
                    return BadRequest();
            }

            var shopCountries = new List<ShopCountry>();
            foreach (var item in countryId)
            {
                var shopCountry = new ShopCountry();
                shopCountry.CountryId = (int)item;
                shopCountry.ShopId = shop.Id;
                shopCountries.Add(shopCountry);
            }
            dbShop.ShopCountries = shopCountries;
            dbShop.Title = shop.Title;
            dbShop.Url = shop.Url;
            dbShop.IsRecommended = isRecommended;
            dbShop.Image = fileName;
            dbShop.LastModificationDate = DateTime.Now;

            await _shopService.UpdateAsync(dbShop);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var shop = await _shopService.GetShopAsync(id.Value);
            if (shop == null)
                return NotFound();

            return View(shop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAdvertisements(int? id)
        {
            if (id == null)
                return BadRequest();

            var shop = await _shopService.GetShopAsync(id.Value);
            if (shop == null)
                return NotFound();

            var folderList = new List<string>
            {
                Path.Combine(Constants.ImageFolderPath, shop.Image),
                @"D:\Programming\CodeAcademy\FrontEnd\FinalProject\limak-az--front-end\public\images" + shop.Image
            };

            FileUtil.DeleteFile(folderList);

            shop.IsDeleted = true;
            await _shopService.UpdateAsync(shop);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var shop = await _shopService.GetShopAsync(id.Value);
            if (shop == null)
                return NotFound();

            return View(shop);
        }

        #endregion
    }
}
