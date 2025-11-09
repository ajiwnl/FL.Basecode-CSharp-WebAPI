using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL.Basecode.Data.Models
{
    [PrimaryKey(nameof(userId))]
    public class mUsers
    {
        public string userId { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int createdAt { get; set; }
        [Required]
        public int lastLogin { get; set; }

        public ICollection<mAccounts> Accounts { get; set; } = new List<mAccounts>();

    }
}
