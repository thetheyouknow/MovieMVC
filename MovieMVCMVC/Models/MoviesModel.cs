using System.Collections.Generic;
using Packt.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieMVCMVC.Models{
    public class MoviesModel{
        public string statement{get;set;}
        public IList<Movie> Movie {get;set;}
        public IList<MovieDirector> MovieDirector {get;set;}
        public string DirectorName;
        public int DirectorID;
        public Movie SingleMovie{get;set;}

        [Key]
        public int MovieID{get;set;}
        public string Title{get;set;}
        public int Runtime{get;set;}


    }
}
