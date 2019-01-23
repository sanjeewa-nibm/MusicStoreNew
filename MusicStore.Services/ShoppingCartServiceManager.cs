using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Business;
using MusicStore.Core;

namespace MusicStore.Services
{
    public class ShoppingCartServiceManager : iShoppingCart
    {
        public int CreateOrder(Order order, string ShoppingCartID)
        {
            return ShoppingCartBusinesManager.CreateOrder(order, ShoppingCartID);
        }
        public void AddToCart(Album album, string ShoppingCartID)
        {
            ShoppingCartBusinesManager.AddToCart(album,ShoppingCartID);
        }

        public List<Cart> GetCartItems(string ShoppingCartID)
        {
            return ShoppingCartBusinesManager.GetCartItems(ShoppingCartID);
        }
        public decimal GetTotal(string ShoppingCartID)
        {
            return ShoppingCartBusinesManager.GetTotal(ShoppingCartID);
        }
        public Album GetAlbum(int id)
        {
            return ShoppingCartBusinesManager.GetAlbum(id);
        }
        public int RemoveFromCart(string ShoppingCartID,int id)
        {
            return ShoppingCartBusinesManager.RemoveFromCart(ShoppingCartID,id);
        }
        public int GetCount()
        {
            return ShoppingCartBusinesManager.GetCount();
        }
        public void MigrateCart(string userName)
        {
            ShoppingCartBusinesManager.MigrateCart(userName);
        }

        public void AddOrder(Order order)
        {
            ShoppingCartBusinesManager.AddOrder(order);
        }
        public bool IsValid(int id, string userName)
        {
            return ShoppingCartBusinesManager.IsValid(id, userName);
        }
    }
}
