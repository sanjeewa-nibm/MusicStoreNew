using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Web.MusicAlbumMgr;
using MusicStore.Web.MusicArtistsMgr;
using MusicStore.Web.MusicGenreMgr;

namespace MusicStore.Web.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicAlbumMgr.Album serviceref1 = new MusicAlbumMgr.Album();
        MusicAlbumMgr.iAlbum servicemethodref1 = new iAlbumClient();

        MusicGenreMgr.Genre serviceref = new MusicGenreMgr.Genre();
        MusicGenreMgr.iGenre servicemethodref = new iGenreClient();

        MusicArtistsMgr.Artist serviceref2 = new MusicArtistsMgr.Artist();
        MusicArtistsMgr.iArtist servicemethodref2 = new iArtistClient();

        //
        // GET: /StoreManager/
        public ActionResult Index()
        {
            var StoreMangerAllList = servicemethodref1.GetAllStoreMangerList();
            return View(StoreMangerAllList.ToList());
        }
        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            var GenresAllList = servicemethodref.GetAllGenreList();
            var ArtistsAllList = servicemethodref2.GetAllArtistList();
            ViewBag.GenreId = new SelectList(GenresAllList, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(ArtistsAllList, "ArtistId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(MusicStore.Web.MusicAlbumMgr.Album album)
        {
            var GenresAllList = servicemethodref.GetAllGenreList();
            var ArtistsAllList = servicemethodref2.GetAllArtistList();

            if (ModelState.IsValid)
            {
                servicemethodref1.CreateAlbum(album);
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(GenresAllList, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(ArtistsAllList, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            var GenresAllList = servicemethodref.GetAllGenreList();
            var ArtistsAllList = servicemethodref2.GetAllArtistList();


            MusicStore.Web.MusicAlbumMgr.Album album = servicemethodref1.FindAlbum(id);
            ViewBag.GenreId = new SelectList(GenresAllList, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(ArtistsAllList, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(MusicStore.Web.MusicAlbumMgr.Album album)
        {
            var GenresAllList = servicemethodref.GetAllGenreList();
            var ArtistsAllList = servicemethodref2.GetAllArtistList();

            if (ModelState.IsValid)
            {
                servicemethodref1.EditAlbum(album);
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(GenresAllList, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(ArtistsAllList, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }
	}
}