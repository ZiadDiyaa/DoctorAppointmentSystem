using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class TreatmentRecord
{
    public int TreatmentRecordID { get; set; }
    [Required]

    public int PatientID { get; set; }
    
    public virtual Patient Patient { get; set; }
    [Required]

    public int DoctorID { get; set; }
    
    public virtual Doctor Doctor { get; set; }
    [Required]

    public DateTime TreatmentDate { get; set; }
    [Required]

    public string TreatmentType{get;set;}
    
    public string TreatmentDetails { get; set; }
}