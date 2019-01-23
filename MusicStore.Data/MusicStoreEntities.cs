using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Core;

namespace MusicStore.Data
{
    public class MusicStoreEntities : DbContext
    {
//
        public MusicStoreEntities()
            : base("MusicStoreEntities")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            this.Configuration.ProxyCreationEnabled = false;
            //this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer<MusicStoreEntities>(new CreateDatabaseIfNotExists<MusicStoreEntities>());
            Database.SetInitializer(new CommonDBInitializer());
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
