using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMVCMVC.Models;
using Packt.Shared;

namespace MovieMVCMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieMVC db;
        public HomeController(ILogger<HomeController> logger, MovieMVC injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index(string searchName)
        {
                var model = new HomeIndexViewModel{
                    //VisitorCount = (new Random()).Next(1,1001),
                    Genres = db.Genres.ToList(),
                    Languages = db.Languages.ToList(),
                    Movies = db.Movies.ToList(),
                };
            
            return View(model);
        }
        public IActionResult Details(int? id){
            
            if(!id.HasValue){
                return NotFound("come on, pass an id");
            }
            var model = db.Movies.SingleOrDefault(m => m.MovieID==id);
            if(model==null){
                return NotFound($"Movie of id {id} not found");
            }
            return View(model);
        }

        public IActionResult RatingSorting(){
            var query  = (from m in db.Movies
                        join r in db.Ratings on m.MovieID equals r.RatingID
                        orderby r.RottenTomatoes
                        select new {m, r});
            return View("Index");
        }
        //[Route("private")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


/*
<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core. </a>.</p>
    <p class="lead">
        We have had @Model.VisitorCount visitors this month.
    </p>
</div>*/