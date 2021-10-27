using Business.Abstract.Users;
using Entity.Enums;
using Entity.Users;
using JJMonitoring.UI.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            if (user == null)
            {
                ViewBag.InvalidMessage = "Kullanıcı kimliği doğrulanamadı.";
                return View();
            }
            List<EnumModel> enums = ((UserRole[])Enum.GetValues(typeof(UserRole))).Select(c => new EnumModel() { Value = (int)c, Name = c.ToString() }).ToList();

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, enums.FirstOrDefault(x => x.Value == (int)user.UserRole).Name));
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel model)
        {
            //if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            //{
            //    ViewBag.InvalidMessage = "Tüm alanları doldurun!";
            //    return View();
            //}

            User user = _userService.Register(model.Username, model.Password);

            return View();
        }

    }
}
