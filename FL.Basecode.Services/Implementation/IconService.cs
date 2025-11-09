using FL.Basecode.Data.Interfaces;
using FL.Basecode.Data.Models;
using FL.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FL.Basecode.Services.Implementation
{
    public class IconService : iIconService
    {
        private readonly iIconsRepository _iconsRepository;

        public IconService(iIconsRepository iconsRepository)
        {
            _iconsRepository = iconsRepository;
        }

        // CREATE
        public async Task<mIcons> CreateIconAsync(mIcons icon)
        {
            // Set timestamps
            int now = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            icon.createdAt = now;
            icon.updatedAt = now;

            return await _iconsRepository.AddAsync(icon);
        }

        // READ by ID
        public async Task<mIcons> GetIconByIdAsync(string iconId)
        {
            return await _iconsRepository.GetByIdAsync(iconId);
        }

        // READ all
        public async Task<List<mIcons>> GetAllIconsAsync()
        {
            return await _iconsRepository.GetAllAsync();
        }

        // UPDATE
        public async Task<mIcons> UpdateIconAsync(mIcons icon)
        {
            // Update timestamp
            icon.updatedAt = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            return await _iconsRepository.UpdateAsync(icon);
        }

        // DELETE
        public async Task<bool> DeleteIconAsync(string iconId)
        {
            return await _iconsRepository.DeleteAsync(iconId);
        }
    }
}
