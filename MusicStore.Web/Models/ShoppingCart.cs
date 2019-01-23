using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Web.MusicShoppingCartMgr;

namespace MusicStore.Web.Models
{
    public class ShoppingCart
    {
        MusicShoppingCartMgr.Cart serviceref1 = new MusicShoppingCartMgr.Cart();
        MusicShoppingCartMgr.iShoppingCart servicemethodref1 = new iShoppingCartClient();

        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                     //Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                     //Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }


        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Album album,string ShoppingCartID)
        {
            servicemethodref1.AddToCart(album,ShoppingCartID);
        }
        public int RemoveFromCart(string ShoppingCartId, int id)
        {
            return servicemethodref1.RemoveFromCart(ShoppingCartId,id);
        }
        public List<Cart> GetCartItems(string ShoppingCartId)
        {
            return servicemethodref1.GetCartItems(ShoppingCartId);
        }

        public int GetCount()
        {
            return servicemethodref1.GetCount();
        }
        public decimal GetTotal(string ShoppingCartId)
        {
            return servicemethodref1.GetTotal(ShoppingCartId);
        }
        public int CreateOrder(Order order, string ShoppingCartId)
        {
            return servicemethodref1.CreateOrder(order, ShoppingCartId);
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            servicemethodref1.MigrateCart(userName);
        }
    }
}