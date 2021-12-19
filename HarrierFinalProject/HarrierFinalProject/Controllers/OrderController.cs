using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpPost]
        public IActionResult CreateOrder(CarViewModel viewModel)
        {
            AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

            var currentUserCars = _context.BasketItems.Include(x=>x.Car).Where(car => car.AppUserId == member.Id);

            foreach (var car in currentUserCars)
            {  
                Order order = new Order
                {
                    CarId = car.CarId,
                    AppUserId = member.Id,
                    CreatedAt = DateTime.UtcNow,
                    Status = Data.Models.Enums.OrderStatus.Pending,
                    Phone = viewModel.Phone,
                    Address = viewModel.Address,
                    CityId = viewModel.CityId
                };
                _context.Orders.Add(order);
                _context.BasketItems.Remove(car);
                 car.Car.CarSituationId = 0;
             }  
            _context.SaveChanges();

            return RedirectToAction("Profile", "Account");
        }
    }
}
