using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class Inventory
{
    public int InventoryID { get; set; }
    [Required]
    public int AdminID { get; set; }  
    
    public virtual Admin Admin { get; set; }
    [Required]
    public DateTime LastUpdated { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int MaxQuantity { get; set; }
    [Required]
    public int CurrentQuantity { get; set; }
    
    public virtual ICollection<Consumable> Consumables { get; set; }
}