using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hr.Models;
using System.Net.Http;


namespace Hr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()

        {
            
            return View();
        }
        public IActionResult Show(string name,string surname, string Number,string mail, string other)
        {
            using (var context = new AppDbContext())
            {
                context.NewHead.Add(new NewHead
                {
                    name=name,
                    surname= surname,
                    number= Number,
                    mail= mail,
                    other=other
                });
                context.SaveChanges();
            }
                //if (GetLOg("check_login=" + Uri.EscapeDataString(Person)) =="false")
                //{
                //var g = GetLOg("read_message=" + Uri.EscapeDataString(Person));
                //var j = getget("read_message=" + Uri.EscapeDataString(Person));


                //ViewBag.Chats = j.Value;

                //Json(g);

                //var result = JsonConvert.DeserializeObject<LOL>(g.Value.ToString());


                //}
                //return View("index");
                return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AllHead()
        {
            using (var context = new AppDbContext())
            {
                List<NewHead> gg = context.NewHead.ToList<NewHead>();

                return View(gg);

            }

            //    var _emplst = _dbContext.new.
            //                Join(_dbContext.tblSkills, e => e.SkillID, s => s.SkillID,
            //                (e, s) => new EmployeeViewModel
            //                {
            //                    EmployeeID = e.EmployeeID,
            //                    EmployeeName = e.EmployeeName,
            //                    PhoneNumber = e.PhoneNumber,
            //                    Skill = s.Title,
            //                    YearsExperience = e.YearsExperience
            //                }).ToList();
            //IList<EmployeeViewModel> emplst = _emplst;
            //return View(emplst);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
