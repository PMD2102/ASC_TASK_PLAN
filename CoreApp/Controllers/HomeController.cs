using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreApp.Models;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


        public IActionResult Grid1()
        {
            return View();
        }

        public IActionResult Form1()
        {
            return View(new UserViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                UserName = "johny",
                Password = "123456",
                Company = "The Boring Company",
                Agree = false
            });
        }

        public IActionResult Chart1()
        {
            return View();
        }
    }
}
