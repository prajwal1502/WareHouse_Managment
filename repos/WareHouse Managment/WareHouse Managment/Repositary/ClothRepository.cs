// ClothRepository.cs
using Microsoft.EntityFrameworkCore;
using WareHouse_Managment.Data;
using WareHouse_Managment.Models;

public class ClothRepository : IClothRepository
{
    private readonly WareHouse_ManagmentContext _context;

    public ClothRepository(WareHouse_ManagmentContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cloth>> GetAllClothesAsync()
    {
        return await _context.Cloth.ToListAsync();
    }

    public async Task<Cloth> GetClothByIdAsync(int id)
    {
        return await _context.Cloth.FindAsync(id);
    }

    public async Task AddClothAsync(Cloth cloth)
    {
        _context.Cloth.Add(cloth);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateClothAsync(Cloth cloth)
    {
        _context.Entry(cloth).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClothAsync(int id)
    {
        var cloth = await _context.Cloth.FindAsync(id);
        if (cloth != null)
        {
            _context.Cloth.Remove(cloth);
            await _context.SaveChangesAsync();
        }
    }
}
