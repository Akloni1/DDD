using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Models
{
    public class Order: IOrder
    {
       
        public int IdOrder {get; set;}
        public string OrderStatus { get; set; }
        public string ListDecoctions { get; set; }
        public string Address { get; set; }

        public int IdOrderRoot { get; set; }

        public virtual OrderRoot OrderRoot { get; set; }
    }
}
