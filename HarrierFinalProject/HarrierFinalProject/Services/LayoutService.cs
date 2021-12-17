using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }

        public List<BasketViewModel> GetFavorites()
        {
            List<BasketViewModel> items = new List<BasketViewModel>();

            AppUser member = null;
            if(_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin); 
            }
           
            if(member == null)
            {
                string itemsStr = _contextAccessor.HttpContext.Request.Cookies["BasketCookie"];

                if (itemsStr != null)
                {
                    items = JsonConvert.DeserializeObject<List<BasketViewModel>>(itemsStr);


                    foreach (var item in items)
                    {
                        Car car = _context.Cars.Include(c => c.CarImages).Include(x=>x.Brand).Include(x=>x.Model).FirstOrDefault(x => x.Id == item.CarId);
                        if (car != null)
                        {
                            item.CarName = car.Brand.Name + car.Model.Name;
                            item.CarPrice = (decimal)car.Price;
                            item.CarPosterImage = car.CarImages.FirstOrDefault(x => x.IsPoster == true)?.Image;
                        }
                    }
                }
            }
            else
            {
                List<BasketItem> basketItems = _context.BasketItems.Include(x=>x.Car)
                                                                    .ThenInclude(c=>c.Brand)
                                                                    .Include(x => x.Car)
                                                                    .ThenInclude(x=>x.CarImages)
                                                                    .Where(x => x.AppUserId==member.Id)
                                                                    .ToList();
                items = basketItems.Select(x => new BasketViewModel
                {
                    CarId = x.CarId,
                    CarPosterImage = x.Car.CarImages.FirstOrDefault(ci => ci.IsPoster == true).Image,
                    CarName = x.Car.Brand.Name,
                    CarPrice = x.Car.Price
                }).ToList();
            }

            

            return items;
        }
    }
}
