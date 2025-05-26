namespace CW_9.DTOs;

public class PrescriptionMedicamentGetDTO
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}