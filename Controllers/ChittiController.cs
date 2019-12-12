using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CTrackAPI.Controllers
{
    public class ChittiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}