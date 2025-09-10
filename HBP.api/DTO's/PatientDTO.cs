namespace HBP.api.DTO_s
{
    public class PatientDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly? Dob { get; set; }

        public string? Gender { get; set; }
    }
}
