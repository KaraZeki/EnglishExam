using EnglishExam.Business.IServices;
using EnglishExam.Model.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EnglishExam.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService )
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel model)
        {

            var userCheck = _userService.UserAccountControlAsync(model);
            if (userCheck.IsOk)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,model.Email),
                    new Claim("Id",userCheck.Id.ToString())
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"] = userCheck.Message;
                return RedirectToAction("Index", "Login");
            }
            
        }
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
