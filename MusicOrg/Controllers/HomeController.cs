using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicOrg.Models;
using System.Collections.Generic;
using System.Linq;

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