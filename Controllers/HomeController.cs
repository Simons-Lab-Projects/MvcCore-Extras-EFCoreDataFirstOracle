using Microsoft.AspNetCore.Mvc;
using System;
using EFCoreDataFirstOracle.Models;

namespace EFCoreDataFirstOracle.Controllers
{
    public class HomeController : Controller
    {
        //GET: /Home
        public ViewResult Index()
        {
            ViewBag.Time = DateTime.Now.ToLocalTime();
            return View();
        }

        //GET: /Home/Foo
        public string Foo()
        {
            return "Hello from Foo";
        }

        public string GetDb()
        {
            string returnString = "";
            string NL = System.Environment.NewLine;
            ModelContext ctx = new ModelContext();

            foreach (Regions r in ctx.Regions)
            {
                returnString += r.RegionId + " " + r.RegionName + NL;
            }

            return returnString;
        }
    }
}
