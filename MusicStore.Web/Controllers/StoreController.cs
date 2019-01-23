using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MusicStore.Web.MusicAlbumMgr;
using MusicStore.Web.MusicGenreMgr;

namespace MusicStore.Web.Controllers
{
//    [Authorize]
    public class StoreController : Controller
    {
        MusicGenreMgr.Genre serviceref = new MusicGenreMgr.Genre();
        MusicGenreMgr.iGenre servicemethodref = new iGenreClient();

        MusicAlbumMgr.Album serviceref1 = new MusicAlbumMgr.Album();
        MusicAlbumMgr.iAlbum servicemethodref1 = new iAlbumClient();

       //
        // GET: /Store/
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var GenreAllList = servicemethodref.GetAllGenreList();
            return View(GenreAllList.ToList());
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = servicemethodref.BrowseGenre(genre);

            return View(genreModel);
        }
        
        // GET: /Store/Details/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var album = servicemethodref1.BrowseAlbum(id);
            
            return View(album);
        }

        //[Authorize(Roles = "Admin")]
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = servicemethodref.GetAllGenreList();
            return PartialView(genres);
        }
    }
}