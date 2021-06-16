using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMVCMVC.Models;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MovieMVCMVC.Controllers
{
    public class MoviesController : Controller
    {
        private MovieMVC db;
        public MoviesController(MovieMVC injectedContext)
        {
            db = injectedContext;
        }

        public IActionResult Index(int page = 0){  //each movie at index calls the details method

            const int PageSize = 20;
            var movies = from m in db.Movies select m;
            int count = movies.Count();
            var data = movies.OrderBy(o => o.MovieID).Skip(page * PageSize).Take(PageSize).ToList(); //get 20 results per page

            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            ViewBag.Page = page;
            List<string> s = new List<string>();

            foreach( var m in data){
                s.Add((getImage(m.Title).Result));
            };

            var model = new MoviesModel{
                statement  = "This is my random statement",
                //Movie = db.Movies.ToList(),//??????????????????????????? :(((((
                Movie = data.ToList(),
                Links = s
            };
            return View(model);
        }

        public List<string> StreamingServices(int id){
            var record = (from s in db.Streamings where s.StreamingID == id select s).Single();
            
            List<int> available = new List<int>();
            available.Append(record.Netflix);
            available.Append(record.Hulu);
            available.Append(record.PrimeVideo);
           

            List<string> urls = new List<string>();
            urls.Append("https://www.freepnglogos.com/uploads/netflix-logo-0.png");
            urls.Append("https://download.logo.wine/logo/Hulu/Hulu-Logo.wine.png");
            urls.Append("https://logodownload.org/wp-content/uploads/2018/07/prime-video-2.png");
           
            List<string> images = new List<string>();
            int count = 0;
            foreach( int item in available){
                    if(item!=0)
                        images.Append(urls[count]);
                    count++;
            }
        return urls;
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

        public async Task<string> getDesc(string title){
            string dpath;

            var baseAddress = new Uri("http://api.themoviedb.org/3/");
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {     
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var response = await httpClient.GetAsync("search/movie?api_key=8952d55f994145a828d53d9ee73af551&query=" + title))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<original>(responseData);
                    if (model.results.Count()>0){
                        dpath = model.results[0].overview;// gets the description for the movie
                    }
                    else{
                        dpath = "no description available";
                    }

                }
            }
            return dpath;

        }
        public IActionResult Details(int? id) {
            var rs = (from d in db.MovieDirectors
                where(d.MovieID==id)
                select d.DirectorID).FirstOrDefault();//if no director, then default value=0


            var tt = (from m in db.Movies
                where(m.MovieID==id)
                select m.Title).FirstOrDefault();

            if (rs!=0){
                var rr = (from f in db.Directors
                where f.DirectorID == rs
                select f.DirectorName).Single();

                var m = new MoviesModel{
                    SingleMovie= db.Movies.SingleOrDefault(m => m.MovieID == id),
                    DirectorName = rr,
                    DirectorID = rs,
                    Image = getImage(tt).Result,
                    Description = getDesc(tt).Result
                };
                
                return View(m); // pass model to view and then return result
            }

            var NoDirector = new MoviesModel{
                    SingleMovie= db.Movies.SingleOrDefault(m => m.MovieID == id),
                    Image = getImage(tt).Result,
                    Description = getDesc(tt).Result
                }; 


            
            return View(NoDirector);
        }

        public IActionResult MoviesForADirector(int? id){//shows all the movies for a director; directorid
            var query = (from m in db.MovieDirectors //connects directors and movies
                        where m.DirectorID==id
                        select m.MovieID);

            List<Movie> mm = new List<Movie>();
            foreach( int i in query){
                mm.Add(
                    (from mo in db.Movies
                    where mo.MovieID==i
                    select mo).Single()
                );
            }
            ViewData["dir"] = (from d in db.Directors
                            where d.DirectorID==id
                            select d.DirectorName).Single();

            List<string> s = new List<string>();
            foreach( var m in mm){
                s.Add((getImage(m.Title).Result));
            };

            ViewBag.Images = s;
            return View(mm);
        }

        public IActionResult GenreSorting(int? id){//click on genre in dropdown and lists movies for it
            var query =  from g in db.MovieGenres
                        where g.GenreID==id
                        select g.MovieID;

            List<Movie> m = new List<Movie>();
            foreach(var v in query){
                m.Add((from mm in db.Movies
                        where mm.MovieID==v
                        select mm).Single());
            }
            ViewData["mGenre"] = (from g in db.Genres
                            where g.GenreID==id
                            select g.GenreName).Single();
            return View(m); 

        }
        public IActionResult LanguageSorting(int? id){
            var query =  from l in db.MovieLanguages
                        where l.LanguageID==id
                        select l.MovieID;

            List<Movie> m = new List<Movie>();
            foreach(var ll in query){
                m.Add((from mm in db.Movies
                        where mm.MovieID==ll
                        select mm).Single());
            }

            ViewData["Language"] = (from ll in db.Languages
                            where ll.LanguageID==id
                            select ll.LanguageName).Single();
            return View(m); 

        }
        public IActionResult MovieSearch(string name){
            var movies = (from m in db.Movies
                            where (EF.Functions.Like(m.Title, $"%{name}%"))
                            select m);
            
            if (movies.Count() == 0) {
                return NotFound($"Sorry, no movies of that title could be found");
            }

            List<string> s = new List<string>();

            foreach( var m in movies){
                s.Add((getImage(m.Title).Result));
            };

            ViewBag.Images = s;
            ViewData["search"] = name;

            return View(movies);
        }
    
        [HttpPost]
        public IActionResult Create(MoviesModel model, string DirectorChoice){ 

            List<Movie> li = db.Movies.ToList(); var item = li[li.Count - 1].MovieID;

            Movie m = new Movie();
            m.Title = model.Title;
            m.Runtime = model.Runtime;
            m.MovieID = item +1;
            db.Movies.Add(m);
            db.SaveChanges();

            int dID = Int32.Parse(DirectorChoice);
            MovieDirector d   = new MovieDirector();
            d.MovieID = item +1;
            d.DirectorID = dID;

            db.MovieDirectors.Add(d);
            db.SaveChanges();

            
            return Index();
        }
        public IActionResult CreateButton(){
            List<Movie> li = db.Movies.ToList();
            var item = li[li.Count - 1].MovieID;

            ViewData["nextID"] = item+1;
            return View("Create", new MoviesModel{ DirectorList = db.Directors.ToList()});
        }

        public IActionResult DeleteButton(int? id){//click the delete button and get directed to page with confirmation
            var movie = db.Movies
                .FirstOrDefault(m => m.MovieID == id);
            var dir = (from m in db.Movies where m.MovieID==id
                    join d in db.MovieDirectors on m.MovieID equals d.MovieID
                    join dd in db.Directors on d.DirectorID equals dd.DirectorID
                    select dd.DirectorName).ToList().DefaultIfEmpty(string.Empty).First();

            
            return View("Delete", new MoviesModel{SingleMovie = movie, DirectorName = dir});
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int? id){//delete the actual record

            var moviedir = (from d in db.MovieDirectors
                        where(d.MovieID==id)
                        select d.DirectorID).FirstOrDefault();

            if(moviedir!=0){
                var dir = (from d in db.MovieDirectors
                        where(d.MovieID==id)
                        select d).Single();
                 db.MovieDirectors.Remove(dir);
            }

            var movie = (from m in db.Movies //remove movie record last
                        where(m.MovieID==id)
                        select m).Single();

            db.Movies.Remove(movie);
            db.SaveChanges();

            List<string> s = new List<string>();

            foreach( var m in db.Movies){
                s.Add((getImage(m.Title).Result));
            }; 

            return View("Index", new MoviesModel{Movie = db.Movies.ToList(), Links = s});

        }

    }

}