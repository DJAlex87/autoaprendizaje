using System;

namespace ClinicaApp.Domain.Model
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }

        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal LineTotal { get; set; }
        public string ItemType { get; set; } = string.Empty;

        // Navegación
        public InvoiceHeader? Invoice { get; set; }
    }
}
