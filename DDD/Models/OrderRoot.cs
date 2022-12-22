using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Models
{
    public class OrderRoot
    {
        public OrderRoot()
        {
            Orders = new HashSet<Order>();
        }
        public int IdOrderRoot { get; set; }
        public DateTime Date { get; set; }

       

        public virtual ICollection<Order> Orders { get; set; }
    }
}
