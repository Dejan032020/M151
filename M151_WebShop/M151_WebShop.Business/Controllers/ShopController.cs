using M151_WebShop.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M151_WebShop.Controllers
{
    public class ShopController : Controller
    {
        [Authorize]
        public ActionResult ShopSite()
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                // creates a list with all articles from the DB 
                ICollection<Movie> movies = context.Movies.Include("User").ToList();
                return View(movies);
            }
        }
        [Authorize]
        public ActionResult CreateArticle()
        {
            Movie movies = new Movie();
            return View(movies);
        }

        //
        // Creates a new Article and add to DB
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle(Movie movie)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                if (!ModelState.IsValid)
                {
                    return View(movie);
                }
                //int userId = Convert.ToInt32(User.Identity.GetUserId());
                //movie.User = context.Users.Find(userId);

                // Adds Article to DB
                context.Movies.Add(movie);
                context.SaveChanges();

                // Go back to the main page
                return RedirectToAction("ShopSite");
            }
        }

        //
        // Adds a new View to view a single Article
        public ActionResult GetArticle(int id)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                var movie = context.Movies.Include("User").Single(x => x.Id == id);

                return View(movie);
            }
        }

        //
        // Removes the Article from our DB
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteArticle(int movieId)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                // search for the article
                Movie movie = context.Movies.Find(movieId);

                // removes the article from the DB

                context.Movies.Remove(movie);
                context.SaveChanges();

                // Return the View
                return RedirectToAction("ShopSite");
            }
        }
    }
}