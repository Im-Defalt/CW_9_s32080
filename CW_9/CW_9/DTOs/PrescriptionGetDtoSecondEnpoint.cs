using CW_9.Models;

namespace CW_9.DTOs;

public class PrescriptionGetDtoSecondEndpoint
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<PrescriptionMedicamentGetDtoSecondEndpoint> Medicaments { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;

}