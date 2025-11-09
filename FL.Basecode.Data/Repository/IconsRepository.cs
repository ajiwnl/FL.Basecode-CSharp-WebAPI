using FL.Basecode.Data.Interfaces;
using FL.Basecode.Data.Models;
using FL.Basecode.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FL.Basecode.Data.Repository
{
    public class IconsRepository : iIconsRepository
    {
        private readonly AppDbContext _context;

        public IconsRepository(AppDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<mIcons> AddAsync(mIcons icon)
        {
            // Generate dynamic ID
            int nextNumber = _context.Icons.Count() + 1;
            icon.iconId = IDGenerator.GenerateId("ICON", nextNumber);

            // Encrypt iconUrl
            icon.iconUrl = DataEncrypt.Encrypt(icon.iconUrl);

            _context.Icons.Add(icon);
            await _context.SaveChangesAsync();
            return icon;
        }


        // READ by Id
        public async Task<mIcons> GetByIdAsync(string iconId)
        {
            var icon = await _context.Icons
                .FirstOrDefaultAsync(i => i.iconId == iconId);

            if (icon != null)
            {
                // Decrypt iconUrl
                icon.iconUrl = DataEncrypt.Decrypt(icon.iconUrl);
            }

            return icon;
        }

        // READ all
        public async Task<List<mIcons>> GetAllAsync()
        {
            var icons = await _context.Icons
                .OrderBy(i => i.iconName)
                .ToListAsync();

            // Decrypt all iconUrls
            foreach (var icon in icons)
            {
                icon.iconUrl = DataEncrypt.Decrypt(icon.iconUrl);
            }

            return icons;
        }

        // UPDATE
        public async Task<mIcons> UpdateAsync(mIcons icon)
        {
            var existingIcon = await _context.Icons
                .FirstOrDefaultAsync(i => i.iconId == icon.iconId);

            if (existingIcon == null) return null;

            existingIcon.iconName = icon.iconName;
            existingIcon.iconUrl = DataEncrypt.Encrypt(icon.iconUrl); // encrypt updated url
            existingIcon.updatedAt = icon.updatedAt;

            await _context.SaveChangesAsync();
            return existingIcon;
        }

        // DELETE
        public async Task<bool> DeleteAsync(string iconId)
        {
            var icon = await _context.Icons
                .FirstOrDefaultAsync(i => i.iconId == iconId);

            if (icon == null) return false;

            _context.Icons.Remove(icon);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
