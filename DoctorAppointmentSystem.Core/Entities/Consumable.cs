using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class Consumable
{
    public int ConsumableID { get; set; }
    [Required]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Category { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }
    [Required]
    public int QuantityInStock { get; set; }
    
    public int ThresholdQuantity { get; set; }
    [Required]
    public DateTime DateAdded { get; set; }
    
    public DateTime? ExpirationDate { get; set; }
    
    public string Barcode { get; set; }
    [Required]
    public int InventoryID { get; set; }
    
    public virtual Inventory Inventory { get; set; }
    
}