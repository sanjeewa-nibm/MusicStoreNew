using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Business;
using MusicStore.Core;

namespace MusicStore.Services
{
    public class GenreServiceManager : iGenre
    {
        public IEnumerable<Genre> GetAllGenreList()
        {
            return GenreBusinesManager.GetAllGenreList();
        }

        public IEnumerable<Genre> GetTopSellingGenres(int count)
        {
            return GenreBusinesManager.GetTopSellingGenres(count);
        }
        public Genre BrowseGenre(string genre)
        {
            return GenreBusinesManager.BrowseGenre(genre);
        }
    }
}
