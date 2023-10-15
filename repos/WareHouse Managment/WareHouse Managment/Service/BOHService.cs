using WareHouse_Managment.Models;
using WareHouse_Managment.Repositary;

namespace WareHouse_Managment.Service
{
    public class BOHService : IBOHService
    {
        private readonly IBOHRepository _bohRepository;

        public BOHService(IBOHRepository bohRepository)
        {
            _bohRepository = bohRepository;
        }

        public async Task<IEnumerable<BOH>> GetAllBOHsAsync()
        {
            return await _bohRepository.GetAllBOHsAsync();
        }

        public async Task<BOH> GetBOHByIdAsync(int id)
        {
            return await _bohRepository.GetBOHByIdAsync(id);
        }

        public async Task AddBOHAsync(BOH bOH)
        {
            await _bohRepository.AddBOHAsync(bOH);
        }

        public async Task UpdateBOHAsync(BOH bOH)
        {
            await _bohRepository.UpdateBOHAsync(bOH);
        }

        public async Task DeleteBOHAsync(int id)
        {
            await _bohRepository.DeleteBOHAsync(id);
        }

        internal static Task AddBOHAsync(object bohItem)
        {
            throw new NotImplementedException();
        }
    }
}