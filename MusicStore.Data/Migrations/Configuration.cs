using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MusicStore.Data.MusicStoreEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
