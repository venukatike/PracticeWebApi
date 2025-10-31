using HBP.api.DTO_s;
using HBP.api.Models;

public class PatientService : IPatientService
{
	private readonly IPatient _repo;
	public PatientService(IPatient repo)
	{
		_repo = repo;
	}

	public List<PatientDTO> Get()
	{
		return _repo.Get();
	}
	

}