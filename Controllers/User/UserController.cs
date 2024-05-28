using ML.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ML.Controllers {

    public class UserController : Controller {
        
        private readonly ILogger<UserController> _logger;
        private readonly UserDbContext _context;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly UserManager<UserApp> _userManager;

        public UserController(ILogger<UserController> logger, UserDbContext context, SignInManager<UserApp> signInManager, UserManager<UserApp> userManager){
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Login

        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }

        // Register

        public IActionResult Register(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var existingUser = await _userManager.FindByNameAsync(username);
            if (existingUser != null)
            {
                ViewBag.Error = "Username already exists";
                return View();
            }

            var newUser = new UserApp { UserName = username };
            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = "Error occurred while registering user";
                return View();
            }
        }

        // Account

        public IActionResult Account(){
            return View();
        }

        public IActionResult YourAction(){
            ViewBag.ShowLinks = _signInManager.IsSignedIn(User);
            return View();
        }

        // Logout

        [HttpPost]
        public async Task<IActionResult> Logout(){
            await _signInManager.SignOutAsync();
            return RedirectToAction("Introduction", "Home");
        }
    }
}