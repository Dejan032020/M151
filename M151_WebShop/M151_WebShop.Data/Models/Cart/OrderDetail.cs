using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M151_WebShop.Data.Models.Cart
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Articles Articles { get; set; }
        public virtual Order Order { get; set; }
    }
}
