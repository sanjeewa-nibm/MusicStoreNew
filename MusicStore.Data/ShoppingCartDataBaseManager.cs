using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web;
using MusicStore.Core;

namespace MusicStore.Data
{
    public class ShoppingCartDataBaseManager
    {
       static string  ShoppingCartId { get; set; }
       public static int CreateOrder(Order order, string ShoppingCartID)
        {
            MusicStoreEntities db = new MusicStoreEntities();

            decimal orderTotal = 0;

            var cartItems = GetCartItems(ShoppingCartID);

            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    AlbumId = item.AlbumId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Album.Price,
                    Quantity = item.Count
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Album.Price);

                db.OrderDetails.Add(orderDetail);

            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            db.SaveChanges();

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.OrderId;
        }
        public static List<Cart> GetCartItems(string ShoppingCartID)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                return db.Carts.Include("Album").Where(cart => cart.CartId == ShoppingCartID).ToList();
            }
        }
        public static void EmptyCart()
        {
            MusicStoreEntities db = new MusicStoreEntities();

            var cartItems = db.Carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }

            // Save changes
            db.SaveChanges();
        }
        public static int RemoveFromCart(string ShoppingCartID,int id)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                // Get the cart
                var cartItem = db.Carts.Single(
                    cart => cart.CartId == ShoppingCartID
                            && cart.RecordId == id);

                int itemCount = 0;

                if (cartItem != null)
                {
                    if (cartItem.Count > 1)
                    {
                        cartItem.Count--;
                        itemCount = cartItem.Count;
                    }
                    else
                    {
                        db.Carts.Remove(cartItem);
                    }

                    // Save changes
                    db.SaveChanges();
                }

                return itemCount;
            }
        }
        public static void AddToCart(Album album, string ShoppingCartID)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                // Get the matching cart and album instances
                var cartItem = db.Carts.SingleOrDefault(
                    c => c.CartId == ShoppingCartID
                         && c.AlbumId == album.AlbumId);

                if (cartItem == null)
                {

                    // Create a new cart item if no cart item exists
                    cartItem = new Cart
                    {
                        AlbumId = album.AlbumId,
                        CartId = ShoppingCartID,
                        Count = 1,
                        DateCreated = DateTime.Now,
                    };

                    db.Carts.Add(cartItem);
                }
                else
                {
                    // If the item does exist in the cart, then add one to the quantity
                    cartItem.Count++;
                }

                // Save changes
                db.SaveChanges();
            }
        }
        public static int GetCount()
        {
            MusicStoreEntities db = new MusicStoreEntities();

            
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }
        public static decimal GetTotal(string ShoppingCartID)
        {
            MusicStoreEntities db = new MusicStoreEntities();

            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in db.Carts
                              where cartItems.CartId == ShoppingCartID
                              select (int?)cartItems.Count * cartItems.Album.Price).Sum();
            return total ?? decimal.Zero;
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public static void MigrateCart(string userName)
        {
            MusicStoreEntities db = new MusicStoreEntities();

            var shoppingCart = db.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            db.SaveChanges();
        }

        public static Album GetAlbum(int id)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                // Retrieve the album from the database
                //var addedAlbum = db.Albums
                //    .Single(album => album.AlbumId == id);

                //var addedAlbum = db.Carts.Where(c => c.RecordId == id);

                var addedAlbum = (from cartItems in db.Carts
                    where cartItems.RecordId == id
                    select cartItems.Album).Single();
               

                return addedAlbum;
            }

        }

        public static void AddOrder(Order order)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public static bool IsValid(int id, string userName)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                bool isValid = db.Orders.Any(
               o => o.OrderId == id &&
               o.Username == userName);

                return isValid;
            }
        }
    }
}
