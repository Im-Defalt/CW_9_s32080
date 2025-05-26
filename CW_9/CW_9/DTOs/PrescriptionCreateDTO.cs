using System.ComponentModel.DataAnnotations;
using CW_9.Models;

namespace CW_9.DTOs;

public class PrescriptionCreateDTO
{
    [Required]
    public PatientTmpGetDTO Patient { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public int IdDoctor { get; set; }
    
    [Required]
    [MaxLength(10)]
    public ICollection<PreMedCreateDTO> PreMed { get; set; }
}

public class PatientTmpGetDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}

public class PreMedCreateDTO
{
    [Required]
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    
    
    [Required]
    [MaxLength(100)]
    public string Details {get; set; }
}