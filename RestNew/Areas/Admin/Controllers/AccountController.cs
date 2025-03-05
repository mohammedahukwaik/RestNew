using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestNew.Areas.Admin.ViewModels;
using RestNew.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;

        public AccountController(
            SignInManager<IdentityUser> _SignInManager,
            UserManager<IdentityUser> _UserManager )
        {
            SignInManager = _SignInManager;
            UserManager = _UserManager;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(key: "", errorMessage: "Email Or Password Is Not Correct");
                    return View();
                }

                var user = new IdentityUser
                {
                    // IdentityUser = LoginModel
                    Email = collection.Email,
                    UserName = collection.Email,
                };/* Momani*/
                var data = await SignInManager.PasswordSignInAsync(
                    collection.Email, collection.Password, collection.RememberMe, false);

                if (data.Succeeded) 
                {
                    return RedirectToAction("Index","Home");
                }

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(key: "", errorMessage: "Email Or Password Is Not Correct");
                    return View();
                }

                var user = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email,
                };

                var data = await UserManager.CreateAsync(user,collection.Password);

                if (data.Succeeded)
                {
                    //await SignInManager.SignInAsync(user,false);
                    //return RedirectToAction("Index","Home");
                    return RedirectToAction(nameof(Login));

                }

                return RedirectToAction(nameof(Register));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Logout()       
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
