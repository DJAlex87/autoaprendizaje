using System;
using System.Collections.Generic;

namespace ClinicaApp.Domain.Model
{
    public class InvoiceHeader
    {
        public int InvoiceId { get; set; }
        public int PatientId { get; set; }
        public string CedulaMedico { get; set; } = string.Empty;

        public int? PolicyId { get; set; }
        public string? CompanyName { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public int? PolicyDaysRemaining { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal CopayAmount { get; set; }
        public decimal InsurerAmount { get; set; }

        public int Year { get; set; }

        // Navegación
        public Patient? Patient { get; set; }
        public InsurancePolicy? Policy { get; set; }
        public ICollection<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();
    }
}
