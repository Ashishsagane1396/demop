using Ashish_.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Ashish_.Data;
using Ashish_.Models.Account;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace Ashish_.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _dbContext;

        public AccountController(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(LoginSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = "Register SuccessFul ! Fill the Login Credential";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["errorMessage"] = "Fill All The Details !";
                return View(model);
            }
          
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                var uname=_dbContext.Users.FirstOrDefault(u=> u.Username==model.Username);
                if (uname != null)
                {
                    bool isValid=uname.Password==model.Password;
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var pricipal=new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,pricipal);
                        HttpContext.Session.SetString("Username",model.Username);
                        TempData["Username"] = model.Username;
                        return RedirectToAction("Index","Vehicles");
                    }
                    else
                    {
                        TempData["errorPassord"] = "Invalid Password";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorUsername"] = "Username Not Found !";
                    return View(model);
                }
                
            }

            return View(model);
        }

       public IActionResult LogOut() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookie in storedCookies)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index","Home"); }
    }
}
