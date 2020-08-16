using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetCms.Site.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace DotnetCms.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                //sign in
                var Signresult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (Signresult.Succeeded)
                {
                    return RedirectToAction("Secret");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username, string password)
        {

            var user = new IdentityUser
            {
                UserName = username,
                Email = ""
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var Signresult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (Signresult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var SchoolClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Jack"),
                new Claim(ClaimTypes.Email,"Jack@fmail.com")
            };

            var LicensClaims = new List<Claim>() {

                new Claim(ClaimTypes.Name,"Zheng"),
                new Claim(ClaimTypes.Email,"zsypublic@126.com"),
                new Claim("begin","2020-08-16")
            };
            
            var SchoolIdentity = new ClaimsIdentity(SchoolClaims, "Student Identity");
            var CarManagerIdentity = new ClaimsIdentity(LicensClaims, "Licens Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { SchoolIdentity, CarManagerIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
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
