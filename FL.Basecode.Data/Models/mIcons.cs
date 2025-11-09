using FL.Basecode.Data.Models;
using System.ComponentModel.DataAnnotations;

public class mIcons
{
    [Key]
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
