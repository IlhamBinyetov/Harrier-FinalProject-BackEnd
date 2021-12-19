using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
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

        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.OrderByDescending(x => x.CreatedAt).Include(x => x.Car).Include(x => x.AppUser).ToList();

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
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null) return NotFound();

            order.Status = Data.Models.Enums.OrderStatus.Accepted;
            _context.SaveChanges();

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
