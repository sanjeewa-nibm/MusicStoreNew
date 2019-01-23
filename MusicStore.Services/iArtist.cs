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
    interface iArtist
    {
        [OperationContract]
        IEnumerable<Artist> GetAllArtistList();
    }
}
