using AdminPanel.ViewModels;
using Buisness.Abstract;
using DataAccess.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    [Authorize(Roles = RoleConstants.AdminRole + "," + RoleConstants.ModeratorRole)]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IStatusService _statusService;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(IOrderService orderService, IStatusService statusService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _statusService = statusService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string id, int page = 1)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var allOrders = await _orderService.GetAllOrdersAsync(id);
            if (allOrders == null)
                return NotFound();

            ViewBag.PageCount = Decimal.Ceiling((decimal)allOrders.Count / 5);
            ViewBag.Page = page;
            ViewBag.UserId = id;

            TempData["id"] = id;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var orders = await _orderService.GetAllOrdersAsync(x => x.StatusId != 4 && x.AppUserId == id 
                                        && x.IsDeleted == false, skipCount, 5);
            if (orders == null)
                return NotFound();

            var ordersVM = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                var status = await _statusService.GetStatusAsync(order.StatusId);
                var orderVM = new OrderViewModel
                {
                    Id = order.Id,
                    Url = order.Url,
                    Code = order.Code,
                    Count = order.Count,
                    Price = order.Price,
                    Note = order.Note,
                    Status = status.Title,
                    UserId = order.AppUserId
                };
                ordersVM.Add(orderVM);
            }

            return View(ordersVM);
        }

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            var order = await _orderService.GetOrderAsync(id.Value);
            if (order == null)
                return NotFound();

            var statuses = await _statusService.GetAllStatusesAsync();
            ViewBag.Statuses = statuses.Take(4);

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, int? statusId)
        {
            if (id == null)
                return BadRequest();

            if (statusId == null)
                return BadRequest();

            var statuses = await _statusService.GetAllStatusesAsync();
            ViewBag.Statuses = statuses.Take(4);

            var order = await _orderService.GetOrderAsync(id.Value);
            if (order == null)
                return NotFound();

            if (statuses.All(x => x.Id != statusId.Value))
                return BadRequest();

            order.StatusId = statusId.Value;

            await _orderService.UpdateAsync(order);

            string userId = "";

            if (TempData.ContainsKey("id"))
                userId = TempData["id"].ToString();

            TempData["userId"] = userId;

            return RedirectToAction("Index", new { id = userId });
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var order = await _orderService.GetOrderWithIncludeAsync(id.Value);
            if (order == null)
                return NotFound();

            return View(order);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var order = await _orderService.GetOrderWithIncludeAsync(id.Value);
            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
                return BadRequest();

            var order = await _orderService.GetOrderWithIncludeAsync(id.Value);
            if (order == null)
                return NotFound();

            order.IsDeleted = true;

            await _orderService.UpdateAsync(order);

            var user = await _userManager.FindByIdAsync(order.AppUserId);
            if (user == null)
                return NotFound();

            user.Balance += order.Price;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", new { id = order.AppUserId });
        }

        #endregion

        #region FinishedOrders

        public async Task<IActionResult> FinshedOrders(string id, int page = 1)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var allOrders = await _orderService.GetAllOrdersAsync(id);
            if (allOrders == null)
                return NotFound();

            ViewBag.PageCount = Decimal.Ceiling((decimal)allOrders.Count / 5);
            ViewBag.Page = page;
            ViewBag.UserId = id;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            int skipCount = (page - 1) * 5;

            var orders = await _orderService.GetAllOrdersAsync(x => x.AppUserId == id && x.Status.Id == 4 ,skipCount, 5);
            if (orders == null)
                return NotFound();

            var ordersVM = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                var status = await _statusService.GetStatusAsync(order.StatusId);
                var orderVM = new OrderViewModel
                {
                    Id = order.Id,
                    Url = order.Url,
                    Code = order.Code,
                    Count = order.Count,
                    Price = order.Price,
                    Note = order.Note,
                    Status = status.Title,
                    UserId = order.AppUserId
                };
                ordersVM.Add(orderVM);
            }

            return View(ordersVM);
        }

        #region Detail

        public async Task<IActionResult> FinishedOrderDetail(int? id)
        {
            if (id == null)
                return BadRequest();

            var order = await _orderService.GetOrderAsync(x => x.Id == id.Value && x.StatusId == 4);
            if (order == null)
                return NotFound();

            ViewBag.UserId = order.AppUserId;

            return View(order);
        }

        #endregion

        #endregion
    }
}
