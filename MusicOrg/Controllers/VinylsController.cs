using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MusicOrg.Models;

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

    }
}

