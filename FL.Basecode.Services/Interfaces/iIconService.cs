using FL.Basecode.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FL.Basecode.Services.Interfaces
{
    public interface iIconService
    {
        // Create
        Task<mIcons> CreateIconAsync(mIcons icon);

        // Read
        Task<mIcons> GetIconByIdAsync(string iconId);
        Task<List<mIcons>> GetAllIconsAsync();

        // Update
        Task<mIcons> UpdateIconAsync(mIcons icon);

        // Delete
        Task<bool> DeleteIconAsync(string iconId);
    }
}
