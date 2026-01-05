using System;

namespace ClinicaApp.Domain.Model
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public int PatientId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string PolicyNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime EndDate { get; set; }
    }
}
