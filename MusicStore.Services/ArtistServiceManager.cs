using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Business;

namespace MusicStore.Services
{
    public class ArtistServiceManager : iArtist
    {
        public IEnumerable<Core.Artist> GetAllArtistList()
        {
            return ArtistBusinesManager.GetAllArtistList();
        }
    }
}
