using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;
using System.Data.Entity; 

namespace MusicStore.Data
{
    public class MusicDataBaseManager
    {
        #region -Genre-

        public static IEnumerable<Genre> GetAllGenreList()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Genres.ToList<Genre>();
        }

        public static IEnumerable<Genre> GetTopSellingGenres(int count)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Genres.OrderByDescending(a => a.GenreId)
                .Take(count)
                .ToList();
        }

        // Retrieve Genre and its Associated Albums from database
        public static Genre BrowseGenre(string genre)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            //return db.Genres.Single(g => g.Name == genre);
            return db.Genres.Include("Albums").Single(g => g.Name == genre);

        }

        #endregion

        #region -Album-
        public static Album BrowseAlbum(int id)
        {
            MusicStoreEntities db = new MusicStoreEntities();

            return db.Albums.Find(id);

        }
        public static IEnumerable<Album> GetAllAlbumList()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Albums.ToList<Album>();
        }
        public static Album FindAlbum(int id)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Albums.Find(id);
        }

        public static void CreateAlbum(Album album)
        {
            MusicStoreEntities db = new MusicStoreEntities();

            db.Albums.Add(album);
            db.SaveChanges();
        }
        public static void EditAlbum(Album album)
        {
            MusicStoreEntities db = new MusicStoreEntities();

            db.Entry(album).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static IEnumerable<Album> GetTopSellingAlbums(int count)
        {
            MusicStoreEntities db = new MusicStoreEntities();

            var rowcount = db.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList().Count();

            if (rowcount > 0)
            {
                return db.Albums
                    .OrderByDescending(a => a.OrderDetails.Count())
                    .Take(count)
                    .ToList();
            }
            else
            {
                return db.Albums
               .Take(count)
               .ToList();
            }
        }

        #endregion

        #region -Artist-
        public static IEnumerable<Artist> GetAllArtistList()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Artists.ToList<Artist>();
        }
        #endregion

        #region -Store Manger-

        public static IEnumerable<Album> GetAllStoreMangerList()
        {
            MusicStoreEntities db = new MusicStoreEntities();

            return db.Albums.Include(a => a.Genre).Include(a => a.Artist);
        }
        #endregion
    }
}
