using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IHubContext<HarrierHub> _hubContext;

        public OrderController(AppDbContext context, IEmailService emailService, IHubContext<HarrierHub> hubContext)
        {
            _context = context;
            _emailService = emailService;
            _hubContext = hubContext;
        }
        public IActionResult Index(int page = 1, string search=null)
        {
            if (page <= 0)
            {
                page = 1;
            }

            var query = _context.Orders.OrderByDescending(x => x.CreatedAt).Include(x => x.Car).Include(x => x.AppUser).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.AppUser.Fullname.Contains(search) || x.Car.Brand.Name.Contains(search));

            List<Order> orders = query.Skip((page - 1) * 6).Take(6).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 6m);
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

        public async Task<IActionResult> Accept(int id)
        {
            Order order = _context.Orders.Include(x=>x.AppUser).Include(x=>x.Car).FirstOrDefault(x => x.Id == id);
            if (order == null) return NotFound();

            order.Status = Data.Models.Enums.OrderStatus.Accepted;
            _context.SaveChanges();



            if (order.AppUser?.ConnectionId != null)
            {
                await _hubContext.Clients.Client(order.AppUser.ConnectionId).SendAsync("OrderAccepted");

            }


            string body = string.Empty;

            using (StreamReader reader = new StreamReader("wwwroot/templates/order.html"))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{{price}}", order.Car.Price.ToString());

            string orders = string.Empty;

            orders = @$"<tr><td width=\""75 %\"" align=\""left\"" style =\""font - family: Open Sans, Helvetica, Arial, sans-serif; font - size: 16px; font - weight: 400; line - height: 24px; padding: 15px 10px 5px 10px;\"" > {order.AppUser.Fullname} </td>
           </tr>";

            body = body.Replace("{{price}}", order.Car.Price.ToString()).Replace("{{order}}", orders);


            _emailService.Send(order.AppUser.Email, "Order Accepted", body);





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
