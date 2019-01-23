using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;

namespace MusicStore.Data
{
    internal class CommonDBInitializer : CreateDatabaseIfNotExists<MusicStoreEntities>
    {
        protected override void Seed(MusicStoreEntities context)
        {
            var genres1 = new List<Genre>
            {
                new Genre
                {
                    Name = "Rock",
                    Description = "Rock",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Jazz",
                    Description = "Jazz",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Metal",
                    Description = "Metal",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Alternative",
                    Description = "Alternative",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Disco",
                    Description = "Disco",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Blues",
                    Description = "Blues",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Latin",
                    Description = "Latin",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Reggae",
                    Description = "Reggae",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Pop",
                    Description = "Pop",
                    Albums = new List<Album>()
                },
                new Genre
                {
                    Name = "Classical",
                    Description = "Classical",
                    Albums = new List<Album>()
                },
            };
            genres1.ForEach(d => context.Genres.Add(d));
            context.SaveChanges();

            var artist1 = new List<Artist>
            {
                new Artist
                {
                    Name = "Aaron Copland & London Symphony Orchestra",
                  
                },
                 new Artist
                {
                    Name = "Barry Wordsworth & BBC Concert Orchestra",
                  
                },
               
            };

            artist1.ForEach(d => context.Artists.Add(d));
            context.SaveChanges();

            var album1 = new List<Album>
            {
                new Album { Title = "The Best Of Men At Work",  Price = 8.99M,  AlbumArtUrl = "/Content/Images/placeholder.gif",Genre = genres1.FirstOrDefault(d => d.GenreId == 1), Artist  = artist1.FirstOrDefault(d => d.ArtistId == 1) },
               new Album { Title = "A Copland Celebration, Vol. I",  Price = 8.99M, AlbumArtUrl = "/Content/Images/placeholder.gif",Genre = genres1.FirstOrDefault(d => d.GenreId == 2),Artist  = artist1.FirstOrDefault(d => d.ArtistId == 2) },

            };

            album1.ForEach(s => context.Albums.Add(s));

            context.SaveChanges();

            //genres1[0].Albums.Add(album1[0]);
            //genres1[0].Albums.Add(album1[1]);
            //context.SaveChanges();

        }
    }
}
