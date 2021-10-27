using Entity.Users;
using JJMonitoring.UI.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JJMonitoring.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.InvalidMessage = "Tüm alanları doldurun!";
                return View();
            }

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                ViewBag.InvalidMessage = "Tüm alanları doldurun!";
                return View();
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
