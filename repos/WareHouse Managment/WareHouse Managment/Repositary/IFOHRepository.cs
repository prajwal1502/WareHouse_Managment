using WareHouse_Managment.Models;

namespace WareHouse_Managment.Repositary
{
    public interface IFOHRepository
    {
        Task<IEnumerable<FOH>> GetAllFOHsAsync();
        Task<FOH> GetFOHByIdAsync(int id);
        Task AddFOHAsync(FOH fOH);
        Task UpdateFOHAsync(FOH fOH);
        Task DeleteFOHAsync(int id);

    }
}