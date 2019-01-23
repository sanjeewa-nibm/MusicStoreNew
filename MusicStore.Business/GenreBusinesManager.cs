using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;
using MusicStore.Data;

namespace MusicStore.Business
{
    public class GenreBusinesManager
    {
        public static IEnumerable<Genre> GetAllGenreList()
        {
            return MusicDataBaseManager.GetAllGenreList();
        }
        public static IEnumerable<Genre> GetTopSellingGenres(int count)
        {
            return MusicDataBaseManager.GetTopSellingGenres(count);
        }
        public static Genre BrowseGenre(string genre)
        {
            return MusicDataBaseManager.BrowseGenre(genre);
        }
    }
}
