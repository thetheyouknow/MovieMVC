using System;
//using System.ComponentModel.DataAnnotations;

//namespace MovieMVCEntities
namespace Packt.Shared
{
    public class Rating
    {
        //[KEY]
        public int RatingID {get;set;}
        public decimal IMDb {get;set;}

        public int RottenTomatoes{get;set;}
        
    }
}
