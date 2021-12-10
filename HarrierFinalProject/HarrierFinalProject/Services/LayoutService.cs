using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Http;
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

        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }

        public List<BasketViewModel> GetFavorites()
        {
            List<BasketViewModel> items = new List<BasketViewModel>();

            string itemsStr = _contextAccessor.HttpContext.Request.Cookies["BasketCookie"];

            if (itemsStr != null)
            {
                items = JsonConvert.DeserializeObject<List<BasketViewModel>>(itemsStr);


                foreach (var item in items)
                {
                    Car car = _context.Cars.Include(c => c.CarImages).FirstOrDefault(x => x.Id == item.CarId);
                    if (car != null)
                    {
                        item.CarName = car.Brand.Name + car.Model.Name;
                        item.CarPrice = (decimal)car.Price;
                        item.CarPosterImage = car.CarImages.FirstOrDefault(x => x.IsPoster == true)?.Image;
                    }
                }
            }

                return items;
        }
    }
}
