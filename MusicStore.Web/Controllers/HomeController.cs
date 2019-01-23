using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Web.MusicAlbumMgr;



namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        MusicAlbumMgr.Album serviceref1 = new MusicAlbumMgr.Album();
        MusicAlbumMgr.iAlbum servicemethodref1 = new iAlbumClient();

        public ActionResult Index()
        {
            var albums = GetTopSellingAlbums(3);
            return View(albums);
        }

        private IEnumerable<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count


            return servicemethodref1.GetTopSellingAlbums(count);
        }
    }
}