using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.DataAccess.EF.Models
{
    public class Cart //Is a list
    {
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

    }
}
