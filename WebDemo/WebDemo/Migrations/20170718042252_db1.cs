using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebDemo.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "xNgonNgu",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: true),
                    EN = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    VN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xNgonNgu", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "xNhanVien",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xNhanVien", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "xNhomQuyen",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xNhomQuyen", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "xChiTietQuyen",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDNhanVien = table.Column<int>(nullable: false),
                    IDNhomQuyen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xChiTietQuyen", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "xQuyen",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xQuyen", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "xTaiKhoan",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    IDNhanVien = table.Column<int>(nullable: false),
                    NhanVien = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xTaiKhoan", x => x.KeyID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "xNgonNgu");

            migrationBuilder.DropTable(
                name: "xNhanVien");

            migrationBuilder.DropTable(
                name: "xNhomQuyen");

            migrationBuilder.DropTable(
                name: "xChiTietQuyen");

            migrationBuilder.DropTable(
                name: "xQuyen");

            migrationBuilder.DropTable(
                name: "xTaiKhoan");
        }
    }
}
