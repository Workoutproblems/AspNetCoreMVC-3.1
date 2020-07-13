﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string PropertyName { get; set; }
        public ViewResult Index() 
        {
            //ViewBag.Title = "Johnny";

            //dynamic data = new ExpandoObject(); // #32
            //data.Id = 1;
            //data.Name = "Jermyy";

            //ViewBag.Type = new BookModel() { Id = 5, Author = "Kevin" };

            //ViewBag.Data = data;
            ViewData["property1"] = "Jhony ViewData";

            ViewData["book"] = new BookModel() { Author = "Johnny", Id = 19 };

            return View();
        }
        public ViewResult AboutUs()
        {
            PropertyName = "Johnny S";
            ViewData["PropertyName"] = PropertyName;
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
