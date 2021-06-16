using System.Collections.Generic;
using Packt.Shared;

namespace MovieMVCMVC.Models{
    public class HomeIndexViewModel{
        //public int VisitorCount;
        public IList<Genre> Genres{get;set;}

        public IList<Language> Languages{get;set;}

        public IList<Movie> Movies{get;set;}

        public List<string> Links{get;set;}

        public List<int> Ratings{get;set;}



    }
}