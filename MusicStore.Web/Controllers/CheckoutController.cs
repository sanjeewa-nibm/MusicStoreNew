﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Web.Models;
using MusicStore.Web.MusicShoppingCartMgr;

namespace MusicStore.Web.Controllers
{
    public class CheckoutController : Controller
    {
        MusicShoppingCartMgr.Cart serviceref1 = new MusicShoppingCartMgr.Cart();
        MusicShoppingCartMgr.iShoppingCart servicemethodref1 = new iShoppingCartClient();
        //

        const string PromoCode = "FREE";
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    servicemethodref1.AddOrder(order);

                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order, cart.ShoppingCartId);

                    return RedirectToAction("Complete",new { id = order.OrderId });
                }

            }
            catch (Exception ex)
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = servicemethodref1.IsValid(id, User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
	}
}