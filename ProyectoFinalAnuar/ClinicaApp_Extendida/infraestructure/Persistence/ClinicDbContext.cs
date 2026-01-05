using ClinicaApp.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<EmergencyContact> EmergencyContacts => Set<EmergencyContact>();
        public DbSet<InsurancePolicy> InsurancePolicies => Set<InsurancePolicy>();

        // Catálogo de medicamentos
        public DbSet<MedicationCatalog> MedicationCatalogs => Set<MedicationCatalog>();

        // Catálogos de procedimientos, ayudas diagnósticas y especialidades
        public DbSet<ProcedureCatalog> ProcedureCatalogs => Set<ProcedureCatalog>();
        public DbSet<DiagnosticHelpCatalog> DiagnosticHelpCatalogs => Set<DiagnosticHelpCatalog>();
        public DbSet<SpecialtyCatalog> SpecialtyCatalogs => Set<SpecialtyCatalog>();

        // ======================
        //   NURSING VISIT
        // ======================
        public DbSet<NursingVisit> NursingVisits => Set<NursingVisit>();

        // ======================
        //       BILLING
        // ======================
        public DbSet<InvoiceHeader> InvoiceHeaders => Set<InvoiceHeader>();
        public DbSet<InvoiceDetail> InvoiceDetails => Set<InvoiceDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ======================
            //         USER
            // ======================
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Cedula)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // ======================
            //       PATIENT
            // ======================
            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.Cedula)
                .IsUnique();

            // ======================
            //   INSURANCE POLICY
            // ======================
            modelBuilder.Entity<InsurancePolicy>(entity =>
            {
                // Nombre real de la tabla en SQL
                entity.ToTable("InsurancePolicy");

                entity.HasKey(p => p.PolicyId);

                entity.Property(p => p.PolicyId)
                      .ValueGeneratedOnAdd();

                entity.Property(p => p.PatientId)
                      .IsRequired();

                entity.Property(p => p.CompanyName)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(p => p.PolicyNumber)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(p => p.IsActive)
                      .IsRequired();

                entity.Property(p => p.EndDate)
                      .HasColumnType("date")
                      .IsRequired();

                // Relación 1–1 Patient–Policy
                entity.HasOne<Patient>()
                      .WithOne(p => p.Policy!)
                      .HasForeignKey<InsurancePolicy>(p => p.PatientId);
            });

            // ======================
            //   MEDICATION CATALOG
            // ======================
            modelBuilder.Entity<MedicationCatalog>(entity =>
            {
                entity.ToTable("MedicationCatalog");

                entity.HasKey(m => m.MedicationId);

                entity.Property(m => m.MedicationId)
                      .ValueGeneratedOnAdd();

                entity.Property(m => m.Nombre)
                      .HasColumnName("Nombre")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(m => m.CostoBase)
                      .HasColumnName("CostoBase")
                      .HasPrecision(12, 2);

                entity.Property(m => m.Description)
                      .HasMaxLength(500);

                entity.Property(m => m.IsActive)
                      .HasDefaultValue(true);
            });

            // ======================
            //   SPECIALTY CATALOG
            // ======================
            modelBuilder.Entity<SpecialtyCatalog>(entity =>
            {
                entity.ToTable("SpecialtyCatalog");

                entity.HasKey(s => s.SpecialtyId);

                entity.Property(s => s.SpecialtyId)
                      .ValueGeneratedOnAdd();

                entity.Property(s => s.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(s => s.Description)
                      .HasMaxLength(500);

                entity.Property(s => s.IsActive)
                      .HasDefaultValue(true);
            });

            // ======================
            //   PROCEDURE CATALOG
            // ======================
            modelBuilder.Entity<ProcedureCatalog>(entity =>
            {
                entity.ToTable("ProcedureCatalog");

                entity.HasKey(p => p.ProcedureId);

                entity.Property(p => p.ProcedureId)
                      .ValueGeneratedOnAdd();

                entity.Property(p => p.Nombre)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(p => p.Description)
                      .HasMaxLength(500);

                entity.Property(p => p.CostoBase)
                      .HasPrecision(12, 2);

                entity.Property(p => p.RequiresSpecialist)
                      .HasDefaultValue(false);

                entity.Property(p => p.IsActive)
                      .HasDefaultValue(true);

                entity.HasOne(p => p.Specialty)
                      .WithMany()
                      .HasForeignKey(p => p.SpecialtyId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ==========================
            // DIAGNOSTIC HELP CATALOG
            // ==========================
            modelBuilder.Entity<DiagnosticHelpCatalog>(entity =>
            {
                entity.ToTable("DiagnosticHelpCatalog");

                entity.HasKey(d => d.DiagnosticHelpId);

                entity.Property(d => d.DiagnosticHelpId)
                      .ValueGeneratedOnAdd();

                entity.Property(d => d.Nombre)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(d => d.Description)
                      .HasMaxLength(500);

                entity.Property(d => d.CostoBase)
                      .HasPrecision(12, 2);

                entity.Property(d => d.RequiresSpecialist)
                      .HasDefaultValue(false);

                entity.Property(d => d.IsActive)
                      .HasDefaultValue(true);

                entity.HasOne(d => d.Specialty)
                      .WithMany()
                      .HasForeignKey(d => d.SpecialtyId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ======================
            //      NURSING VISIT
            // ======================
            modelBuilder.Entity<NursingVisit>(entity =>
            {
                // Nombre real de la tabla en SQL
                entity.ToTable("NurseVisit");

                entity.HasKey(v => v.VisitId);

                entity.Property(v => v.VisitId)
                      .HasColumnName("VisitId")
                      .ValueGeneratedOnAdd();

                entity.Property(v => v.CedulaPaciente)
                      .HasColumnName("CedulaPaciente")
                      .HasMaxLength(10)
                      .IsRequired();

                entity.Property(v => v.CedulaEnfermera)
                      .HasColumnName("CedulaEnfermera")
                      .HasMaxLength(10)
                      .IsRequired();

                entity.Property(v => v.FechaHora)
                      .HasColumnName("FechaHora")
                      .IsRequired();

                entity.Property(v => v.PresionArterial)
                      .HasColumnName("PresionArterial")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(v => v.Temperatura)
                      .HasColumnName("Temperatura")
                      .HasColumnType("decimal(4,1)")
                      .IsRequired();

                entity.Property(v => v.Pulso)
                      .HasColumnName("Pulso")
                      .IsRequired();

                entity.Property(v => v.Oxigeno)
                      .HasColumnName("Oxigeno")
                      .IsRequired();

                entity.Property(v => v.Observaciones)
                      .HasColumnName("Observaciones");

                entity.Property(v => v.OrderNumber)
                      .HasColumnName("OrderNumber");

                entity.Property(v => v.ItemNumber)
                      .HasColumnName("ItemNumber");
            });

            // ======================
            //     INVOICE HEADER
            // ======================
            modelBuilder.Entity<InvoiceHeader>(entity =>
            {
                entity.ToTable("InvoiceHeader");

                entity.HasKey(h => h.InvoiceId);

                entity.Property(h => h.InvoiceId)
                      .ValueGeneratedOnAdd();

                entity.Property(h => h.PatientId)
                      .IsRequired();

                entity.Property(h => h.CedulaMedico)
                      .HasMaxLength(10)
                      .IsRequired();

                // PolicyId, CompanyName, PolicyNumber,
                // PolicyEndDate y PolicyDaysRemaining son opcionales en la BD
                entity.Property(h => h.PolicyId);

                entity.Property(h => h.CompanyName)
                      .HasMaxLength(100);

                entity.Property(h => h.PolicyNumber)
                      .HasMaxLength(50);

                entity.Property(h => h.PolicyEndDate);

                entity.Property(h => h.PolicyDaysRemaining);

                entity.Property(h => h.InvoiceDate)
                      .IsRequired();

                entity.Property(h => h.TotalAmount)
                      .HasPrecision(12, 2)
                      .IsRequired();

                entity.Property(h => h.CopayAmount)
                      .HasPrecision(12, 2)
                      .IsRequired();

                entity.Property(h => h.InsurerAmount)
                      .HasPrecision(12, 2)
                      .IsRequired();

                entity.Property(h => h.Year)
                      .IsRequired();

                // Relación 1 (Header) - muchos (Details)
                entity.HasMany(h => h.Details)
                      .WithOne(d => d.Invoice)
                      .HasForeignKey(d => d.InvoiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ======================
            //     INVOICE DETAIL
            // ======================
            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("InvoiceDetail");

                entity.HasKey(d => d.InvoiceDetailId);

                entity.Property(d => d.InvoiceDetailId)
                      .ValueGeneratedOnAdd();

                entity.Property(d => d.InvoiceId)
                      .IsRequired();

                entity.Property(d => d.Description)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(d => d.Quantity)
                      .IsRequired();

                entity.Property(d => d.UnitCost)
                      .HasPrecision(12, 2)
                      .IsRequired();

                entity.Property(d => d.LineTotal)
                      .HasPrecision(12, 2)
                      .IsRequired();

                entity.Property(d => d.ItemType)
                      .HasMaxLength(20)
                      .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
