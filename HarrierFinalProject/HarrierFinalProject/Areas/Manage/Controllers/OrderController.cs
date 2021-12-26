using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    //[Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public OrderController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        public IActionResult Index(int page = 1)
        {
            List<Order> orders = _context.Orders.OrderByDescending(x => x.CreatedAt).Include(x => x.Car).Include(x => x.AppUser).Skip((page - 1) * 6).Take(6).ToList();

            ViewBag.TotalPage = Math.Ceiling(_context.Orders.Count() / 6m);
            ViewBag.SelectedPage = page;

            OrderViewModel orderVM = new OrderViewModel()
            {
                Orders = orders
            };

            return View(orderVM);
        }


        public IActionResult Edit(int id)
        {
            Order order = _context.Orders.Include(x => x.Car).Include(x => x.AppUser).FirstOrDefault(x => x.Id == id);

            if (order == null) return NotFound();

            OrderViewModel orderVM = new OrderViewModel()
            {
               Order = order
            };

            return View(orderVM);
        }

        public IActionResult Accept(int id)
        {
            Order order = _context.Orders.Include(x=>x.AppUser).Include(x=>x.Car).FirstOrDefault(x => x.Id == id);
            if (order == null) return NotFound();

            order.Status = Data.Models.Enums.OrderStatus.Accepted;
            _context.SaveChanges();

            _emailService.Send(order.AppUser.Email, "Order Accepted", "Your Order Accepted, total:");

            return RedirectToAction("index");
        }

        public IActionResult Reject(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null) return NotFound();

            order.Status = Data.Models.Enums.OrderStatus.Rejected;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
