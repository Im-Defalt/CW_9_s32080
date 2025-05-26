namespace CW_9.DTOs;

public class PrescriptionGetDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public ICollection<MedicamentGetDTO> Medicaments { get; set; }
    
}