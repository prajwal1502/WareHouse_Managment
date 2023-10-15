using WareHouse_Managment.Controllers;
using WareHouse_Managment.Models;

namespace WareHouse_Managment.Service
{
    public interface IBOHService
    {
        Task<IEnumerable<BOH>> GetAllBOHsAsync();
        Task<BOH> GetBOHByIdAsync(int id);
        Task AddBOHAsync(BOH bOH);
        Task UpdateBOHAsync(BOH bOH);
        Task DeleteBOHAsync(int id);
        //Task AddBOHAsync(int id);
        // Task AddBOHAsync(BOHDto bohDto);
    }
}
