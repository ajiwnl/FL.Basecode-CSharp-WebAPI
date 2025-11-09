using FL.Basecode.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FL.Basecode.Data.Interfaces
{
    public interface iIconsRepository
    {
        // Create
        Task<mIcons> AddAsync(mIcons icon);

        // Read
        Task<mIcons> GetByIdAsync(string iconId);
        Task<List<mIcons>> GetAllAsync();

        // Update
        Task<mIcons> UpdateAsync(mIcons icon);

        // Delete
        Task<bool> DeleteAsync(string iconId);
    }
}
