using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface IInvoiceRepository
    {
        // Consultas existentes
        IList<InvoiceHeader> GetAll();
        IList<InvoiceHeader> GetByYear(int year);
        InvoiceHeader? GetByIdWithDetails(int invoiceId);

        // Nuevo: creación de factura (encabezado + detalles)
        InvoiceHeader AddInvoice(InvoiceHeader header, IList<InvoiceDetail> details);
    }
}
