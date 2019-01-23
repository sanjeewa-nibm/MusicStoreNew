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
    interface iAlbum
    {
        [OperationContract]
        Album BrowseAlbum(int id);

        [OperationContract]
        IEnumerable<Album> GetAllAlbumList();

        [OperationContract]
        IEnumerable<Album> GetTopSellingAlbums(int count);

        [OperationContract]
        IEnumerable<Album> GetAllStoreMangerList();

        [OperationContract]
        void CreateAlbum(Album album);

        [OperationContract]
        void EditAlbum(Album album);

        [OperationContract]
        Album FindAlbum(int id);
    }
}
