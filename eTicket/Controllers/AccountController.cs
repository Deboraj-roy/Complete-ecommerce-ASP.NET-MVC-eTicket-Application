using eTicket.Data;
using eTicket.Data.ViewModels;
using eTicket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            AppDbContext context, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
        }

        public IActionResult Login()
        {
            _logger.LogInformation("I am in Account Controller.");

            return View(new LoginVM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        _logger.LogError("Logged in Success.");
                        return RedirectToAction("Index", "Movies");
                    }
                }

                _logger.LogError("Wrong credentials. Please, try again!");
                TempData["LoinError"] = "Wrong credentials. Please, try again!";
                return View(loginVM);

            }

            _logger.LogError("Wrong credentials. Please, try again!");
            TempData["LoinError"] = "Wrong credentials. Please, try again!";
            return View(loginVM);

        }
    }
}
