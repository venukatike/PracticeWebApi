using System;
using System.Collections.Generic;
using HBP.api.Models;
using Microsoft.EntityFrameworkCore;

namespace HBP.api.Data;

public partial class BillingDbContext : DbContext
{
    public BillingDbContext()
    {
    }

    public BillingDbContext(DbContextOptions<BillingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<AuthorizationProcedure> AuthorizationProcedures { get; set; }

    public virtual DbSet<AuthorizationRequest> AuthorizationRequests { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<FinancialCase> FinancialCases { get; set; }

    public virtual DbSet<FinancialCaseNote> FinancialCaseNotes { get; set; }

    public virtual DbSet<Gfe> Gves { get; set; }

    public virtual DbSet<Gfeitem> Gfeitems { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<InsuranceVerification> InsuranceVerifications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientInsurance> PatientInsurances { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<VwPatientSummary> VwPatientSummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VUVTT19\\SQLEXPRESS;Database=HBP;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__AppUser__1788CC4CEBEECF80");

            entity.ToTable("AppUser");

            entity.HasIndex(e => e.Username, "UQ__AppUser__536C85E4D49F30CE").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__AppUser__A9D10534FBB92997").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DisplayName).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.Username).HasMaxLength(150);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC2D7CF469D");

            entity.ToTable("Appointment");

            entity.HasIndex(e => e.PatientId, "IX_Appointment_Patient");

            entity.HasIndex(e => e.ScheduledAt, "IX_Appointment_ScheduledAt");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DurationMinutes).HasDefaultValue(30);
            entity.Property(e => e.Reason).HasMaxLength(1000);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Scheduled");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__Appointme__Creat__151B244E");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__1332DBDC");

            entity.HasOne(d => d.Provider).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__Appointme__Provi__14270015");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AuditLog__A17F239896CC67C3");

            entity.ToTable("AuditLog");

            entity.HasIndex(e => e.EventType, "IX_AuditLog_EventType");

            entity.HasIndex(e => e.PerformedAt, "IX_AuditLog_PerformedAt").IsDescending();

            entity.Property(e => e.Detail).HasMaxLength(4000);
            entity.Property(e => e.EntityId).HasMaxLength(200);
            entity.Property(e => e.EntityType).HasMaxLength(200);
            entity.Property(e => e.EventType).HasMaxLength(200);
            entity.Property(e => e.PerformedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.PerformedByUser).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.PerformedByUserId)
                .HasConstraintName("FK__AuditLog__Perfor__1CBC4616");
        });

        modelBuilder.Entity<AuthorizationProcedure>(entity =>
        {
            entity.HasKey(e => e.AuthProcedureId).HasName("PK__Authoriz__480C6612EF1C2A5A");

            entity.ToTable("AuthorizationProcedure");

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.EstimatedCost).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.ProcedureCode).HasMaxLength(50);
            entity.Property(e => e.Units).HasDefaultValue(1);

            entity.HasOne(d => d.Authorization).WithMany(p => p.AuthorizationProcedures)
                .HasForeignKey(d => d.AuthorizationId)
                .HasConstraintName("FK__Authoriza__Autho__75A278F5");
        });

        modelBuilder.Entity<AuthorizationRequest>(entity =>
        {
            entity.HasKey(e => e.AuthorizationId).HasName("PK__Authoriz__09019C17920AA15B");

            entity.ToTable("AuthorizationRequest");

            entity.HasIndex(e => e.PatientId, "IX_AuthorizationRequest_Patient");

            entity.HasIndex(e => e.Status, "IX_AuthorizationRequest_Status");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ExternalAuthNumber).HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(4000);
            entity.Property(e => e.RequestedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Patient).WithMany(p => p.AuthorizationRequests)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Authoriza__Patie__6FE99F9F");

            entity.HasOne(d => d.Provider).WithMany(p => p.AuthorizationRequests)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__Authoriza__Provi__70DDC3D8");

            entity.HasOne(d => d.RequestorUser).WithMany(p => p.AuthorizationRequests)
                .HasForeignKey(d => d.RequestorUserId)
                .HasConstraintName("FK__Authoriza__Reque__71D1E811");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF0FCEBB6CFE");

            entity.ToTable("Document");

            entity.HasIndex(e => new { e.OwnerType, e.OwnerId }, "IX_Document_Owner");

            entity.Property(e => e.FileMimeType).HasMaxLength(200);
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.OwnerType).HasMaxLength(100);
            entity.Property(e => e.UploadedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Url).HasMaxLength(2000);

            entity.HasOne(d => d.UploadedByUser).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UploadedByUserId)
                .HasConstraintName("FK__Document__Upload__18EBB532");
        });

        modelBuilder.Entity<FinancialCase>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PK__Financia__6CAE524C594098F9");

            entity.ToTable("FinancialCase");

            entity.HasIndex(e => e.PatientId, "IX_FinancialCase_Patient");

            entity.HasIndex(e => e.Status, "IX_FinancialCase_Status");

            entity.Property(e => e.EstimatedBalance).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Notes).HasMaxLength(4000);
            entity.Property(e => e.OpenedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Open");

            entity.HasOne(d => d.AssignedToUser).WithMany(p => p.FinancialCases)
                .HasForeignKey(d => d.AssignedToUserId)
                .HasConstraintName("FK__Financial__Assig__08B54D69");

            entity.HasOne(d => d.Patient).WithMany(p => p.FinancialCases)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Financial__Patie__07C12930");
        });

        modelBuilder.Entity<FinancialCaseNote>(entity =>
        {
            entity.HasKey(e => e.CaseNoteId).HasName("PK__Financia__DF5F93B1E56D450C");

            entity.ToTable("FinancialCaseNote");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.NoteText).HasMaxLength(4000);

            entity.HasOne(d => d.Case).WithMany(p => p.FinancialCaseNotes)
                .HasForeignKey(d => d.CaseId)
                .HasConstraintName("FK__Financial__CaseI__0C85DE4D");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.FinancialCaseNotes)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__Financial__Creat__0D7A0286");
        });

        modelBuilder.Entity<Gfe>(entity =>
        {
            entity.HasKey(e => e.Gfeid).HasName("PK__GFE__CB84C08B178DB7AC");

            entity.ToTable("GFE");

            entity.HasIndex(e => e.PatientId, "IX_GFE_Patient");

            entity.Property(e => e.Gfeid).HasColumnName("GFEId");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Notes).HasMaxLength(2000);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Draft");
            entity.Property(e => e.TotalEstimatedCost).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Gves)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__GFE__CreatedByUs__7D439ABD");

            entity.HasOne(d => d.Patient).WithMany(p => p.Gves)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__GFE__PatientId__7B5B524B");

            entity.HasOne(d => d.Provider).WithMany(p => p.Gves)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__GFE__ProviderId__7C4F7684");
        });

        modelBuilder.Entity<Gfeitem>(entity =>
        {
            entity.HasKey(e => e.GfeitemId).HasName("PK__GFEItem__9623CDB9E18CD3ED");

            entity.ToTable("GFEItem");

            entity.Property(e => e.GfeitemId).HasColumnName("GFEItemId");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.EstimatedCost).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Gfeid).HasColumnName("GFEId");
            entity.Property(e => e.ItemCode).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Gfe).WithMany(p => p.Gfeitems)
                .HasForeignKey(d => d.Gfeid)
                .HasConstraintName("FK__GFEItem__GFEId__02084FDA");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("PK__Insuranc__74231A24DEA5CD3C");

            entity.ToTable("Insurance");

            entity.HasIndex(e => new { e.PayerName, e.PayerCode }, "UQ_Insurance_Payer").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.PayerCode).HasMaxLength(100);
            entity.Property(e => e.PayerName).HasMaxLength(300);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<InsuranceVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__Insuranc__306D4907599ED957");

            entity.ToTable("InsuranceVerification");

            entity.HasIndex(e => e.PatientInsuranceId, "IX_InsuranceVerification_PatientInsurance");

            entity.HasIndex(e => e.Status, "IX_InsuranceVerification_Status");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Notes).HasMaxLength(2000);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Unknown");

            entity.HasOne(d => d.PatientInsurance).WithMany(p => p.InsuranceVerifications)
                .HasForeignKey(d => d.PatientInsuranceId)
                .HasConstraintName("FK__Insurance__Patie__693CA210");

            entity.HasOne(d => d.VerifiedByNavigation).WithMany(p => p.InsuranceVerifications)
                .HasForeignKey(d => d.VerifiedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Insurance__Verif__6A30C649");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__970EC366B55DC0AD");

            entity.ToTable("Patient");

            entity.HasIndex(e => new { e.LastName, e.FirstName }, "IX_Patient_Name");

            entity.HasIndex(e => e.Mrn, "UQ__Patient__C790FDB4773C8534").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Mrn)
                .HasMaxLength(50)
                .HasColumnName("MRN");
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<PatientInsurance>(entity =>
        {
            entity.HasKey(e => e.PatientInsuranceId).HasName("PK__PatientI__1B84E4365500DF10");

            entity.ToTable("PatientInsurance");

            entity.HasIndex(e => e.InsuranceId, "IX_PatientInsurance_Insurance");

            entity.HasIndex(e => e.PatientId, "IX_PatientInsurance_Patient");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.GroupNumber).HasMaxLength(200);
            entity.Property(e => e.PolicyNumber).HasMaxLength(200);

            entity.HasOne(d => d.Insurance).WithMany(p => p.PatientInsurances)
                .HasForeignKey(d => d.InsuranceId)
                .HasConstraintName("FK__PatientIn__Insur__6477ECF3");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientInsurances)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__PatientIn__Patie__6383C8BA");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("PK__Provider__B54C687D032BD09F");

            entity.ToTable("Provider");

            entity.Property(e => e.Address).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.Npi)
                .HasMaxLength(50)
                .HasColumnName("NPI");
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A7366FE01");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ__Role__737584F6FCB02871").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__UserRole__AF2760AD6719B076");

            entity.ToTable("UserRole");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRole__RoleId__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRole__UserId__534D60F1");
        });

        modelBuilder.Entity<VwPatientSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PatientSummary");

            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Mrn)
                .HasMaxLength(50)
                .HasColumnName("MRN");
            entity.Property(e => e.OpenBalances).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.PatientId).ValueGeneratedOnAdd();
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
