using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreApp.Models
{
    public partial class ASC_TASK_PLANNINGContext : DbContext
    {
        public ASC_TASK_PLANNINGContext()
        {
        }

        public ASC_TASK_PLANNINGContext(DbContextOptions<ASC_TASK_PLANNINGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AclAction> AclActions { get; set; }
        public virtual DbSet<AclManHinh> AclManHinhs { get; set; }
        public virtual DbSet<AclNguoiDung> AclNguoiDungs { get; set; }
        public virtual DbSet<AclNhomNguoiDung> AclNhomNguoiDungs { get; set; }
        public virtual DbSet<AclPhanQuyen> AclPhanQuyens { get; set; }
        public virtual DbSet<AclVaiTro> AclVaiTros { get; set; }
        public virtual DbSet<CvCongViecThang> CvCongViecThangs { get; set; }
        public virtual DbSet<CvCongViecTuan> CvCongViecTuans { get; set; }
        public virtual DbSet<CvGiaoViec> CvGiaoViecs { get; set; }
        public virtual DbSet<DmModule> DmModules { get; set; }
        public virtual DbSet<DmThang> DmThangs { get; set; }
        public virtual DbSet<DmTuan> DmTuans { get; set; }
        public virtual DbSet<NsNhanSu> NsNhanSus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PC5R3OC;Initial Catalog=ASC_TASK_PLAN; User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AclAction>(entity =>
            {
                entity.HasOne(d => d.IdmanHinhNavigation)
                    .WithMany(p => p.AclActions)
                    .HasForeignKey(d => d.IdmanHinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACL_Actio__IDMan__4316F928");
            });

            modelBuilder.Entity<AclNguoiDung>(entity =>
            {
                entity.HasOne(d => d.IdnhanSuNavigation)
                    .WithMany(p => p.AclNguoiDungs)
                    .HasForeignKey(d => d.IdnhanSu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACL_Nguoi__IDNha__38996AB5");
            });

            modelBuilder.Entity<AclNhomNguoiDung>(entity =>
            {
                entity.HasOne(d => d.IdnguoiDungNavigation)
                    .WithMany(p => p.AclNhomNguoiDungs)
                    .HasForeignKey(d => d.IdnguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACL_NhomN__IDNgu__3D5E1FD2");

                entity.HasOne(d => d.IdvaiTroNavigation)
                    .WithMany(p => p.AclNhomNguoiDungs)
                    .HasForeignKey(d => d.IdvaiTro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACL_NhomN__IDVai__3E52440B");
            });

            modelBuilder.Entity<AclPhanQuyen>(entity =>
            {
                entity.HasOne(d => d.IdactionNavigation)
                    .WithMany(p => p.AclPhanQuyens)
                    .HasForeignKey(d => d.Idaction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACL_PhanQ__IDAct__46E78A0C");

                entity.HasOne(d => d.IdvaiTroNavigation)
                    .WithMany(p => p.AclPhanQuyens)
                    .HasForeignKey(d => d.IdvaiTro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACL_PhanQ__IDVai__45F365D3");
            });

            modelBuilder.Entity<CvCongViecThang>(entity =>
            {
                entity.HasOne(d => d.IdnhanSuNavigation)
                    .WithMany(p => p.CvCongViecThangs)
                    .HasForeignKey(d => d.IdnhanSu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CV_CongVi__IDNha__2B3F6F97");

                entity.HasOne(d => d.IdthangNavigation)
                    .WithMany(p => p.CvCongViecThangs)
                    .HasForeignKey(d => d.Idthang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CV_CongVi__IDTha__2A4B4B5E");
            });

            modelBuilder.Entity<CvCongViecTuan>(entity =>
            {
                entity.HasOne(d => d.IdcongViecThangNavigation)
                    .WithMany(p => p.CvCongViecTuans)
                    .HasForeignKey(d => d.IdcongViecThang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CV_CongVi__IDCon__30F848ED");

                entity.HasOne(d => d.IdtuanNavigation)
                    .WithMany(p => p.CvCongViecTuans)
                    .HasForeignKey(d => d.Idtuan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CV_CongVi__IDTua__31EC6D26");
            });

            modelBuilder.Entity<CvGiaoViec>(entity =>
            {
                entity.HasOne(d => d.IdcongViecTuanNavigation)
                    .WithMany(p => p.CvGiaoViecs)
                    .HasForeignKey(d => d.IdcongViecTuan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CV_GiaoVi__IDCon__34C8D9D1");

                entity.HasOne(d => d.IdmoduleNavigation)
                    .WithMany(p => p.CvGiaoViecs)
                    .HasForeignKey(d => d.Idmodule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CV_GiaoVi__IDMod__35BCFE0A");
            });

            modelBuilder.Entity<DmTuan>(entity =>
            {
                entity.HasOne(d => d.IdthangNavigation)
                    .WithMany(p => p.DmTuans)
                    .HasForeignKey(d => d.Idthang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DM_Tuan__IDThang__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
