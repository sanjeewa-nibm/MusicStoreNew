using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;

namespace MusicStore.Services
{
    [ServiceContract]
    interface iShoppingCart
    {
        [OperationContract]
        int CreateOrder(Order order, string ShoppingCartID);

        [OperationContract]
        void AddToCart(Album album, string ShoppingCartID);

        [OperationContract]
        List<Cart> GetCartItems(string ShoppingCartID);
        [OperationContract]
        decimal GetTotal(string ShoppingCartID);
        [OperationContract]
        Album GetAlbum(int id);
        [OperationContract]
        int RemoveFromCart(string ShoppingCartID,int id);
        [OperationContract]
        int GetCount();

        [OperationContract]
        void MigrateCart(string userName);


        [OperationContract]
        void AddOrder(Order order);
        [OperationContract]
        bool IsValid(int id, string userName);
    }
}
