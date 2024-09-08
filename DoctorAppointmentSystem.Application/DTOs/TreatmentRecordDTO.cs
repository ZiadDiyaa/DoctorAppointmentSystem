namespace DoctorAppointmentSystem.Application.DTOs;

public class TreatmentRecordDTO
{
    public int TreatmentRecordID { get; set; }

    public int PatientID { get; set; }
    
    public int DoctorID { get; set; }
    
    public DateTime TreatmentDate { get; set; }

    public string TreatmentType{get;set;}
    
    public string TreatmentDetails { get; set; }
}