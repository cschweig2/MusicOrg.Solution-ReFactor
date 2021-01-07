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
    }

}