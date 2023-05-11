using AutoMapper;
using IdentityManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(IMapper mapper, UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, SignInManager<AppUser> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            this.signInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = mapper.Map<AppUser>(userVM);
                user.WhoAdded = "Abbas";
                //AppUser user = new();
                //mapper.Map(userVM,user);
                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("User Create", $"{error.Code} - {error.Description}");
                    }
                }
            }
            return View(userVM);
        }       
        public IActionResult List()
        {
            return View(userManager.Users.ToList());
        }
        public async Task<IActionResult> Update(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("List");
            }
            UserVM userVm = mapper.Map<UserVM>(user);

            return View(userVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(userVM.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("User", "Bende böyle bir user yok arkadaş");
                    return View(userVM);
                }
                mapper.Map(userVM, user);
                user.PasswordHash = passwordHasher.HashPassword(user, userVM.Password);
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("User Update", $"{error.Code} - {error.Description}");
                    }
                }
            }
            return View(userVM);
        }
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            IdentityResult result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("List");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("User Update", $"{error.Code} - {error.Description}");
                }
            }
            return View("List");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);
                if (appUser != null)
                {
                    await signInManager.SignOutAsync(); // bütün oturumları kapatır.
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("List");
                    }
                }

                ModelState.AddModelError("User Operations", $"Böyle bir mail ile ({login.Email}) giriş başarısız. Şifre veya email yanlış girilmiştir.");
            }
            return View(login);
        }
    }
}
