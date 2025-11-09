using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL.Basecode.Data.Models
{
    [PrimaryKey(nameof(acctId))]
    public class mAccounts
    {
        public string acctId { get; set; }
        [Required]
        public string userId { get; set; }
        public mUsers Users { get; set; } 

        [Required]
        public string name { get; set; }
        [Required]
        public string initialBalance { get; set; }
        [Required]
        public string currentBalance { get; set; }
        [Required]
        public string iconId { get; set; }
        public mIcons Icons { get; set; }

        [Required]
        public bool isActive { get; set; }
        [Required]
        public int createdAt { get; set; }
        [Required]
        public int updatedAt { get; set; }


    }
}
