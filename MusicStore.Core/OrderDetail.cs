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
    public class OrderDetail
    {
         [DataMember]
        public int OrderDetailId { get; set; }
         [DataMember]
        public int OrderId { get; set; }
         [DataMember]
        public int AlbumId { get; set; }
         [DataMember]
        public int Quantity { get; set; }
         [DataMember]
        public decimal UnitPrice { get; set; }
        

        public virtual Album Album { get; set; }
         [DataMember]
        public virtual Order Order { get; set; }
    }
}
