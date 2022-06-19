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
    public class SupportController : Controller
    {
        // GET: Support
        //
        // Because of the [Authorize] only users who have been signed in can acces this page
        [Authorize]
        public ActionResult SupportView()
        {
            Ticket ticket = new Ticket();
            return View(ticket);
        }

        //
        // Only Users with Administrator role can acces the Ticket overview
        [Authorize(Roles = "Administrator")]
        public ActionResult TicketOverview()
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                // Creates a list with Tickets 
                ICollection<Ticket> tickets = context.Tickets.Include("User").ToList();
                return View(tickets);
            }
        }

        //
        // Creates a new Ticket 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CreateTicket(Ticket ticket)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                if (!ModelState.IsValid)
                {
                    return View(ticket);
                }
                int userId = Convert.ToInt32(User.Identity.GetUserId());
                ticket.User = context.Users.Find(userId);

                // Adds Ticket to DB
                context.Tickets.Add(ticket);
                context.SaveChanges();

                // Go back to the support page 
                return RedirectToAction("SupportView");
            }
        }

        //
        // Removes Tickets from DB
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteTicket(int ticketId)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                // searches the Ticket in the DB
                Ticket ticket = context.Tickets.Find(ticketId);

                // Removes the Ticket from the DB
                context.Tickets.Remove(ticket);
                context.SaveChanges();

                // Go back to the ticket overview
                return RedirectToAction("TicketOverview");
            }
        }
    }
}