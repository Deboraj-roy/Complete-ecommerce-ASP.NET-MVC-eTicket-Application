using eTicket.Data.Cart;
using eTicket.Data.Services;
using eTicket.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, ILogger<OrdersController> logger)
        { 
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
            _logger = logger;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;
            
            _logger.LogInformation("I am currently within the ShoppingCart action of the Orders Controller.");

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            }; 

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));

        }

    }
}
