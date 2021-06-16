using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMVCMVC.Models;
using Packt.Shared;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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
            var k = (from kk in db.Ratings
                    orderby kk.RottenTomatoes descending
                    where (kk.RottenTomatoes > 0 ) 
                    select kk).Take(20);

            var r = db.Ratings.OrderByDescending(rr => rr.RottenTomatoes).Take(20);
            var m  = (from o in db.Movies 
                    join rr in k on  o.MovieID  equals rr.RatingID
                    select o).ToList();

            var r2 = from a in k
                    select a.RottenTomatoes;
            List<string> s = new List<string>();

            foreach( var one in m){
                s.Add((getImage(one.Title).Result));
            };

                var model = new HomeIndexViewModel{
                    Genres = db.Genres.ToList(),
                    Languages = db.Languages.ToList(),
                    Movies = m,
                    Links=s,
                    Ratings = r2.ToList()
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
   
   public async Task<string> getImage(string title){
            string ipath;
            var baseAddress = new Uri("http://api.themoviedb.org/3/");
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {     
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var response = await httpClient.GetAsync("search/movie?api_key=8952d55f994145a828d53d9ee73af551&query=" + title))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<original>(responseData);

                   if (model.results.Count()>0){
                        ipath = model.results[0].poster_path;// gets the poster path for the movie
                    }
                    else{
                        ipath = "none";
                    }

                }
            }
            string img= "https://image.tmdb.org/t/p/original" + ipath;
            return img;

        }
   
   
   }
}
