using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DevNot21.Entities;

/// <summary>
/// Scaffold-DbContext 'Server=LAPTOP-M5JK3RPB;Database=ABYS_PROD;Trusted_Connection=True;' Microsoft.EntityFrameworkCore.SqlServer -ContextDir "Entities\DbContexts" -OutputDir "Entities"
/// </summary>
namespace DevNot21.Entities.DbContexts
{
    public partial class ABYS_PRODContext : DbContext
    {
        public ABYS_PRODContext()
        {
        }

        public ABYS_PRODContext(DbContextOptions<ABYS_PRODContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbAbone> AbAbones { get; set; } = null!;
        public virtual DbSet<AbAboneGrubu> AbAboneGrubus { get; set; } = null!;
        public virtual DbSet<AbAboneTipi> AbAboneTipis { get; set; } = null!;
        public virtual DbSet<CompaniesInfo> CompaniesInfos { get; set; } = null!;
        public virtual DbSet<DbMenu> DbMenus { get; set; } = null!;
        public virtual DbSet<DbRole> DbRoles { get; set; } = null!;
        public virtual DbSet<DbRoleMenu> DbRoleMenus { get; set; } = null!;
        public virtual DbSet<DbSecurityAction> DbSecurityActions { get; set; } = null!;
        public virtual DbSet<DbSecurityController> DbSecurityControllers { get; set; } = null!;
        public virtual DbSet<DbSecurityRole> DbSecurityRoles { get; set; } = null!;
        public virtual DbSet<DbSecurityUserAction> DbSecurityUserActions { get; set; } = null!;
        public virtual DbSet<DbSecurityUserRole> DbSecurityUserRoles { get; set; } = null!;
        public virtual DbSet<DbUser> DbUsers { get; set; } = default!;
        public virtual DbSet<DbUser2> DbUser2s { get; set; } = null!;
        public virtual DbSet<DbUser2017> DbUser2017s { get; set; } = null!;
        public virtual DbSet<DbUser2018> DbUser2018s { get; set; } = null!;
        public virtual DbSet<DbUser2019> DbUser2019s { get; set; } = null!;
        public virtual DbSet<DbUserMenu> DbUserMenus { get; set; } = null!;
        public virtual DbSet<GnBolge> GnBolges { get; set; } = null!;
        public virtual DbSet<GnSozlesmeTipi> GnSozlesmeTipis { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleGroup> RoleGroups { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<ViewAbone> ViewAbones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-M5JK3RPB;Database=ABYS_PROD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbAbone>(entity =>
            {
                entity.HasKey(e => e.IdAbone);

                entity.ToTable("AB_ABONE");

                entity.Property(e => e.IdAbone)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AboneAdi).HasMaxLength(250);

                entity.Property(e => e.AboneNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AboneSoyadi).HasMaxLength(250);

                entity.Property(e => e.AcikAdres).HasMaxLength(500);

                entity.Property(e => e.KimlikNo).HasMaxLength(50);

                entity.Property(e => e.SozlesmeBaslangicTarihi).HasColumnType("date");

                entity.Property(e => e.SozlesmeBitisTarihi).HasColumnType("date");

                entity.Property(e => e.SozlesmeNo).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdAboneTipiNavigation)
                    .WithMany(p => p.AbAbones)
                    .HasForeignKey(d => d.IdAboneTipi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AB_ABONE_TIPI_IdAboneTipi");

                entity.HasOne(d => d.IdBolgeNavigation)
                    .WithMany(p => p.AbAbones)
                    .HasForeignKey(d => d.IdBolge)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GN_BOLGE_IdBolge");

                entity.HasOne(d => d.IdSozlesmeTipiNavigation)
                    .WithMany(p => p.AbAbones)
                    .HasForeignKey(d => d.IdSozlesmeTipi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GN_SOZLESME_TIPI_IdSozlesmeTipi");
            });

            modelBuilder.Entity<AbAboneGrubu>(entity =>
            {
                entity.HasKey(e => e.IdAboneGrubu);

                entity.ToTable("AB_ABONE_GRUBU");

                entity.Property(e => e.AboneGrubuAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<AbAboneTipi>(entity =>
            {
                entity.HasKey(e => e.IdAboneTipi);

                entity.ToTable("AB_ABONE_TIPI");

                entity.Property(e => e.AboneTipiAdi).HasMaxLength(100);

                entity.Property(e => e.SabitAl).HasMaxLength(50);
            });

            modelBuilder.Entity<CompaniesInfo>(entity =>
            {
                entity.ToTable("Companies_Info");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(500)
                    .HasColumnName("Company_Name");

                entity.Property(e => e.CompanyNumber).HasColumnName("Company_Number");

                entity.Property(e => e.ConnName)
                    .HasMaxLength(500)
                    .HasColumnName("Conn_Name");

                entity.Property(e => e.ConnStr)
                    .HasMaxLength(500)
                    .HasColumnName("Conn_Str");
            });

            modelBuilder.Entity<DbMenu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.ToTable("DB_MENU");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageClass).HasMaxLength(75);

                entity.Property(e => e.MenuName).HasMaxLength(150);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.RoutingPath).HasMaxLength(255);
            });

            modelBuilder.Entity<DbRole>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("DB_ROLE");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<DbRoleMenu>(entity =>
            {
                entity.HasKey(e => e.IdRoleMenu);

                entity.ToTable("DB_ROLE_MENU");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DbSecurityAction>(entity =>
            {
                entity.HasKey(e => e.IdSecurityAction);

                entity.ToTable("DB_SECURITY_ACTION");

                entity.Property(e => e.ActionName).HasMaxLength(100);

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.OpenStatus).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdSecurityControllerNavigation)
                    .WithMany(p => p.DbSecurityActions)
                    .HasForeignKey(d => d.IdSecurityController)
                    .HasConstraintName("FK_DB_SECURITY_ACTION_DB_SECURITY_CONTROLLER");
            });

            modelBuilder.Entity<DbSecurityController>(entity =>
            {
                entity.HasKey(e => e.IdSecurityController);

                entity.ToTable("DB_SECURITY_CONTROLLER");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.ControllerName).HasMaxLength(100);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DbSecurityRole>(entity =>
            {
                entity.HasKey(e => e.IdSecurityRole);

                entity.ToTable("DB_SECURITY_ROLE");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.SecurityRoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<DbSecurityUserAction>(entity =>
            {
                entity.HasKey(e => e.IdSecurityUserAction);

                entity.ToTable("DB_SECURITY_USER_ACTION");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdSecurityControllerNavigation)
                    .WithMany(p => p.DbSecurityUserActions)
                    .HasForeignKey(d => d.IdSecurityController)
                    .HasConstraintName("FK_DB_SECURITY_USER_ACTION_DB_SECURITY_CONTROLLER");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.DbSecurityUserActions)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_DB_SECURITY_USER_ACTION_DB_USER");
            });

            modelBuilder.Entity<DbSecurityUserRole>(entity =>
            {
                entity.HasKey(e => e.IdSecurityUserRole);

                entity.ToTable("DB_SECURITY_USER_ROLE");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdSecurityControllerNavigation)
                    .WithMany(p => p.DbSecurityUserRoles)
                    .HasForeignKey(d => d.IdSecurityController)
                    .HasConstraintName("FK_DB_SECURITY_USER_ROLE_DB_SECURITY_CONTROLLER");

                entity.HasOne(d => d.IdSecurityRoleNavigation)
                    .WithMany(p => p.DbSecurityUserRoles)
                    .HasForeignKey(d => d.IdSecurityRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DB_SECURITY_USER_ROLE_DB_SECURITY_ROLE");
            });

            modelBuilder.Entity<DbUser>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("DB_USER");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsRoleLock).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSecurityRoleNavigation)
                    .WithMany(p => p.DbUsers)
                    .HasForeignKey(d => d.IdSecurityRole)
                    .HasConstraintName("FK_DB_USER_DB_SECURITY_ROLE");
            });

            modelBuilder.Entity<DbUser2>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("DB_USER2");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSecurityRoleNavigation)
                    .WithMany(p => p.DbUser2s)
                    .HasForeignKey(d => d.IdSecurityRole)
                    .HasConstraintName("FK_DB_USER2_DB_SECURITY_ROLE");
            });

            modelBuilder.Entity<DbUser2017>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("DB_USER2017");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSecurityRoleNavigation)
                    .WithMany(p => p.DbUser2017s)
                    .HasForeignKey(d => d.IdSecurityRole)
                    .HasConstraintName("FK_DB_USER2017_DB_SECURITY_ROLE");
            });

            modelBuilder.Entity<DbUser2018>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("DB_USER2018");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSecurityRoleNavigation)
                    .WithMany(p => p.DbUser2018s)
                    .HasForeignKey(d => d.IdSecurityRole)
                    .HasConstraintName("FK_DB_USER2018_DB_SECURITY_ROLE");
            });

            modelBuilder.Entity<DbUser2019>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("DB_USER2019");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSecurityRoleNavigation)
                    .WithMany(p => p.DbUser2019s)
                    .HasForeignKey(d => d.IdSecurityRole)
                    .HasConstraintName("FK_DB_USER2019_DB_SECURITY_ROLE");
            });

            modelBuilder.Entity<DbUserMenu>(entity =>
            {
                entity.HasKey(e => e.IdUserMenu);

                entity.ToTable("DB_USER_MENU");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GnBolge>(entity =>
            {
                entity.HasKey(e => e.IdBolge);

                entity.ToTable("GN_BOLGE");

                entity.Property(e => e.BolgeAdi).HasMaxLength(250);

                entity.Property(e => e.BolgeKodu).HasMaxLength(10);

                entity.Property(e => e.EfaturaIban).HasMaxLength(50);

                entity.Property(e => e.FirmaAdi).HasMaxLength(250);

                entity.Property(e => e.FirmaKisaAdi).HasMaxLength(50);

                entity.Property(e => e.Vkn).HasMaxLength(10);
            });

            modelBuilder.Entity<GnSozlesmeTipi>(entity =>
            {
                entity.HasKey(e => e.IdSozlesmeTipi);

                entity.ToTable("GN_SOZLESME_TIPI");

                entity.Property(e => e.SozlesmeTipiAdi).HasMaxLength(250);

                entity.Property(e => e.SozlesmeTipiKodu).HasMaxLength(2);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Roles_RoleGroups");
            });

            modelBuilder.Entity<RoleGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleGroupId).HasColumnName("RoleGroupID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.RoleGroup)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleGroupId)
                    .HasConstraintName("FK_UserRoles_RoleGroups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            modelBuilder.Entity<ViewAbone>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_ABONE");

                entity.Property(e => e.AboneNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FirmaKisaAdi).HasMaxLength(50);

                entity.Property(e => e.SozlesmeNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SozlesmeTipiAdi).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
