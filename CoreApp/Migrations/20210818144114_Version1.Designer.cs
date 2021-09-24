﻿// <auto-generated />
using System;
using CoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreApp.Migrations
{
    [DbContext(typeof(ASC_TASK_PLANNINGContext))]
    [Migration("20210818144114_Version1")]
    partial class Version1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreApp.Models.AclAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdmanHinh")
                        .HasColumnType("int")
                        .HasColumnName("IDManHinh");

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("TenAction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChucNang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenController")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdmanHinh");

                    b.ToTable("ACL_Action");
                });

            modelBuilder.Entity("CoreApp.Models.AclManHinh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<int>("SoThuTu")
                        .HasColumnType("int");

                    b.Property<string>("TenAction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenController")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenManHinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ACL_ManHinh");
                });

            modelBuilder.Entity("CoreApp.Models.AclNguoiDung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<int>("IdnhanSu")
                        .HasColumnType("int")
                        .HasColumnName("IDNhanSu");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdnhanSu");

                    b.ToTable("ACL_NguoiDung");
                });

            modelBuilder.Entity("CoreApp.Models.AclNhomNguoiDung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiDung")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiDung");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<int>("IdvaiTro")
                        .HasColumnType("int")
                        .HasColumnName("IDVaiTro");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdnguoiDung");

                    b.HasIndex("IdvaiTro");

                    b.ToTable("ACL_NhomNguoiDung");
                });

            modelBuilder.Entity("CoreApp.Models.AclPhanQuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idaction")
                        .HasColumnType("int")
                        .HasColumnName("IDAction");

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<int>("IdvaiTro")
                        .HasColumnType("int")
                        .HasColumnName("IDVaiTro");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Idaction");

                    b.HasIndex("IdvaiTro");

                    b.ToTable("ACL_PhanQuyen");
                });

            modelBuilder.Entity("CoreApp.Models.AclVaiTro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("TenVaiTro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ACL_VaiTro");
                });

            modelBuilder.Entity("CoreApp.Models.CvCongViecThang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnumChatLuong")
                        .HasColumnType("int");

                    b.Property<int>("EnumKhoiLuong")
                        .HasColumnType("int");

                    b.Property<int>("EnumTienDo")
                        .HasColumnType("int");

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<int>("IdnhanSu")
                        .HasColumnType("int")
                        .HasColumnName("IDNhanSu");

                    b.Property<int>("Idthang")
                        .HasColumnType("int")
                        .HasColumnName("IDThang");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("NhanXetThang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdnhanSu");

                    b.HasIndex("Idthang");

                    b.ToTable("CV_CongViecThang");
                });

            modelBuilder.Entity("CoreApp.Models.CvCongViecTuan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnumChatLuong")
                        .HasColumnType("int");

                    b.Property<int>("EnumKhoiLuong")
                        .HasColumnType("int");

                    b.Property<int>("EnumTienDo")
                        .HasColumnType("int");

                    b.Property<int>("IdcongViecThang")
                        .HasColumnType("int")
                        .HasColumnName("IDCongViecThang");

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<int>("IdnhanSu")
                        .HasColumnType("int")
                        .HasColumnName("IDNhanSu");

                    b.Property<int>("Idtuan")
                        .HasColumnType("int")
                        .HasColumnName("IDTuan");

                    b.Property<bool>("IsDaDuyet")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("NhanXetTuan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdcongViecThang");

                    b.HasIndex("Idtuan");

                    b.ToTable("CV_CongViecTuan");
                });

            modelBuilder.Entity("CoreApp.Models.CvGiaoViec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnumNguocGocCongViec")
                        .HasColumnType("int");

                    b.Property<int>("EnumTrangThaiCongViec")
                        .HasColumnType("int");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GiaoDenNgay")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("GiaoTuNgay")
                        .HasColumnType("datetime");

                    b.Property<int>("IdcongViecTuan")
                        .HasColumnType("int")
                        .HasColumnName("IDCongViecTuan");

                    b.Property<int?>("IdgiaoViecCopiedFrom")
                        .HasColumnType("int")
                        .HasColumnName("IDGiaoViecCopiedFrom");

                    b.Property<int>("Idmodule")
                        .HasColumnType("int")
                        .HasColumnName("IDModule");

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayHoanThanh")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("TenCongViec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenIssue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("ThoiGianLam")
                        .HasColumnType("tinyint");

                    b.Property<string>("UrlIssue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdcongViecTuan");

                    b.HasIndex("Idmodule");

                    b.ToTable("CV_GiaoViec");
                });

            modelBuilder.Entity("CoreApp.Models.DmModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<int>("SoThuTu")
                        .HasColumnType("int");

                    b.Property<string>("TenModule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DM_Module");
                });

            modelBuilder.Entity("CoreApp.Models.DmThang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GiaTri")
                        .HasColumnType("int");

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<int>("Nam")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("TenThang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DM_Thang");
                });

            modelBuilder.Entity("CoreApp.Models.DmTuan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DenNgay")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<int>("Idthang")
                        .HasColumnType("int")
                        .HasColumnName("IDThang");

                    b.Property<bool>("IsDaKhoa")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<int>("SoGioLam")
                        .HasColumnType("int");

                    b.Property<int>("SoThuTu")
                        .HasColumnType("int");

                    b.Property<string>("TenTuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TuNgay")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Idthang");

                    b.ToTable("DM_Tuan");
                });

            modelBuilder.Entity("CoreApp.Models.NsNhanSu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoDem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdnguoiCapNhat")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiCapNhat");

                    b.Property<int>("IdnguoiTao")
                        .HasColumnType("int")
                        .HasColumnName("IDNguoiTao");

                    b.Property<int>("MaNhanSu")
                        .HasColumnType("int");

                    b.Property<int>("NamSinh")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NS_NhanSu");
                });

            modelBuilder.Entity("CoreApp.Models.AclAction", b =>
                {
                    b.HasOne("CoreApp.Models.AclManHinh", "IdmanHinhNavigation")
                        .WithMany("AclActions")
                        .HasForeignKey("IdmanHinh")
                        .HasConstraintName("FK__ACL_Actio__IDMan__4316F928")
                        .IsRequired();

                    b.Navigation("IdmanHinhNavigation");
                });

            modelBuilder.Entity("CoreApp.Models.AclNguoiDung", b =>
                {
                    b.HasOne("CoreApp.Models.NsNhanSu", "IdnhanSuNavigation")
                        .WithMany("AclNguoiDungs")
                        .HasForeignKey("IdnhanSu")
                        .HasConstraintName("FK__ACL_Nguoi__IDNha__38996AB5")
                        .IsRequired();

                    b.Navigation("IdnhanSuNavigation");
                });

            modelBuilder.Entity("CoreApp.Models.AclNhomNguoiDung", b =>
                {
                    b.HasOne("CoreApp.Models.AclNguoiDung", "IdnguoiDungNavigation")
                        .WithMany("AclNhomNguoiDungs")
                        .HasForeignKey("IdnguoiDung")
                        .HasConstraintName("FK__ACL_NhomN__IDNgu__3D5E1FD2")
                        .IsRequired();

                    b.HasOne("CoreApp.Models.AclVaiTro", "IdvaiTroNavigation")
                        .WithMany("AclNhomNguoiDungs")
                        .HasForeignKey("IdvaiTro")
                        .HasConstraintName("FK__ACL_NhomN__IDVai__3E52440B")
                        .IsRequired();

                    b.Navigation("IdnguoiDungNavigation");

                    b.Navigation("IdvaiTroNavigation");
                });

            modelBuilder.Entity("CoreApp.Models.AclPhanQuyen", b =>
                {
                    b.HasOne("CoreApp.Models.AclAction", "IdactionNavigation")
                        .WithMany("AclPhanQuyens")
                        .HasForeignKey("Idaction")
                        .HasConstraintName("FK__ACL_PhanQ__IDAct__46E78A0C")
                        .IsRequired();

                    b.HasOne("CoreApp.Models.AclVaiTro", "IdvaiTroNavigation")
                        .WithMany("AclPhanQuyens")
                        .HasForeignKey("IdvaiTro")
                        .HasConstraintName("FK__ACL_PhanQ__IDVai__45F365D3")
                        .IsRequired();

                    b.Navigation("IdactionNavigation");

                    b.Navigation("IdvaiTroNavigation");
                });

            modelBuilder.Entity("CoreApp.Models.CvCongViecThang", b =>
                {
                    b.HasOne("CoreApp.Models.NsNhanSu", "IdnhanSuNavigation")
                        .WithMany("CvCongViecThangs")
                        .HasForeignKey("IdnhanSu")
                        .HasConstraintName("FK__CV_CongVi__IDNha__2B3F6F97")
                        .IsRequired();

                    b.HasOne("CoreApp.Models.DmThang", "IdthangNavigation")
                        .WithMany("CvCongViecThangs")
                        .HasForeignKey("Idthang")
                        .HasConstraintName("FK__CV_CongVi__IDTha__2A4B4B5E")
                        .IsRequired();

                    b.Navigation("IdnhanSuNavigation");

                    b.Navigation("IdthangNavigation");
                });

            modelBuilder.Entity("CoreApp.Models.CvCongViecTuan", b =>
                {
                    b.HasOne("CoreApp.Models.CvCongViecThang", "IdcongViecThangNavigation")
                        .WithMany("CvCongViecTuans")
                        .HasForeignKey("IdcongViecThang")
                        .HasConstraintName("FK__CV_CongVi__IDCon__30F848ED")
                        .IsRequired();

                    b.HasOne("CoreApp.Models.DmTuan", "IdtuanNavigation")
                        .WithMany("CvCongViecTuans")
                        .HasForeignKey("Idtuan")
                        .HasConstraintName("FK__CV_CongVi__IDTua__31EC6D26")
                        .IsRequired();

                    b.Navigation("IdcongViecThangNavigation");

                    b.Navigation("IdtuanNavigation");
                });

            modelBuilder.Entity("CoreApp.Models.CvGiaoViec", b =>
                {
                    b.HasOne("CoreApp.Models.CvCongViecTuan", "IdcongViecTuanNavigation")
                        .WithMany("CvGiaoViecs")
                        .HasForeignKey("IdcongViecTuan")
                        .HasConstraintName("FK__CV_GiaoVi__IDCon__34C8D9D1")
                        .IsRequired();

                    b.HasOne("CoreApp.Models.DmModule", "IdmoduleNavigation")
                        .WithMany("CvGiaoViecs")
                        .HasForeignKey("Idmodule")
                        .HasConstraintName("FK__CV_GiaoVi__IDMod__35BCFE0A")
                        .IsRequired();

                    b.Navigation("IdcongViecTuanNavigation");

                    b.Navigation("IdmoduleNavigation");
                });

            modelBuilder.Entity("CoreApp.Models.DmTuan", b =>
                {
                    b.HasOne("CoreApp.Models.DmThang", "IdthangNavigation")
                        .WithMany("DmTuans")
                        .HasForeignKey("Idthang")
                        .HasConstraintName("FK__DM_Tuan__IDThang__2E1BDC42")
                        .IsRequired();

                    b.Navigation("IdthangNavigation");
                });

            modelBuilder.Entity("CoreApp.Models.AclAction", b =>
                {
                    b.Navigation("AclPhanQuyens");
                });

            modelBuilder.Entity("CoreApp.Models.AclManHinh", b =>
                {
                    b.Navigation("AclActions");
                });

            modelBuilder.Entity("CoreApp.Models.AclNguoiDung", b =>
                {
                    b.Navigation("AclNhomNguoiDungs");
                });

            modelBuilder.Entity("CoreApp.Models.AclVaiTro", b =>
                {
                    b.Navigation("AclNhomNguoiDungs");

                    b.Navigation("AclPhanQuyens");
                });

            modelBuilder.Entity("CoreApp.Models.CvCongViecThang", b =>
                {
                    b.Navigation("CvCongViecTuans");
                });

            modelBuilder.Entity("CoreApp.Models.CvCongViecTuan", b =>
                {
                    b.Navigation("CvGiaoViecs");
                });

            modelBuilder.Entity("CoreApp.Models.DmModule", b =>
                {
                    b.Navigation("CvGiaoViecs");
                });

            modelBuilder.Entity("CoreApp.Models.DmThang", b =>
                {
                    b.Navigation("CvCongViecThangs");

                    b.Navigation("DmTuans");
                });

            modelBuilder.Entity("CoreApp.Models.DmTuan", b =>
                {
                    b.Navigation("CvCongViecTuans");
                });

            modelBuilder.Entity("CoreApp.Models.NsNhanSu", b =>
                {
                    b.Navigation("AclNguoiDungs");

                    b.Navigation("CvCongViecThangs");
                });
#pragma warning restore 612, 618
        }
    }
}
