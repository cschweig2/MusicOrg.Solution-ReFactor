using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicOrg.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrg.Controllers
{
    public class VinylsController : Controller
    {
        private readonly MusicOrgContext _db;

        public VinylsController(MusicOrgContext db)
        {
          _db = db;
        }

        public ActionResult Index()
        {
          return View(_db.Vinyls.ToList());
        }

        public ActionResult Create()
        {
          ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
          return View();
        }

        [HttpPost]
        public ActionResult Create(Vinyl vinyl, int ArtistId)
        {
          _db.Vinyls.Add(vinyl);
          if (ArtistId != 0)
          {
            _db.ArtistVinyl.Add(new ArtistVinyl() { ArtistId = ArtistId, VinylId = vinyl.VinylId});
          }
          _db.SaveChanges();
          return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
          var thisVinyl = _db.Vinyls
            .Include(vinyl => vinyl.Artists)
            .ThenInclude(join => join.Artist)
            .FirstOrDefault(vinyl => vinyl.VinylId == id);
          return View(thisVinyl);
        }

        public ActionResult Edit(int id)
        {
          var thisVinyl = _db.Vinyls.FirstOrDefault(vinyls => vinyls.VinylId == id);
          ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
          return View(thisVinyl);
        }

        [HttpPost]
        public ActionResult Edit(Vinyl vinyl, int ArtistId)
        {
          if (ArtistId != 0)
          {
            _db.ArtistVinyl.Add(new ArtistVinyl() { ArtistId = ArtistId, VinylId = vinyl.VinylId});
          }
          _db.Entry(vinyl).State = EntityState.Modified;
          _db.SaveChanges();
          return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
          var thisVinyl = _db.Vinyls.FirstOrDefault(vinyls => vinyls.VinylId == id);
          return View(thisVinyl);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
          var thisVinyl = _db.Vinyls.FirstOrDefault(vinyls => vinyls.VinylId == id);
          _db.Vinyls.Remove(thisVinyl);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteArtist(int joinId)
        {
            var joinEntry = _db.ArtistVinyl.FirstOrDefault(entry => entry.ArtistVinylId == joinId);
            _db.ArtistVinyl.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

