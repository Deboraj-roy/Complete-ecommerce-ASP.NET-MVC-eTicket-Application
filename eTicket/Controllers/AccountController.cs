using eTicket.Data;
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

        public IActionResult Index()
        {
            _logger.LogInformation("I am in Account Controller.");

            return View();
        }
    }
}
