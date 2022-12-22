using DDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Factory
{
    public class FactoryOrder
    {
        public static IOrder CreateOrder(string type)
        {
            if (type.Equals("Заказ"))
            {
                return new Order();
            }
            else return null;
        }
    }
}
