using CW_9.Data;
using CW_9.DTOs;
using CW_9.Exceptions;
using CW_9.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9.Services;


public interface IDbService
{
    public Task<PrescriptionGetDTO> CreatePrescriptionAsync(PrescriptionCreateDTO prescriptionData);
    public Task<PatientGetDtoSecondEnpoint> GetPatientDetailsAsync(int id);
}

public class DbService(AppDbContext data) : IDbService
{
    public async Task<PrescriptionGetDTO> CreatePrescriptionAsync(PrescriptionCreateDTO prescriptionData)
    {
        
        Patient? patient = await data.Patients.FirstOrDefaultAsync(e => e.IdPatient == prescriptionData.Patient.IdPatient);
        

        if (prescriptionData.Date >= prescriptionData.DueDate)
        {
            throw new DateException("Prescription date cannot be greater than due date");
        }
        
        List<Medicament> medicaments = [];
        foreach (PreMedCreateDTO pm in prescriptionData.PreMed)
        {
            Medicament? tmp = await data.Medicaments.FirstOrDefaultAsync(e => e.IdMedicament == pm.IdMedicament);

            if (tmp == null)
            {
                throw new NotFoundException($"Medicament {pm.IdMedicament} not found.");
            }
            medicaments.Add(tmp);
            
        }
        
        
        var prescription = new Prescription
        {
            Date = prescriptionData.Date,
            DueDate = prescriptionData.DueDate,
            Patient = (patient is null) ? new Patient()
            {
                FirstName = prescriptionData.Patient.FirstName,
                LastName = prescriptionData.Patient.LastName,
                Birthdate = prescriptionData.Patient.Birthdate,
                
            } : patient,
            IdDoctor = prescriptionData.IdDoctor,
            PrescriptionMedicaments = (prescriptionData.PreMed ?? []).Select(preMed =>
                new PrescriptionMedicament()
                {
                    IdMedicament = preMed.IdMedicament,
                    Dose = preMed.Dose,
                    Details = preMed.Details
                    
                }).ToList(),
        };
        
        await data.Prescriptions.AddAsync(prescription);
        await data.SaveChangesAsync();


        return new PrescriptionGetDTO
        {
            IdPrescription = prescription.IdPrescription,
            Date = prescriptionData.Date,
            DueDate = prescriptionData.DueDate,
            IdPatient = prescriptionData.Patient.IdPatient,
            IdDoctor = prescriptionData.IdDoctor,
            Medicaments = medicaments.Select(medicament => new MedicamentGetDTO
            {
                IdMedicament = medicament.IdMedicament,
                Name = medicament.Name,
                Description = medicament.Description,
                Type = medicament.Type,
            }).ToList()
        };


    }

    public async Task<PatientGetDtoSecondEnpoint> GetPatientDetailsAsync(int id)
    {
        Patient? patientRead = await data.Patients.FirstOrDefaultAsync(e => e.IdPatient == id);

        if (patientRead == null)
        {
            throw new NotFoundException($"Patient {id} not found.");
        }
        
        var result = await data.Patients.Select(pt => new PatientGetDtoSecondEnpoint()
        {
            IdPatient = pt.IdPatient,
            FirstName = pt.FirstName,
            LastName = pt.LastName,
            Birthdate = pt.Birthdate,
            Prescriptions = pt.Prescriptions.Select(presc => new PrescriptionGetDtoSecondEndpoint()
            {
                IdPrescription = presc.IdPrescription,
                Date = presc.Date,
                DueDate = presc.DueDate,
                Medicaments = presc.PrescriptionMedicaments.Select(premed => new PrescriptionMedicamentGetDtoSecondEndpoint
                {
                    IdMedicament = premed.IdMedicament,
                    Dose = (premed.Dose == null) ? null : premed.Dose,
                    Details = premed.Details
                    
                }).ToList(),
                Doctor = presc.Doctor
            }).ToList(),
        }).FirstOrDefaultAsync();
        
        return result ?? throw new NotFoundException($"Patient {id} not found.");
    }
    
}