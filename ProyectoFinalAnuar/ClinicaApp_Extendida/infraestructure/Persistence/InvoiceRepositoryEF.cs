using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class InvoiceRepositoryEF : IInvoiceRepository
    {
        private readonly ClinicDbContext _context;

        public InvoiceRepositoryEF(ClinicDbContext context)
        {
            _context = context;
        }

        public IList<InvoiceHeader> GetAll()
        {
            return _context.InvoiceHeaders
                .Include(h => h.Patient)
                .OrderBy(h => h.InvoiceDate)
                .ToList();
        }

        public IList<InvoiceHeader> GetByYear(int year)
        {
            return _context.InvoiceHeaders
                .Include(h => h.Patient)
                .Where(h => h.Year == year)
                .OrderBy(h => h.InvoiceDate)
                .ToList();
        }

        public InvoiceHeader? GetByIdWithDetails(int invoiceId)
        {
            return _context.InvoiceHeaders
                .Include(h => h.Patient)
                .Include(h => h.Policy)
                .Include(h => h.Details)
                .FirstOrDefault(h => h.InvoiceId == invoiceId);
        }

        // ============================
        //  Creación de factura (Header + Details)
        // ============================
        public InvoiceHeader AddInvoice(InvoiceHeader header, IList<InvoiceDetail> details)
        {
            using var tx = _context.Database.BeginTransaction();

            try
            {
                // 1) Guardar encabezado
                _context.InvoiceHeaders.Add(header);
                _context.SaveChanges(); // genera InvoiceId

                // 2) Asociar detalles al encabezado recién creado
                foreach (var d in details)
                {
                    d.InvoiceId = header.InvoiceId;
                }

                _context.InvoiceDetails.AddRange(details);
                _context.SaveChanges();

                // 3) Confirmar transacción
                tx.Commit();

                // 4) Cargar navegaciones por si el llamador las necesita
                _context.Entry(header).Collection(h => h.Details).Load();
                _context.Entry(header).Reference(h => h.Patient).Load();
                _context.Entry(header).Reference(h => h.Policy).Load();

                return header;
            }
            catch
            {
                // Proteger el rollback para evitar la excepción:
                // "This SqlTransaction has completed; it is no longer usable."
                try
                {
                    tx.Rollback();
                }
                catch
                {
                    // Si la transacción ya fue completada (zombie), ignoramos este error.
                }

                throw;
            }
        }
    }
}
