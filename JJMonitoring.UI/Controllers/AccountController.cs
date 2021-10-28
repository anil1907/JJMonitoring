using Business.Abstract.Branch;
using Business.Abstract.Users;
using Entity.Enums;
using Entity.Users;
using Entity.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        private IBranchService _branchService;

        public AccountController(IUserService userService, IBranchService branchService)
        {
            _userService = userService;
            _branchService = branchService;

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

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, Enum.GetName(typeof(UserRole), (int)user.UserRole)));
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            List<EnumModel> enums = ((UserRole[])Enum.GetValues(typeof(UserRole))).Select(c => new EnumModel() { Value = (int)c, Name = c.ToString() }).ToList();
            ViewBag.RoleList = enums;
            ViewBag.BranchList = _branchService.GetBranches();
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.RetryPassword) || model.BranchId == 0 || (int)model.UserRole == 0)
            {
                ViewBag.InvalidMessage = "Tüm alanları doldurun!";
                return RedirectToAction("Register", "Account");
            }
            if (model.Password != model.RetryPassword)
            {
                ViewBag.InvalidMessage = "Şifreler Eşleşmiyor";
                return RedirectToAction("Register", "Account");
            }
            User user = _userService.RegisterWithModel(model);
            if (user != null)
                return RedirectToAction("Login", "Account");

            return RedirectToAction("Register", "Account");
        }

    }
}
