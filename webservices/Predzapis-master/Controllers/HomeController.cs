using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SignalR_Vuejs__Demo.Models;

namespace SignalR_Vuejs__Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [HttpGet("GetWindows")]
        public JsonResult GetWindows(string date)
        {



            if (date != null)
            {


                using (var context = new AppDbContext())
                {
                    //Получение времени записи
                    var times1 = context.Times;
                    //Получение ОКН
                    var windows = context.Windows;

                    var r = context.PredZapBD.Where(b => b.DATE==date); //поменять на приходящую дату
                    int h = context.Windows.ToList().Count * context.Times.ToList().Count;
                    

                    DateTime aDate = DateTime.Now;
                    string TTTT = aDate.ToString("dd/MM/yyyy HH:mm:ss");


                    if (r.ToList().Count < h)
                    {

                        foreach (var item in r)
                        {
                            context.PredZapBD.Remove(item);
                        }
                        context.SaveChanges();

                        foreach (var window in windows)
                        {
                            foreach (var time in times1)
                            {
                                context.PredZapBD.Add(new PredZapBD
                                {

                                    DATE = date,
                                    WINDOW = window.Name,
                                    TIME = time.Name,
                                    EDIT = "<p>Создано автоматически [" + TTTT+"]</p>"
                                }) ;
                            }
                        }
                        context.SaveChanges();


                    }


                    List<ParseJson> jjj = new List<ParseJson>();
                    List<HR> ttt = new List<HR>();

                    foreach (var window in windows)
                    {

                        foreach (var time in times1)
                        {
                            var c = context.PredZapBD.Where(b => b.WINDOW == window.Name && b.TIME == time.Name && b.DATE == date).ToList()[0];
                            ttt.Add(new HR
                            {
                                Name = c.TIME,
                                Leading = c.LEADING,
                                Person = c.FIO,
                                id = c.Id,
                                Edit = c.EDIT
                            });
                        }

                        jjj.Add(new ParseJson()
                        {
                            Name = window.Name,
                            Hr = ttt.ToList(),

                        });
                        ttt.Clear();
                    }

                    return Json(jjj);
                }
                
            }
            return Json("ОТСУТВУЕТ ДАТА");

        }

        //getDay?date
        [HttpGet("GetDay")]
        public string GetDay(string date)
        {
            string i;
            using(var context = new AppDbContext())
            {
                try
                {
                    var status = context.Holidays.Where(b => b.Date == date).Select(b => b.Status).ToList();
#pragma warning disable CA1305 // Укажите IFormatProvider
                    i = status.First().ToString();
#pragma warning restore CA1305 // Укажите IFormatProvider
                }
                catch
                {
                    i = "0";
                }
                
            }
            if (i == "0")
            {
                return "work";
            }
            else
            {
                return "not";

            }


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
