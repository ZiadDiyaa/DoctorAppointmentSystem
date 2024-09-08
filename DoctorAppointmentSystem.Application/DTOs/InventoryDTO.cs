namespace DoctorAppointmentSystem.Application.DTOs;

public class InventoryDTO
{
    public int InventoryID { get; set; }
    
    public int AdminID { get; set; }  
    
    public string Name { get; set; }
    
    public int MaxQuantity { get; set; }
    
    public int CurrentQuantity { get; set; }
    
    public DateTime LastUpdated { get; set; }
    
}