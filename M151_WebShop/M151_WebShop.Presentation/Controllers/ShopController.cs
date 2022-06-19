using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M151_WebShop.Data.Models;
using M151_WebShop.DataAccess;

namespace M151_WebShop.Business.Controllers
{
    public class ShopController : Controller
    {
        [Authorize]
        public ActionResult ShopSite()
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                // creates a list with all articles from the DB 
                ICollection<Articles> articles = context.Articles.Include("User").ToList();
                return View(articles);
            }
        }
        [Authorize]
        public ActionResult CreateArticle()
        {
            Articles articles = new Articles();
            return View(articles);
        }

        //
        // Creates a new Article and add to DB
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle(Articles articles)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                if (!ModelState.IsValid)
                {
                    return View(articles);
                }
                //int userId = Convert.ToInt32(User.Identity.GetUserId());
                //movie.User = context.Users.Find(userId);

                // Adds Article to DB
                context.Articles.Add(articles);
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
                var articles = context.Articles.Include("User").Single(x => x.Id == id);

                return View(articles);
            }
        }

        //
        // Removes the Article from our DB
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteArticle(int articleId)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                // search for the article
                Articles articles = context.Articles.Find(articleId);

                // removes the article from the DB

                context.Articles.Remove(articles);
                context.SaveChanges();

                // Return the View
                return RedirectToAction("ShopSite");
            }
        }
    }
}