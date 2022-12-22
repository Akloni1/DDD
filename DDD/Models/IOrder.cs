using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Models
{
    public interface IOrder
    {
        public int IdOrder { get; set; }
        public string OrderStatus { get; set; }
        public string ListDecoctions { get; set; }
        public string Address { get; set; }
    }
}
