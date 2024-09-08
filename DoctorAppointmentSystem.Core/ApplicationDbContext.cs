using System.Net;
using DoctorAppointmentSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentSystem.Core;

public class ApplicationDbContext: DbContext
{

    // public ApplicationDbContext()
    // {
    //     
    // }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<AccountDetails> AccountDetails { get; set; }
    
    public DbSet<Admin> Admins { get; set; }
    
    public DbSet<Appointment> Appointments { get; set; }
    
    public DbSet<Consumable> Consumables { get; set; }
    
    public DbSet<Doctor> Doctors { get; set; }
    
    public DbSet<DoctorPractice> DoctorPractices { get; set; }
    
    public DbSet<Inventory> Inventories { get; set; }
    
    public DbSet<Patient> Patients { get; set; }
    
    public DbSet<TimeSlot> TimeSlots { get; set; }
    
    public DbSet<TreatmentRecord> TreatmentRecords { get; set; }
    
    public DbSet<DoctorPracticeAssignment> DoctorPracticeAssignments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Admin>()
            .HasOne(a => a.Practice)
            .WithOne(p => p.Admin)
            .HasForeignKey<DoctorPractice>(p => p.AdminID);
        
        modelBuilder.Entity<Admin>()
            .HasOne(a=>a.Inventory)
            .WithOne(i=>i.Admin)
            .HasForeignKey<Inventory>(i=>i.AdminID);
            
            
    }
}