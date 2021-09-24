using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class Version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACL_ManHinh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenManHinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenController = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACL_ManHinh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACL_VaiTro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACL_VaiTro", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DM_Module",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenModule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_Module", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DM_Thang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime", nullable: false),
                    GiaTri = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_Thang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NS_NhanSu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanSu = table.Column<int>(type: "int", nullable: false),
                    HoDem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamSinh = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NS_NhanSu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACL_Action",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDManHinh = table.Column<int>(type: "int", nullable: false),
                    TenChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenController = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACL_Action", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ACL_Actio__IDMan__4316F928",
                        column: x => x.IDManHinh,
                        principalTable: "ACL_ManHinh",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DM_Tuan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDThang = table.Column<int>(type: "int", nullable: false),
                    TenTuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    DenNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    SoGioLam = table.Column<int>(type: "int", nullable: false),
                    IsDaKhoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_Tuan", x => x.ID);
                    table.ForeignKey(
                        name: "FK__DM_Tuan__IDThang__2E1BDC42",
                        column: x => x.IDThang,
                        principalTable: "DM_Thang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACL_NguoiDung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNhanSu = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACL_NguoiDung", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ACL_Nguoi__IDNha__38996AB5",
                        column: x => x.IDNhanSu,
                        principalTable: "NS_NhanSu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CV_CongViecThang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDThang = table.Column<int>(type: "int", nullable: false),
                    IDNhanSu = table.Column<int>(type: "int", nullable: false),
                    EnumKhoiLuong = table.Column<int>(type: "int", nullable: false),
                    EnumTienDo = table.Column<int>(type: "int", nullable: false),
                    EnumChatLuong = table.Column<int>(type: "int", nullable: false),
                    NhanXetThang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_CongViecThang", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CV_CongVi__IDNha__2B3F6F97",
                        column: x => x.IDNhanSu,
                        principalTable: "NS_NhanSu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CV_CongVi__IDTha__2A4B4B5E",
                        column: x => x.IDThang,
                        principalTable: "DM_Thang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACL_PhanQuyen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVaiTro = table.Column<int>(type: "int", nullable: false),
                    IDAction = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACL_PhanQuyen", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ACL_PhanQ__IDAct__46E78A0C",
                        column: x => x.IDAction,
                        principalTable: "ACL_Action",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ACL_PhanQ__IDVai__45F365D3",
                        column: x => x.IDVaiTro,
                        principalTable: "ACL_VaiTro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACL_NhomNguoiDung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVaiTro = table.Column<int>(type: "int", nullable: false),
                    IDNguoiDung = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACL_NhomNguoiDung", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ACL_NhomN__IDNgu__3D5E1FD2",
                        column: x => x.IDNguoiDung,
                        principalTable: "ACL_NguoiDung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ACL_NhomN__IDVai__3E52440B",
                        column: x => x.IDVaiTro,
                        principalTable: "ACL_VaiTro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CV_CongViecTuan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCongViecThang = table.Column<int>(type: "int", nullable: false),
                    IDTuan = table.Column<int>(type: "int", nullable: false),
                    IsDaDuyet = table.Column<bool>(type: "bit", nullable: false),
                    IDNhanSu = table.Column<int>(type: "int", nullable: false),
                    EnumKhoiLuong = table.Column<int>(type: "int", nullable: false),
                    EnumTienDo = table.Column<int>(type: "int", nullable: false),
                    EnumChatLuong = table.Column<int>(type: "int", nullable: false),
                    NhanXetTuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_CongViecTuan", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CV_CongVi__IDCon__30F848ED",
                        column: x => x.IDCongViecThang,
                        principalTable: "CV_CongViecThang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CV_CongVi__IDTua__31EC6D26",
                        column: x => x.IDTuan,
                        principalTable: "DM_Tuan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CV_GiaoViec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCongViecTuan = table.Column<int>(type: "int", nullable: false),
                    IDModule = table.Column<int>(type: "int", nullable: false),
                    EnumNguocGocCongViec = table.Column<int>(type: "int", nullable: false),
                    IDGiaoViecCopiedFrom = table.Column<int>(type: "int", nullable: true),
                    TenIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenCongViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianLam = table.Column<byte>(type: "tinyint", nullable: false),
                    EnumTrangThaiCongViec = table.Column<int>(type: "int", nullable: false),
                    GiaoTuNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    GiaoDenNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayHoanThanh = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDNguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDNguoiCapNhat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_GiaoViec", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CV_GiaoVi__IDCon__34C8D9D1",
                        column: x => x.IDCongViecTuan,
                        principalTable: "CV_CongViecTuan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CV_GiaoVi__IDMod__35BCFE0A",
                        column: x => x.IDModule,
                        principalTable: "DM_Module",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACL_Action_IDManHinh",
                table: "ACL_Action",
                column: "IDManHinh");

            migrationBuilder.CreateIndex(
                name: "IX_ACL_NguoiDung_IDNhanSu",
                table: "ACL_NguoiDung",
                column: "IDNhanSu");

            migrationBuilder.CreateIndex(
                name: "IX_ACL_NhomNguoiDung_IDNguoiDung",
                table: "ACL_NhomNguoiDung",
                column: "IDNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_ACL_NhomNguoiDung_IDVaiTro",
                table: "ACL_NhomNguoiDung",
                column: "IDVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_ACL_PhanQuyen_IDAction",
                table: "ACL_PhanQuyen",
                column: "IDAction");

            migrationBuilder.CreateIndex(
                name: "IX_ACL_PhanQuyen_IDVaiTro",
                table: "ACL_PhanQuyen",
                column: "IDVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CongViecThang_IDNhanSu",
                table: "CV_CongViecThang",
                column: "IDNhanSu");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CongViecThang_IDThang",
                table: "CV_CongViecThang",
                column: "IDThang");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CongViecTuan_IDCongViecThang",
                table: "CV_CongViecTuan",
                column: "IDCongViecThang");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CongViecTuan_IDTuan",
                table: "CV_CongViecTuan",
                column: "IDTuan");

            migrationBuilder.CreateIndex(
                name: "IX_CV_GiaoViec_IDCongViecTuan",
                table: "CV_GiaoViec",
                column: "IDCongViecTuan");

            migrationBuilder.CreateIndex(
                name: "IX_CV_GiaoViec_IDModule",
                table: "CV_GiaoViec",
                column: "IDModule");

            migrationBuilder.CreateIndex(
                name: "IX_DM_Tuan_IDThang",
                table: "DM_Tuan",
                column: "IDThang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACL_NhomNguoiDung");

            migrationBuilder.DropTable(
                name: "ACL_PhanQuyen");

            migrationBuilder.DropTable(
                name: "CV_GiaoViec");

            migrationBuilder.DropTable(
                name: "ACL_NguoiDung");

            migrationBuilder.DropTable(
                name: "ACL_Action");

            migrationBuilder.DropTable(
                name: "ACL_VaiTro");

            migrationBuilder.DropTable(
                name: "CV_CongViecTuan");

            migrationBuilder.DropTable(
                name: "DM_Module");

            migrationBuilder.DropTable(
                name: "ACL_ManHinh");

            migrationBuilder.DropTable(
                name: "CV_CongViecThang");

            migrationBuilder.DropTable(
                name: "DM_Tuan");

            migrationBuilder.DropTable(
                name: "NS_NhanSu");

            migrationBuilder.DropTable(
                name: "DM_Thang");
        }
    }
}
