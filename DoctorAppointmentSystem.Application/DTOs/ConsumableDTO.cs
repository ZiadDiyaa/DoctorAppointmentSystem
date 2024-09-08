namespace DoctorAppointmentSystem.Application.DTOs;

public class ConsumableDTO
{
    public int ConsumableID { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Category { get; set; }
    
    public decimal UnitPrice { get; set; }
    
    public int QuantityInStock { get; set; }
    
    public int ThresholdQuantity { get; set; }
    
    public DateTime DateAdded { get; set; }
    
    public DateTime? ExpirationDate { get; set; }
    
    public string Barcode { get; set; }
    
    public int InventoryID { get; set; }
    
}