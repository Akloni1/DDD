using DDD.Data;
using DDD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Repository.BuyerRepository
{
    internal class BuyerRepository: IBuyerRepository
    {
       
        private readonly DDDContext _context;

        public BuyerRepository(DDDContext context)
        {
            _context = context;
        }



        public async Task<IBuyer> GetBuyer(int id)
        {
            var Buyer = await _context.Buyers.FirstOrDefaultAsync(m => m.IdBuyer == id);
            return Buyer;
        }

        public async Task<IEnumerable<IBuyer>> GetAllBuyers()
        {
            var Buyer = await _context.Buyers.ToListAsync();
            return Buyer;
        }



        public async Task<IBuyer> AddBuyer(IBuyer inputModel, BuyerRoot buyerRoot)
        {

            var buyerRootAdded = _context.BuyersRoot.Add(buyerRoot).Entity;
            await _context.SaveChangesAsync();
            inputModel.IdBuyerRoot = buyerRootAdded.IdBuyerRoot;
            var buyerAdded = _context.Add(inputModel).Entity;
            await _context.SaveChangesAsync();

            return buyerAdded;

        }



        public async Task<IBuyer> UpdateBuyer(int id, IBuyer editModel)
        {
            try
            {
                var Buyer = editModel;
                Buyer.IdBuyer = id;

                _context.Update(Buyer);
                await _context.SaveChangesAsync();

                return Buyer;
            }
            catch (DbUpdateException)
            {
                if (!await BuyerExists(id))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }



        public async Task<IBuyer> DeleteBuyer(int id)
        {
            var Buyer = await _context.Buyers.FindAsync(id);

            if (Buyer == null) return null;
            var BuyersRoot = await _context.BuyersRoot.FindAsync(id);
            _context.BuyersRoot.Remove(BuyersRoot);
            await _context.SaveChangesAsync();
            _context.Buyers.Remove(Buyer);
            await _context.SaveChangesAsync();

            return Buyer;
        }


        private async Task<bool> BuyerExists(int id)
        {
            return await _context.Buyers.AnyAsync(e => e.IdBuyer == id);
        }



    }
}
