using Microsoft.EntityFrameworkCore;
using WareHouse_Managment.Data;
using WareHouse_Managment.Models;

namespace WareHouse_Managment.Repositary
{
    public class BOHRepository : IBOHRepository
    {
        private readonly WareHouse_ManagmentContext _context;

        public BOHRepository(WareHouse_ManagmentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BOH>> GetAllBOHsAsync()
        {
            return await _context.BOH.ToListAsync();
        }

        public async Task<BOH> GetBOHByIdAsync(int id)
        {
            return await _context.BOH.FindAsync(id);
        }

        public async Task AddBOHAsync(BOH bOH)
        {
            _context.BOH.Add(bOH);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBOHAsync(BOH bOH)
        {
            _context.Entry(bOH).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBOHAsync(int id)
        {
            var bOH = await _context.BOH.FindAsync(id);
            if (bOH != null)
            {
                _context.BOH.Remove(bOH);
                await _context.SaveChangesAsync();
            }
        }

    }
}