using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;
using MusicStore.Data;

namespace MusicStore.Business
{
    public class StoreMgrBusinesManager
    {
        public static IEnumerable<Album> GetAllStoreMangerList()
        {
            return MusicDataBaseManager.GetAllStoreMangerList();
        }
    }
}
