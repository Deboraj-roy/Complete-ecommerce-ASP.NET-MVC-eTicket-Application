using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Cart
{
    public class ShoppingCart
    {
        //public AppDbContext _context { get; set; }
        private readonly AppDbContext _context;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        { 
            _context = context;
        }
        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id
            && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null) 
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1,
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ?? (shoppingCartItems = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
            .Select(n => n.Movie.Price * n.Amount).Sum();
    }
}
