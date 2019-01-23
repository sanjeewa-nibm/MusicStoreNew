using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Business;
using MusicStore.Core;

namespace MusicStore.Services
{
    public class AlbumServiceManager : iAlbum
    {
        public Album BrowseAlbum(int id)
        {
            return AlbumBusinesManager.BrowseAlbum(id);
        }

        public IEnumerable<Album> GetAllAlbumList()
        {
            return AlbumBusinesManager.GetAllAlbumList();
        }
        public IEnumerable<Album> GetTopSellingAlbums(int count)
        {
            return AlbumBusinesManager.GetTopSellingAlbums(count);
        }
        public IEnumerable<Album> GetAllStoreMangerList()
        {
            return StoreMgrBusinesManager.GetAllStoreMangerList();
        }
        public void CreateAlbum(Album album)
        {
            AlbumBusinesManager.CreateAlbum(album);
        }
        public void EditAlbum(Album album)
        {
            AlbumBusinesManager.EditAlbum(album);
        }
        public Album FindAlbum(int id)
        {
            return AlbumBusinesManager.FindAlbum(id);
        }
    }
}
