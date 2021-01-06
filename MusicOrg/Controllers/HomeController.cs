using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MusicOrg.Models;

namespace MusicOrg.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}