using WareHouse_Managment.Models;

namespace WareHouse_Managment.Repositary
{
    public interface IBOHRepository
    {
        Task<IEnumerable<BOH>> GetAllBOHsAsync();
        Task<BOH> GetBOHByIdAsync(int id);
        Task AddBOHAsync(BOH bOH);
        Task UpdateBOHAsync(BOH bOH);
        Task DeleteBOHAsync(int id);
    }
}
