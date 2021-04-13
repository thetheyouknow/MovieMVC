using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;

using Microsoft.AspNetCore.Mvc;

namespace MovieMVCWeb.Pages
{
  public class SuppliersModel : PageModel
  {
           public IEnumerable<string> Suppliers { get; set; }

           [BindProperty]
           public Genre Genre{get;set;}

        ////////////////can use form submit and validation for a watchlist
          public IActionResult OnPost(){
            if(ModelState.IsValid){
              db.Genre.Add(Genre);
              db.SaveChanges();
              return RedirectToPage("/genres");
            }
            return Page();
          }



           private MovieMVC db;

           public SuppliersModel(MovieMVC injectedContext){
             db = injectedContext;
           }
           public void OnGet()
           {
             ViewData["Title"] = "Something Tab heading";
             Suppliers = db.Genre.Select(g => g.GenreName);
             //Suppliers = db.Ratings.Select(r => r.RatingsID);
             /*Suppliers = new[] {
               "Alpha Co", "Beta Limited", "Gamma Corp"
              };*/
            }
  } 
}
