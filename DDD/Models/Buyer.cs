using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Models
{
    public class Buyer: IBuyer
    {
      
        public int IdBuyer { get; set; }
        public string TypeCard { get; set; }
        public string PaymentMethod { get; set; }
        public int IdBuyerRoot { get; set; }
        public virtual BuyerRoot BuyerRoot { get; set; }
    }
}
