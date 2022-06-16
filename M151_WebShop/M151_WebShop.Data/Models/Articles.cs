using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M151_WebShop.Data.Models
{
    public class Articles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // The Enums are operations wich you can chause while you create your Movie
        public Genre Genre { get; set; }
        public USK USK { get; set; }
        public Condition Condition { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}