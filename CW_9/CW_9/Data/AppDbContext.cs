using CW_9.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9.Data;

public class AppDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set;}
    public DbSet<Doctor> Doctors { get; set;}
    public DbSet<Medicament> Medicaments { get; set;}
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set;}
    public DbSet<Prescription> Prescriptions { get; set;}

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}