using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebDemo.Migrations
{
    public partial class db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NhanVien",
                table: "xTaiKhoan",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "xTaiKhoan",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "xQuyen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "xQuyen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "xNhomQuyen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "xNhomQuyen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "xNhanVien",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "xNhanVien",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "eDM_KhachHang",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: false),
                    HinhAnh = table.Column<byte[]>(nullable: true),
                    Ho = table.Column<string>(nullable: false),
                    IDGioiTinh = table.Column<int>(nullable: false),
                    IDNhomKhachHang = table.Column<int>(nullable: false),
                    IDTinhThanh = table.Column<int>(nullable: false),
                    Ma = table.Column<string>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    NhomKhachHang = table.Column<string>(nullable: true),
                    SoDienThoai = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: false),
                    TinhThanh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eDM_KhachHang", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "eDM_NhomKhachHang",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ma = table.Column<string>(nullable: false),
                    Ten = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eDM_NhomKhachHang", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "eDM_TinhThanh",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DienGiai = table.Column<string>(nullable: true),
                    IDTinhThanh = table.Column<int>(nullable: false),
                    LocationCode = table.Column<string>(nullable: true),
                    Ma = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: false),
                    TinhThanh = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eDM_TinhThanh", x => x.KeyID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eDM_KhachHang");

            migrationBuilder.DropTable(
                name: "eDM_NhomKhachHang");

            migrationBuilder.DropTable(
                name: "eDM_TinhThanh");

            migrationBuilder.AlterColumn<string>(
                name: "NhanVien",
                table: "xTaiKhoan",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "xTaiKhoan",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "xQuyen",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "xQuyen",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "xNhomQuyen",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "xNhomQuyen",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "xNhanVien",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "xNhanVien",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
