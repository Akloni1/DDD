using DDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Repository.BuyerRepository
{
    internal interface IBuyerRepository
    {
        Task<IBuyer> GetBuyer(int id);
        Task<IEnumerable<IBuyer>> GetAllBuyers();
        Task<IBuyer> AddBuyer(IBuyer inputModel, BuyerRoot buyerRoot);
        Task<IBuyer> UpdateBuyer(int id, IBuyer editModel);
        Task<IBuyer> DeleteBuyer(int id);
    }
}
