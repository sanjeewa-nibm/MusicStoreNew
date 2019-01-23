using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Core
{
    [Serializable]
    [DataContract]
    public class Artist
    {
        [DataMember]
        public int ArtistId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
