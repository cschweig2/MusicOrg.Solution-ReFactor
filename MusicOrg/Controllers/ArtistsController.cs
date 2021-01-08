using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicOrg.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrg.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly MusicOrgContext _db;

        public ArtistsController(MusicOrgContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Artists.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            _db.Artists.Add(artist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisArtist = _db.Artists
                .Include(artist => artist.Vinyls)
                .ThenInclude(join => join.Vinyl)
                .FirstOrDefault(artist => artist.ArtistId == id);
            return View(thisArtist);
        }

        




        public ActionResult Delete(int id)
        {
            var thisArtist = _db.Artists.FirstOrDefault(artists => artists.ArtistId == id);
            return View(thisArtist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisArtist = _db.Artists.FirstOrDefault(artists => artists.ArtistId == id);
            _db.Artists.Remove(thisArtist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteVinyl(int joinId)
        {
            var joinEntry = _db.ArtistVinyl.FirstOrDefault(entry => entry.ArtistVinylId == joinId);
            _db.ArtistVinyl.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}