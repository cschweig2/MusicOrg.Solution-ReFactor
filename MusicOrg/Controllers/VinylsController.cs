using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MusicOrg.Models;

namespace MusicOrg.Controllers
{
    public class VinylsController : Controller
    {
        [HttpGet("/vinyl")]
        public ActionResult Index()
        {
          List<Vinyl> newVinylList = Vinyl.GetAll();
          return View(newVinylList);
        }


        [HttpGet("/vinyl/new")]
        public ActionResult New()
        {
          return View();
        }

        [HttpPost("/vinyl")]
        public ActionResult Create(string album, string artist)
        {
          public bool exist = false;
          for (int i=0; i < Artist._instances.Count; i++)
            {   
                Artist current = Artist._instances[i];
                if(current.Name == artist.ToLower)
                {
                  Vinyl newVinyl = new Vinyl(album);
                  Artist._instances[i].Records.Add(newVinyl.ToLower);
                  exist = true;
                } 
                else 
                {
                  exist = false;
                }
            }
          if(exist == true)
            {
              return RedirectToAction("Index");
            }
          else
            {
              Artist newArtist = new Artist(artist.ToLower);
              Vinyl newVinyl = new Vinyl(album.ToLower);
              Artist._instances[newArtist.Id].Records.Add(newVinyl);
              return RedirectToAction("Index");
            }
        }
    }
}

