using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL.Basecode.Data.Models
{
    [PrimaryKey(nameof(iconId))]
    public class mIcons
    {
        public string iconId { get; set; }
        [Required]
        public string iconName { get; set; }
        [Required]
        public string iconUrl { get; set; }
        [Required]
        public int createdAt { get; set; }
        [Required]
        public int updatedAt { get; set; }

        public ICollection<mAccounts> Accounts { get; set; } = new List<mAccounts>();


    }
}
