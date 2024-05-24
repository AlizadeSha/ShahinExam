using AmoebaApp.Models;
using AmoebaApp.ViewModels.Login;
using AmoebaApp.ViewModels.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Diagnostics;

namespace AmoebaApp.Controllers
{
    public class AuthController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            AppUser appUser = new AppUser
            {
                Email = vm.Email,
                Name = vm.Name,
                Surmame = vm.Surname,
                UserName = vm.Username
            };

            IdentityResult result = await _userManager.CreateAsync(appUser ,vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(vm);
                }
            };
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Login(LoginVm vM)
        {
            if (!ModelState.IsValid) { return View(vM); }
            AppUser user = await _userManager.FindByNameAsync(vM.UsernamOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(vM.UsernamOrEmail);
                if (user == null)
                {
                    ModelState.AddModelError("", "Istifadeci adi ve ya parol yalnisdir");
                    return View(vM);
                }
            }

            user.AccessFailedCount++;


            var result = await _signInManager.CheckPasswordSignInAsync(user, vM.Password, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Cox sayda yalnis parol gonderdiniz");
                return View(vM);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
    }


    }



}

