using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppointmentSystem.Core.Entities;

public class DoctorPractice
{
    [Key,Required]
    public int PracticeID { get; set; }
    [Required]

    public string Name { get; set; }
    [Required]
    public string City { get; set; }
    
    public string Area { get; set; }
    [Required]

    public string Address { get; set; }
    [Required]

    public string PostalCode { get; set; }
    [Required]

    public string PhoneNumber { get; set; }
    [ForeignKey("AdminID")]
    public int AdminID { get; set; }
    [InverseProperty("Practice")]
    public virtual Admin Admin { get; set; }
    
    public virtual ICollection<DoctorPracticeAssignment> DoctorPracticeAssignments { get; set; }
}