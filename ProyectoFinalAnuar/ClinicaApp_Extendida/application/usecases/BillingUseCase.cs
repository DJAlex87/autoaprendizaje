using System;
using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Application.UseCases
{
    public class BillingUseCase
    {
        private readonly IInvoiceRepository _invoiceRepo;

        public BillingUseCase(IInvoiceRepository invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }

        // =========================
        //   CONSULTAS DE FACTURAS
        // =========================
        public (bool Success, string Message, IList<InvoiceHeader> Invoices)
            BuscarFacturasPorAnio(int? year)
        {
            IList<InvoiceHeader> list;

            if (year.HasValue && year.Value > 0)
                list = _invoiceRepo.GetByYear(year.Value);
            else
                list = _invoiceRepo.GetAll();

            if (list.Count == 0)
                return (false, "No se encontraron facturas para el criterio indicado.", new List<InvoiceHeader>());

            return (true, string.Empty, list);
        }

        public (bool Success, string Message, InvoiceHeader? Invoice)
            ObtenerFacturaConDetalle(int invoiceId)
        {
            var inv = _invoiceRepo.GetByIdWithDetails(invoiceId);
            if (inv == null)
                return (false, "No se encontró la factura.", null);

            return (true, string.Empty, inv);
        }

        // Nuevo helper para la grid de detalles
        public (bool Success, string Message, IList<InvoiceDetail> Details)
            ObtenerDetallesFactura(int invoiceId)
        {
            var inv = _invoiceRepo.GetByIdWithDetails(invoiceId);
            if (inv == null)
                return (false, "No se encontró la factura.", new List<InvoiceDetail>());

            var details = inv.Details?.ToList() ?? new List<InvoiceDetail>();
            if (details.Count == 0)
                return (false, "La factura no tiene ítems de detalle.", details);

            return (true, string.Empty, details);
        }

        // =========================
        //   GENERACIÓN DE FACTURA
        // =========================
        public (bool Success, string Message, InvoiceHeader? Invoice)
            GenerarFactura(InvoiceHeader header, IList<InvoiceDetail> details)
        {
            if (header == null)
                return (false, "El encabezado de la factura es obligatorio.", null);

            if (details == null || details.Count == 0)
                return (false, "Debes registrar al menos un ítem en la factura.", null);

            if (header.PatientId <= 0)
                return (false, "El Id de paciente no es válido.", null);

            if (string.IsNullOrWhiteSpace(header.CedulaMedico))
                return (false, "La cédula del médico es obligatoria.", null);

            // Aseguramos fecha e información básica
            if (header.InvoiceDate == default)
                header.InvoiceDate = DateTime.Now;

            if (header.Year <= 0)
                header.Year = header.InvoiceDate.Year;

            // Calcular line totals si vienen sin valor y el total de la factura
            foreach (var d in details)
            {
                if (d.Quantity <= 0) d.Quantity = 1;
                if (d.LineTotal <= 0m && d.UnitCost > 0m)
                    d.LineTotal = d.UnitCost * d.Quantity;
            }

            var total = details.Sum(d => d.LineTotal);

            if (header.TotalAmount <= 0m)
                header.TotalAmount = total;

            // Si copago/aseguradora no están seteados, los dejamos en 0
            if (header.CopayAmount < 0m) header.CopayAmount = 0m;
            if (header.InsurerAmount < 0m) header.InsurerAmount = 0m;

            try
            {
                var saved = _invoiceRepo.AddInvoice(header, details);

                // Nos aseguramos de devolverla con detalles ya cargados
                var withDetails = _invoiceRepo.GetByIdWithDetails(saved.InvoiceId) ?? saved;

                return (true, "Factura generada correctamente.", withDetails);
            }
            catch (Exception)
            {
                // En un sistema real podríamos loguear ex.Message
                return (false, "Ocurrió un error al generar la factura.", null);
            }
        }
    }
}
