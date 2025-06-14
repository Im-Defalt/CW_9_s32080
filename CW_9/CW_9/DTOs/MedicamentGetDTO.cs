namespace CW_9.DTOs;

public class MedicamentGetDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public ICollection<PrescriptionGetDTO> Prescriptions { get; set; }
}