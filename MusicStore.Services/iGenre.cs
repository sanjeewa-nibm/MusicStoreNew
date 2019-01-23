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
    interface iGenre
    {
        [OperationContract]
        IEnumerable<Genre> GetAllGenreList();
        [OperationContract]
        IEnumerable<Genre> GetTopSellingGenres(int count);
        [OperationContract]
        Genre BrowseGenre(string genre);
    }
}
