using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Core
{
    [Serializable]
    [DataContract]
    public class Cart
    {
        [Key]
        [DataMember]
        public int RecordId { get; set; }
        [DataMember]
        public string CartId { get; set; }
        [DataMember]
        public int AlbumId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public System.DateTime DateCreated { get; set; }
        [DataMember]
        public virtual Album Album { get; set; }
    }
}
