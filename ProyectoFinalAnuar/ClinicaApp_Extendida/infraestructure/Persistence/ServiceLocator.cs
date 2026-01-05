using System;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Infraestructure.Config;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Infraestructure.Persistence
{
    public static class ServiceLocator
    {
        // Cambia a true si quieres usar repositorios en memoria
        public static bool UseInMemory { get; set; } = false;

        // ===========================================================
        // MÉTODO PRIVADO PARA CREAR UN DbContext (evita duplicación)
        // ===========================================================
        private static ClinicDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClinicDbContext>();
            optionsBuilder.UseSqlServer(Config.Config.ConnectionString);

            var ctx = new ClinicDbContext(optionsBuilder.Options);
            ctx.Database.EnsureCreated();   // Garantiza estructura

            return ctx;
        }

        // ======================
        //          USERS
        // ======================
        public static IUserRepository CreateUserRepository()
        {
            if (UseInMemory)
                return new UserRepositoryInMemory();

            return new UserRepositoryEF(CreateDbContext());
        }

        // ======================
        //        PATIENTS
        // ======================
        public static IPatientRepository CreatePatientRepository()
        {
            if (UseInMemory)
                return new PatientRepositoryInMemory();

            return new PatientRepositoryEF(CreateDbContext());
        }

        // ======================
        //   MEDICATION CATALOG
        // ======================
        public static IMedicationCatalogRepository CreateMedicationCatalogRepository()
        {
            if (UseInMemory)
                throw new NotImplementedException("No existe un repositorio InMemory para MedicationCatalog.");

            return new MedicationCatalogRepositoryEF(CreateDbContext());
        }

        // ======================
        //  PROCEDURE CATALOG
        // ======================
        public static IProcedureCatalogRepository CreateProcedureCatalogRepository()
        {
            if (UseInMemory)
                throw new NotImplementedException("No existe un repositorio InMemory para ProcedureCatalog.");

            return new ProcedureCatalogRepositoryEF(CreateDbContext());
        }

        // ==============================
        // DIAGNOSTIC HELP CATALOG
        // ==============================
        public static IDiagnosticHelpCatalogRepository CreateDiagnosticHelpCatalogRepository()
        {
            if (UseInMemory)
                throw new NotImplementedException("No existe un repositorio InMemory para DiagnosticHelpCatalog.");

            return new DiagnosticHelpCatalogRepositoryEF(CreateDbContext());
        }

        // ======================
        //  SPECIALTY CATALOG
        // ======================
        public static ISpecialtyCatalogRepository CreateSpecialtyCatalogRepository()
        {
            if (UseInMemory)
                throw new NotImplementedException("No existe un repositorio InMemory para SpecialtyCatalog.");

            return new SpecialtyCatalogRepositoryEF(CreateDbContext());
        }

        // ======================
        //  CLINICAL HISTORY (NoSQL JSON)
        // ======================
        public static IClinicalHistoryRepository CreateClinicalHistoryRepository()
        {
            // Ya es “NoSQL” en archivo JSON, no hace falta versión InMemory
            return new JsonClinicalHistoryRepository();
        }

        public static ClinicalHistoryUseCase CreateClinicalHistoryUseCase()
        {
            return new ClinicalHistoryUseCase(CreateClinicalHistoryRepository());
        }

        // ======================
        //     NURSING VISITS
        // ======================
        public static INursingVisitRepository CreateNursingVisitRepository()
        {
            if (UseInMemory)
                throw new NotImplementedException("No existe un repositorio InMemory para NursingVisit.");

            return new NursingVisitRepositoryEF(CreateDbContext());
        }

        public static NursingUseCase CreateNursingUseCase()
        {
            return new NursingUseCase(
                CreateNursingVisitRepository(),
                CreatePatientRepository(),
                CreateUserRepository());
        }

        // ======================
        //        BILLING
        // ======================
        public static IInvoiceRepository CreateInvoiceRepository()
        {
            if (UseInMemory)
                throw new NotImplementedException("No existe un repositorio InMemory para Invoice.");

            return new InvoiceRepositoryEF(CreateDbContext());
        }

        public static BillingUseCase CreateBillingUseCase()
        {
            return new BillingUseCase(CreateInvoiceRepository());
        }
    }
}
