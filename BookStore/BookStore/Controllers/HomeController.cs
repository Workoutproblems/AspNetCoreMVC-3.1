using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore.Models;

namespace BookStore.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        //[Route("~/")]
        public ViewResult Index() 
        {
            //ViewData["property1"] = "Jhony ViewData";
            //ViewData["book"] = new BookModel() { Author = "Johnny", Id = 19 };
            return View();
        }
        [HttpGet("about-us/{name:alpha:minlength(5)}")]
        public ViewResult AboutUs(string name)
        {
            //PropertyName = "Johnny S";
            //ViewData["PropertyName"] = PropertyName;
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
