using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSMultifamilyProperty.Models
{
    public partial class MultifamilyPropertyContext : DbContext
    {
        public MultifamilyPropertyContext()
        {
        }

        public MultifamilyPropertyContext(DbContextOptions<MultifamilyPropertyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<Dwelling> Dwelling { get; set; }
        public virtual DbSet<ManagementFees> ManagementFees { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Pqr> Pqr { get; set; }
        public virtual DbSet<PropertyMaintenance> PropertyMaintenance { get; set; }
        public virtual DbSet<PropertyRevenue> PropertyRevenue { get; set; }
        public virtual DbSet<Reserve> Reserve { get; set; }
        public virtual DbSet<ResidentialComplex> ResidentialComplex { get; set; }
        public virtual DbSet<RolAction> RolAction { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=33060;user=root;password=secretito;database=MultifamilyProperty", x => x.ServerVersion("10.5.8-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("action");

                entity.HasIndex(e => e.IdModule)
                    .HasName("fkaction_module");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IdModule)
                    .HasColumnName("id_module")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.Action)
                    .HasForeignKey(d => d.IdModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkaction_module");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("building");

                entity.HasIndex(e => e.IdResidentialComplex)
                    .HasName("fkbuilding_residentialComplex");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IdResidentialComplex)
                    .HasColumnName("id_residentialComplex")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdResidentialComplexNavigation)
                    .WithMany(p => p.Building)
                    .HasForeignKey(d => d.IdResidentialComplex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkbuilding_residentialComplex");
            });

            modelBuilder.Entity<Dwelling>(entity =>
            {
                entity.ToTable("dwelling");

                entity.HasIndex(e => e.IdBuilding)
                    .HasName("fkdwelling_building");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IdBuilding)
                    .HasColumnName("id_building")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdBuildingNavigation)
                    .WithMany(p => p.Dwelling)
                    .HasForeignKey(d => d.IdBuilding)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkdwelling_building");
            });

            modelBuilder.Entity<ManagementFees>(entity =>
            {
                entity.ToTable("managementFees");

                entity.HasIndex(e => e.IdDwelling)
                    .HasName("fkmanagementFees_dwelling");

                entity.HasIndex(e => e.IdResidentialComplex)
                    .HasName("fkmanagementFees_residentialComplex");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasColumnType("decimal(16,2) unsigned");

                entity.Property(e => e.IdDwelling)
                    .HasColumnName("id_dwelling")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.IdResidentialComplex)
                    .HasColumnName("id_residentialComplex")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasColumnName("month")
                    .HasColumnType("enum('1','2','3','4','5','6','7','8','9','10','11','12')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("year(4)");

                entity.HasOne(d => d.IdDwellingNavigation)
                    .WithMany(p => p.ManagementFees)
                    .HasForeignKey(d => d.IdDwelling)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkmanagementFees_dwelling");

                entity.HasOne(d => d.IdResidentialComplexNavigation)
                    .WithMany(p => p.ManagementFees)
                    .HasForeignKey(d => d.IdResidentialComplex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkmanagementFees_residentialComplex");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("module");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Pqr>(entity =>
            {
                entity.ToTable("pqr");

                entity.HasIndex(e => e.IdDwelling)
                    .HasName("fkpqr_dwelling");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdDwelling)
                    .HasColumnName("id_dwelling")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('sent','resolved','closed')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdDwellingNavigation)
                    .WithMany(p => p.Pqr)
                    .HasForeignKey(d => d.IdDwelling)
                    .HasConstraintName("fkpqr_dwelling");
            });

            modelBuilder.Entity<PropertyMaintenance>(entity =>
            {
                entity.ToTable("propertyMaintenance");

                entity.HasIndex(e => e.IdResidentialComplex)
                    .HasName("fkpropertyMaintenance_residentialComplex");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdResidentialComplex)
                    .HasColumnName("id_residentialComplex")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("enum('Water','Electricity','Gas','Telecommunications','Maintenance','Security','Cleaning')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdResidentialComplexNavigation)
                    .WithMany(p => p.PropertyMaintenance)
                    .HasForeignKey(d => d.IdResidentialComplex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpropertyMaintenance_residentialComplex");
            });

            modelBuilder.Entity<PropertyRevenue>(entity =>
            {
                entity.ToTable("propertyRevenue");

                entity.HasIndex(e => e.IdResidentialComplex)
                    .HasName("fkpropertyRevenues_residentialComplex");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Concept)
                    .HasColumnName("concept")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IdResidentialComplex)
                    .HasColumnName("id_residentialComplex")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Revenue)
                    .HasColumnName("revenue")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("enum('Rent','Reserve')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdResidentialComplexNavigation)
                    .WithMany(p => p.PropertyRevenue)
                    .HasForeignKey(d => d.IdResidentialComplex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpropertyRevenues_residentialComplex");
            });

            modelBuilder.Entity<Reserve>(entity =>
            {
                entity.ToTable("reserve");

                entity.HasIndex(e => e.IdDwelling)
                    .HasName("fkreserve_dwelling");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Facility)
                    .HasColumnName("facility")
                    .HasColumnType("enum('entertainment room','pool')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdDwelling)
                    .HasColumnName("id_dwelling")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.IdDwellingNavigation)
                    .WithMany(p => p.Reserve)
                    .HasForeignKey(d => d.IdDwelling)
                    .HasConstraintName("fkreserve_dwelling");
            });

            modelBuilder.Entity<ResidentialComplex>(entity =>
            {
                entity.ToTable("residentialComplex");

                entity.HasIndex(e => e.Address)
                    .HasName("address")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.HasIndex(e => e.Phonenumber)
                    .HasName("phonenumber")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<RolAction>(entity =>
            {
                entity.ToTable("rol_action");

                entity.HasIndex(e => e.IdAction)
                    .HasName("fkrol_action_action");

                entity.HasIndex(e => e.IdRole)
                    .HasName("fkrol_action_rol");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IdAction)
                    .HasColumnName("id_action")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdRole)
                    .HasColumnName("id_role")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.IdActionNavigation)
                    .WithMany(p => p.RolAction)
                    .HasForeignKey(d => d.IdAction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkrol_action_action");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.RolAction)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkrol_action_rol");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.IdDwelling)
                    .HasName("fkuser_dwelling");

                entity.HasIndex(e => e.IdOptionalRole)
                    .HasName("fkuser_optionalRole");

                entity.HasIndex(e => e.IdResidentialComplex)
                    .HasName("fkuser_residentialComplex");

                entity.HasIndex(e => e.IdRole)
                    .HasName("fkuser_role");

                entity.HasIndex(e => e.Username)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdDwelling)
                    .HasColumnName("id_dwelling")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.IdOptionalRole)
                    .HasColumnName("id_optionalRole")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdResidentialComplex)
                    .HasColumnName("id_residentialComplex")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.IdRole)
                    .HasColumnName("id_role")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Tenure)
                    .HasColumnName("tenure")
                    .HasColumnType("enum('occupier','owner-occuppier')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdDwellingNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdDwelling)
                    .HasConstraintName("fkuser_dwelling");

                entity.HasOne(d => d.IdOptionalRoleNavigation)
                    .WithMany(p => p.UserIdOptionalRoleNavigation)
                    .HasForeignKey(d => d.IdOptionalRole)
                    .HasConstraintName("fkuser_optionalRole");

                entity.HasOne(d => d.IdResidentialComplexNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdResidentialComplex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkuser_residentialComplex");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserIdRoleNavigation)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkuser_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
