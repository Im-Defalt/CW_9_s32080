namespace CW_9.DTOs;

public class PatientGetDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public ICollection<DoctorGetDTO> Doctors { get; set; }
}