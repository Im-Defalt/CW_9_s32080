using CW_9.DTOs;
using CW_9.Exceptions;
using CW_9.Models;
using CW_9.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_9.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IDbService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionCreateDTO prescriptionData)
    {
        try
        {
            var prescription = await service.CreatePrescriptionAsync(prescriptionData);
            return Created($"prescription/{prescription.IdPrescription}", prescription);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}