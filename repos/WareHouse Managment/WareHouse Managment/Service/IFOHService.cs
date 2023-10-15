using WareHouse_Managment.Models;

namespace WareHouse_Managment.Service
{
    public interface IFOHService
    {
        Task<IEnumerable<FOH>> GetAllFOHsAsync();
        Task<FOH> GetFOHByIdAsync(int id);
        Task AddFOHAsync(FOH fOH);
        Task UpdateFOHAsync(FOH fOH);
        Task DeleteFOHAsync(int id);
    }
}
