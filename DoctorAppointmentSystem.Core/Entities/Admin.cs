using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppointmentSystem.Core.Entities;

public class Admin
{
    public int AdminID { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]

    public string LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]

    public string Email { get; set; }
    [Required]

    public string PhoneNumber { get; set; }
    [Required]

    public int AccountID { get; set; }
    
    public virtual AccountDetails Account { get; set; }
   [ForeignKey("PracticeID")]

    public int PracticeID { get; set; }
    [InverseProperty("Admin")]
    public  virtual DoctorPractice Practice { get; set; }
    [Required]
    public int InventoryID { get; set; }
    public virtual Inventory Inventory { get; set; }
}