using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Seeco.Models.ViewModels;

namespace Seeco.Models
{
    public partial class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext()
        {
        }

        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<TblBoq> TblBoq { get; set; }
        public virtual DbSet<TblClients> TblClients { get; set; }
        public virtual DbSet<TblClientsTeams> TblClientsTeams { get; set; }
        public virtual DbSet<TblConsultants> TblConsultants { get; set; }
        public virtual DbSet<TblConsultantsTeams> TblConsultantsTeams { get; set; }
        public virtual DbSet<TblContractors> TblContractors { get; set; }
        public virtual DbSet<TblContractorsTeams> TblContractorsTeams { get; set; }
        public virtual DbSet<TblContracts> TblContracts { get; set; }
        public virtual DbSet<TblDrawingDet> TblDrawingDet { get; set; }
        public virtual DbSet<TblDrawings> TblDrawings { get; set; }
        public virtual DbSet<TblInvoicesContractor> TblInvoicesContractor { get; set; }
        public virtual DbSet<TblItems> TblItems { get; set; }
        public virtual DbSet<TblLetters> TblLetters { get; set; }
        public virtual DbSet<TblProjects> TblProjects { get; set; }
        public virtual DbSet<TblRequests> TblRequests { get; set; }
        public virtual DbSet<TblRoles> TblRoles { get; set; }
        public virtual DbSet<TblSchedules> TblSchedules { get; set; }
        public virtual DbSet<TblSubItemsSpecifications> TblSubItemsSpecifications { get; set; }
        public virtual DbSet<TblTechProposals> TblTechProposals { get; set; }
        public virtual DbSet<TblUserRole> TblUserRole { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=FATHY;Initial Catalog=ProjectsDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<TblBoq>(entity =>
            {
                entity.ToTable("tblBoq");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Notes).HasMaxLength(50);

                entity.Property(e => e.Unit).HasMaxLength(20);

                entity.Property(e => e.Uprice)
                    .HasColumnName("UPrice")
                    .HasColumnType("money");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblBoq)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblBoq_tblItems");
            });

            modelBuilder.Entity<TblClients>(entity =>
            {
                entity.ToTable("tblClients");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Ceo).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Faxes).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Parent).HasMaxLength(50);

                entity.Property(e => e.Phones).HasMaxLength(50);

                entity.Property(e => e.WebSite).HasMaxLength(50);
            });

            modelBuilder.Entity<TblClientsTeams>(entity =>
            {
                entity.ToTable("tblClientsTeams");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IdNo).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ResponsibleName).HasMaxLength(50);

                entity.Property(e => e.Sector).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblClientsTeams)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblClientsTeams_tblClients");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblClientsTeams)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tblClientsTeams_tblProjects");
            });

            modelBuilder.Entity<TblConsultants>(entity =>
            {
                entity.ToTable("tblConsultants");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Ceo).HasMaxLength(50);

                entity.Property(e => e.Cofounder).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Faxes).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phones).HasMaxLength(50);

                entity.Property(e => e.WebSite).HasMaxLength(50);
            });

            modelBuilder.Entity<TblConsultantsTeams>(entity =>
            {
                entity.ToTable("tblConsultantsTeams");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConsultantId).HasColumnName("ConsultantID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IdNo).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ResponsibleName).HasMaxLength(50);

                entity.Property(e => e.Sector).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Consultant)
                    .WithMany(p => p.TblConsultantsTeams)
                    .HasForeignKey(d => d.ConsultantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblConsultantsTeams_tblConsultants");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblConsultantsTeams)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tblConsultantsTeams_tblProjects");
            });

            modelBuilder.Entity<TblContractors>(entity =>
            {
                entity.ToTable("tblContractors");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Ceo).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Faxes).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Parent).HasMaxLength(50);

                entity.Property(e => e.Phones).HasMaxLength(50);

                entity.Property(e => e.WebSite).HasMaxLength(50);
            });

            modelBuilder.Entity<TblContractorsTeams>(entity =>
            {
                entity.ToTable("tblContractorsTeams");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContractorId).HasColumnName("ContractorID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IdNo).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ResponsibleName).HasMaxLength(50);

                entity.Property(e => e.Sector).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.TblContractorsTeams)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblContractorsTeams_tblContractors");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblContractorsTeams)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tblContractorsTeams_tblProjects");
            });

            modelBuilder.Entity<TblContracts>(entity =>
            {
                entity.ToTable("tblContracts");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaseValue).HasColumnType("money");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ConsultantContractorId).HasColumnName("ConsultantContractorID");

                entity.Property(e => e.ConsultantDesignId).HasColumnName("ConsultantDesignID");

                entity.Property(e => e.ConsultantSupervisionId).HasColumnName("ConsultantSupervisionID");

                entity.Property(e => e.ContractorId).HasColumnName("ContractorID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblContracts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblContracts_tblClients");

                entity.HasOne(d => d.ConsultantContractor)
                    .WithMany(p => p.TblContractsConsultantContractor)
                    .HasForeignKey(d => d.ConsultantContractorId)
                    .HasConstraintName("FK_tblContracts_tblConsultantsContractor");

                entity.HasOne(d => d.ConsultantDesign)
                    .WithMany(p => p.TblContractsConsultantDesign)
                    .HasForeignKey(d => d.ConsultantDesignId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblContracts_tblConsultantsDesign");

                entity.HasOne(d => d.ConsultantSupervision)
                    .WithMany(p => p.TblContractsConsultantSupervision)
                    .HasForeignKey(d => d.ConsultantSupervisionId)
                    .HasConstraintName("FK_tblContracts_tblConsultantsSupervision");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.TblContracts)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblContracts_tblContractors");
            });

            modelBuilder.Entity<TblDrawingDet>(entity =>
            {
                entity.ToTable("tblDrawingDet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DecisionMaker).HasMaxLength(50);

                entity.Property(e => e.DrawingId).HasColumnName("DrawingID");

                entity.HasOne(d => d.Drawing)
                    .WithMany(p => p.TblDrawingDet)
                    .HasForeignKey(d => d.DrawingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblDrawingDet_tblDrawings");
            });

            modelBuilder.Entity<TblDrawings>(entity =>
            {
                entity.ToTable("tblDrawings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateIssued).HasColumnType("date");

                entity.Property(e => e.DateReceived).HasColumnType("date");

                entity.Property(e => e.DrawBy).HasMaxLength(50);

                entity.Property(e => e.DrawingName).HasMaxLength(50);

                entity.Property(e => e.DrawingType).HasMaxLength(50);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Receiver).HasMaxLength(50);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblDrawings)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblDrawings_tblItems");
            });

            modelBuilder.Entity<TblInvoicesContractor>(entity =>
            {
                entity.ToTable("tblInvoicesContractor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DiscountContractor).HasColumnType("money");

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.InvoiceValue).HasColumnType("money");

                entity.Property(e => e.Liability).HasColumnType("money");

                entity.Property(e => e.Net).HasColumnType("money");

                entity.Property(e => e.PrePayed).HasColumnType("money");

                entity.Property(e => e.PreviousInvoices).HasColumnType("money");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.StoresValue).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.TotalAfterDiscountContractor).HasColumnType("money");

                entity.Property(e => e.WorksUpToDate).HasColumnType("money");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblInvoicesContractor)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblInvoicesContractor_tblProjects");
            });

            modelBuilder.Entity<TblItems>(entity =>
            {
                entity.ToTable("tblItems");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemNo).HasMaxLength(50);

                entity.Property(e => e.ItemType).HasMaxLength(50);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblItems)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblItems_tblProjects");
            });

            modelBuilder.Entity<TblLetters>(entity =>
            {
                entity.ToTable("tblLetters");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DateReceived).HasColumnType("date");

                entity.Property(e => e.DirectedTo).HasMaxLength(50);

                entity.Property(e => e.IssuedBy).HasMaxLength(50);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Subject).HasMaxLength(300);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblLetters)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblLetters_tblProjects");
            });

            modelBuilder.Entity<TblProjects>(entity =>
            {
                entity.ToTable("tblProjects");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.TblProjects)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblProjects_tblContracts");
            });

            modelBuilder.Entity<TblRequests>(entity =>
            {
                entity.ToTable("tblRequests");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConsultantTeamId).HasColumnName("ConsultantTeamID");

                entity.Property(e => e.ContractorTeamId).HasColumnName("ContractorTeamID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SubItemId).HasColumnName("SubItemID");

                entity.Property(e => e.Subject).HasMaxLength(50);

                entity.HasOne(d => d.ConsultantTeam)
                    .WithMany(p => p.TblRequests)
                    .HasForeignKey(d => d.ConsultantTeamId)
                    .HasConstraintName("FK_tblRequests_tblConsultantsTeams");

                entity.HasOne(d => d.ContractorTeam)
                    .WithMany(p => p.TblRequests)
                    .HasForeignKey(d => d.ContractorTeamId)
                    .HasConstraintName("FK_tblRequests_tblContractorsTeams");

                entity.HasOne(d => d.SubItem)
                    .WithMany(p => p.TblRequests)
                    .HasForeignKey(d => d.SubItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblRequests_tblSubItemsSpecifications");
            });

            modelBuilder.Entity<TblRoles>(entity =>
            {
                entity.ToTable("tblRoles");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSchedules>(entity =>
            {
                entity.ToTable("tblSchedules");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DecisionDate).HasColumnType("date");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.SchEndDate).HasColumnType("date");

                entity.Property(e => e.SchStartDate).HasColumnType("date");

                entity.Property(e => e.ScheduleNo).HasMaxLength(50);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblSchedules)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblSchedules_tblProjects");
            });

            modelBuilder.Entity<TblSubItemsSpecifications>(entity =>
            {
                entity.ToTable("tblSubItemsSpecifications");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Notes).HasMaxLength(50);

                entity.Property(e => e.SubItemName).HasMaxLength(50);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblSubItemsSpecifications)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblSubItemsSpecifications_tblItems");
            });

            modelBuilder.Entity<TblTechProposals>(entity =>
            {
                entity.ToTable("tblTechProposals");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConsultantTeamId).HasColumnName("ConsultantTeamID");

                entity.Property(e => e.ContractorTeamId).HasColumnName("ContractorTeamID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FilePath).HasMaxLength(200);

                entity.Property(e => e.Provider).HasMaxLength(200);

                entity.Property(e => e.SubItemId).HasColumnName("SubItemID");

                entity.HasOne(d => d.ConsultantTeam)
                    .WithMany(p => p.TblTechProposals)
                    .HasForeignKey(d => d.ConsultantTeamId)
                    .HasConstraintName("FK_tblTechProposals_tblConsultantsTeams");

                entity.HasOne(d => d.ContractorTeam)
                    .WithMany(p => p.TblTechProposals)
                    .HasForeignKey(d => d.ContractorTeamId)
                    .HasConstraintName("FK_tblTechProposals_tblContractorsTeams");

                entity.HasOne(d => d.SubItem)
                    .WithMany(p => p.TblTechProposals)
                    .HasForeignKey(d => d.SubItemId)
                    .HasConstraintName("FK_tblTechProposals_tblSubItemsSpecifications");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity.ToTable("tblUserRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblUserRole_tblRoles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblUserRole_tblUsers");
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblUsers_tblProjects");
            });
        }

        public DbSet<Seeco.Models.ViewModels.BoqViewModel> BoqViewModel { get; set; }

        public DbSet<Seeco.Models.ViewModels.ItemViewModel> ItemViewModel { get; set; }
    }
}
