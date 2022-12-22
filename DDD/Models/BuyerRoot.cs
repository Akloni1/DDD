using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Models
{
    public class BuyerRoot
    {
        public BuyerRoot()
        {
            Buyers = new HashSet<Buyer>();
        }
        public int IdBuyerRoot { get; set; }
        public string Gender { get; set; }
        
        public virtual ICollection<Buyer> Buyers { get; set; }
    }
}
