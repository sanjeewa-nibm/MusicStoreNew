using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;
using MusicStore.Data;

namespace MusicStore.Business
{
    public class ShoppingCartBusinesManager
    {
        public static int CreateOrder(Order order, string ShoppingCartID)
        {
            return ShoppingCartDataBaseManager.CreateOrder(order, ShoppingCartID);
        }
        public static void AddToCart(Album album, string ShoppingCartID)
        {
            ShoppingCartDataBaseManager.AddToCart(album,ShoppingCartID);
        }

        public static List<Cart> GetCartItems(string ShoppingCartID)
        {
            return ShoppingCartDataBaseManager.GetCartItems(ShoppingCartID);
        }
        public static decimal GetTotal(string ShoppingCartID)
        {
            return ShoppingCartDataBaseManager.GetTotal(ShoppingCartID);
        }
        public static Album GetAlbum(int id)
        {
            return ShoppingCartDataBaseManager.GetAlbum(id);
        }
        public static int RemoveFromCart(string ShoppingCartID,int id)
        {
            return ShoppingCartDataBaseManager.RemoveFromCart(ShoppingCartID,id);
        }
        public static int GetCount()
        {
            return ShoppingCartDataBaseManager.GetCount();
        }

        public static void MigrateCart(string userName)
        {
            ShoppingCartDataBaseManager.MigrateCart(userName);
        }

        public static void AddOrder(Order order)
        {
            ShoppingCartDataBaseManager.AddOrder(order);
        }
        public static bool IsValid(int id, string userName)
        {
            return ShoppingCartDataBaseManager.IsValid(id, userName);
        }
    }
}
