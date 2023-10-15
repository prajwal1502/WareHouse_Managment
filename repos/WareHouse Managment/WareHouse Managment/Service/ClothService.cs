using WareHouse_Managment.Models;

namespace WareHouse_Managment.Service
{
    public class ClothService : IClothService
    {
        private readonly IClothRepository _clothRepository;

        public ClothService(IClothRepository clothRepository)
        {
            _clothRepository = clothRepository;
        }

        public async Task<IEnumerable<Cloth>> GetAllClothesAsync()
        {
            return await _clothRepository.GetAllClothesAsync();
        }

        public async Task<Cloth> GetClothByIdAsync(int id)
        {
            return await _clothRepository.GetClothByIdAsync(id);
        }

        public async Task AddClothAsync(Cloth cloth)
        {
            await _clothRepository.AddClothAsync(cloth);
        }

        public async Task UpdateClothAsync(Cloth cloth)
        {
            await _clothRepository.UpdateClothAsync(cloth);
        }

        public async Task DeleteClothAsync(int id)
        {
            await _clothRepository.DeleteClothAsync(id);
        }
    }

}
