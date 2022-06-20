using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using M151_WebShop.Data.Models.Cart;

namespace M151_WebShop.Presentation.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}