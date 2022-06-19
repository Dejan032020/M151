using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M151_WebShop.Data.Models.Cart
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ArticleId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Articles Articles { get; set; }
    }
}
