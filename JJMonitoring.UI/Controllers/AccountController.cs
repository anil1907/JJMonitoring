using Business.Abstract.Users;
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
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Login()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                ViewBag.InvalidMessage = "Tüm alanları doldurun!";
                return View();
            }

            User user = _userService.Login(model.Username, model.Password);

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
