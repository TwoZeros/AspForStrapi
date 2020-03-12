using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspforStrapi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using AspforStrapi.Data;
using AspforStrapi.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AspforStrapi.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AccountController(ILogger<AccountController> logger, IAuthService authService, IUserService userService)
        {
            _logger = logger;
            _authService = authService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var jwt = Request.Cookies["jwt"];
            
          var profile=  await _userService.GetMyInfo(jwt);
            return View(profile);
        }

        [Authorize(Roles = "Boss")]
        public async Task<IActionResult> AllUser()
        {
            var jwt = Request.Cookies["jwt"];

            var userList = await _userService.UserList(jwt);
            return View(userList);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

            ClaimsIdentity claimsIdenity =await _authService.GetIdentity(username, password);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                IsPersistent = true,
            };
            if(claimsIdenity == null)
            {
                return View();
            }
           // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdenity), authProperties);
            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdenity));

           
            Response.Cookies.Append("jwt", _authService.getToken());
            return RedirectToAction("Profile");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
