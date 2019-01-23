using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Web.Models;
using MusicStore.Web.MusicShoppingCartMgr;
using MusicStore.Web.ViewModels;

namespace MusicStore.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicShoppingCartMgr.Cart serviceref1 = new MusicShoppingCartMgr.Cart();
        MusicShoppingCartMgr.iShoppingCart servicemethodref1 = new iShoppingCartClient();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(cart.ShoppingCartId),
                CartTotal = cart.GetTotal(cart.ShoppingCartId)
            };

            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {
            var addedAlbum = servicemethodref1.GetAlbum(id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum, cart.ShoppingCartId);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            Album obj = servicemethodref1.GetAlbum(id);
            string albumName = string.Empty;
            if (obj != null)
            {
                albumName = obj.Title;
            }

            // Remove from cart
            int itemCount = cart.RemoveFromCart(cart.ShoppingCartId, id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(cart.ShoppingCartId),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }
	}
}