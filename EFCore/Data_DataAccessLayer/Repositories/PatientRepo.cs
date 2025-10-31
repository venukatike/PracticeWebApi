using EFCore.Data_DataAccessLayer.Data;
using EFCore.Data_DataAccessLayer.EFModels;
using EFCore.MyProjectInfrastructure.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PatientRepo : IPatientRepo

{
	private readonly MyDbContext context;

	public PatientRepo(MyDbContext _context)
	{
		context = _context;
	}

    public async Task<List<Patient>> GetAllPatients(int pageNmber, int pageSize)
    {
		var a = await context.Patients.OrderBy(e=>e.PatientId).Skip((pageNmber-1)*(pageSize)).Take(pageSize).
			ToListAsync();
		return a;
    }

	public Patient PostPatient(Patient patient)
	{

		context.Patients.Add(patient);
		context.SaveChanges();
		
		return patient;
	
	}
}
