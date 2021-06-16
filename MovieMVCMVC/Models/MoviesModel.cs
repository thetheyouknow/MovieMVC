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
        public IList<Director> DirectorList{get;set;}
        public IList<Genre> Genres{get;set;}
        public List<string> Streamings{get;set;}
        
        public Movie SingleMovie{get;set;}

        [Key]
        public int MovieID{get;set;}
        public string Title{get;set;}
        public int Runtime{get;set;}
        public string DirectorName;

        public int DirectorID;
        
        public string Image{get;set;}

        public List<string> Links{get;set;}
        public string Description{get;set;}
        public string GenreName{get;set;}
        


        



    }
}


/*
<img src="@Model.Image" alt="Sample Image" width="300px" />
            <h3>Movie Title </br></h3>
            <dd>@Model.SingleMovie.Title </dd>
            <h3> Movie Director</h3>
            <dd>
                <a asp-controller = "Movies"
                    asp-action = "MoviesForADirector"
                    asp-route-id = "@Model.DirectorID">
                    @Model.DirectorName</br>
                </a>
            </dd>
            <h3> Runtime</h3>
            <dd>@Model.SingleMovie.Runtime</dd>
            <h3> Image</h3>
            <h3></h3>*/