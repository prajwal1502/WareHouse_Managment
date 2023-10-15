using Microsoft.EntityFrameworkCore;
using WareHouse_Managment.Data;
using WareHouse_Managment.Models;

namespace WareHouse_Managment.Repositary
{
    public class FOHRepository : IFOHRepository
    {
        private readonly WareHouse_ManagmentContext _context;

        public FOHRepository(WareHouse_ManagmentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FOH>> GetAllFOHsAsync()
        {
            return await _context.FOH.ToListAsync();
        }

        public async Task<FOH> GetFOHByIdAsync(int id)
        {
            return await _context.FOH.FindAsync(id);
        }

        public async Task AddFOHAsync(FOH fOH)
        {
            _context.FOH.Add(fOH);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFOHAsync(FOH fOH)
        {
            _context.Entry(fOH).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFOHAsync(int id)
        {
            var fOH = await _context.FOH.FindAsync(id);
            if (fOH != null)
            {
                _context.FOH.Remove(fOH);
                await _context.SaveChangesAsync();
            }
        }
    }
}
