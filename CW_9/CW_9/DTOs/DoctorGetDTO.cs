namespace CW_9.DTOs;

public class DoctorGetDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public ICollection<PatientGetDTO> Patients { get; set; }
}