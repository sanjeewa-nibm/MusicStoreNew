using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;
using MusicStore.Data;

namespace MusicStore.Business
{
    public class AlbumBusinesManager
    {
        public static Album BrowseAlbum(int id)
        {
            return MusicDataBaseManager.BrowseAlbum(id);
        }

        public static IEnumerable<Album> GetAllAlbumList()
        {
            return MusicDataBaseManager.GetAllAlbumList();
        }

        public static IEnumerable<Album> GetTopSellingAlbums(int count)
        {
            return MusicDataBaseManager.GetTopSellingAlbums(count);
        }
        public static void CreateAlbum(Album album)
        {
            MusicDataBaseManager.CreateAlbum(album);
        }
        public static void EditAlbum(Album album)
        {
            MusicDataBaseManager.EditAlbum(album);
        }
        public static Album FindAlbum(int id)
        {
           return MusicDataBaseManager.FindAlbum(id);
        }
    }
}
