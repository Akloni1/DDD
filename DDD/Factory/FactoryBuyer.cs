using DDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Factory
{
    public class FactoryBuyer
    {
        public static IBuyer CreateBuyer(string type)
        {
            if (type.Equals("Покупатель"))
            {
                return new Buyer();
            }
            else return null;
        }
    }
}
