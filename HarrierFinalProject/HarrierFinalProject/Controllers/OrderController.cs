using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult CreateOrder(int id)
        {
            AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            Car car = _context.Cars.FirstOrDefault(x => x.Id == id);

            Order order = new Order
            {
                CarId = car.Id,
                AppUserId = member.Id,
                FullName = member.Fullname,
                Email = member.Email,
                CreatedAt = DateTime.UtcNow,
                Status = Data.Models.Enums.OrderStatus.Pending,
                Price = (decimal)car.Price
            };


            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("profile", "account");
        }
    }
}
