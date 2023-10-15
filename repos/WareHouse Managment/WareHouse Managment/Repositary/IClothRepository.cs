using WareHouse_Managment.Models;

public interface IClothRepository
{
    Task<IEnumerable<Cloth>> GetAllClothesAsync();
    Task<Cloth> GetClothByIdAsync(int id);
    Task AddClothAsync(Cloth cloth);
    Task UpdateClothAsync(Cloth cloth);
    Task DeleteClothAsync(int id);
}