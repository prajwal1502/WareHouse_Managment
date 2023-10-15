using WareHouse_Managment.Models;

namespace WareHouse_Managment.Service
{
        public interface IClothService
        {
            Task<IEnumerable<Cloth>> GetAllClothesAsync();
            Task<Cloth> GetClothByIdAsync(int id);
            Task AddClothAsync(Cloth cloth);
            Task UpdateClothAsync(Cloth cloth);
            Task DeleteClothAsync(int id);
        }

    
}
