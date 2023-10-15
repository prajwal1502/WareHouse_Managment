using WareHouse_Managment.Models;
using WareHouse_Managment.Repositary;

namespace WareHouse_Managment.Service
{
    public class FOHService : IFOHService
    {
        private readonly IFOHRepository _fohRepository;

        public FOHService(IFOHRepository fohRepository)
        {
            _fohRepository = fohRepository;
        }

        public async Task<IEnumerable<FOH>> GetAllFOHsAsync()
        {
            return await _fohRepository.GetAllFOHsAsync();
        }

        public async Task<FOH> GetFOHByIdAsync(int id)
        {
            return await _fohRepository.GetFOHByIdAsync(id);
        }

        public async Task AddFOHAsync(FOH fOH)
        {
            await _fohRepository.AddFOHAsync(fOH);
        }

        public async Task UpdateFOHAsync(FOH fOH)
        {
            await _fohRepository.UpdateFOHAsync(fOH);
        }

        public async Task DeleteFOHAsync(int id)
        {
            await _fohRepository.DeleteFOHAsync(id);
        }
    }

}
