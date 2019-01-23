using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;
using MusicStore.Data;

namespace MusicStore.Business
{
    public class ArtistBusinesManager
    {
        public static IEnumerable<Artist> GetAllArtistList()
        {
            return MusicDataBaseManager.GetAllArtistList();
        }
    }
}
