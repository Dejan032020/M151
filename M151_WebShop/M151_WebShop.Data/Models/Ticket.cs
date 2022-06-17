using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M151_WebShop.Common;

namespace M151_WebShop.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int UserId { get; set; }

        // The two Enums are operations wich you can chause while you create your Ticket
        public Case Case { get; set; }
        public Criticality Criticality { get; set; }
        public string Textarea { get; set; }
    }
}
