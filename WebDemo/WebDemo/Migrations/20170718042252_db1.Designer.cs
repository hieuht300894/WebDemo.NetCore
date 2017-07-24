using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebDemo.Model;

namespace WebDemo.Migrations
{
    [DbContext(typeof(zModel))]
    [Migration("20170718042252_db1")]
    partial class db1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityModel.Models.xNgonNgu", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<string>("EN");

                    b.Property<string>("FieldName");

                    b.Property<string>("VN");

                    b.HasKey("KeyID");

                    b.ToTable("xNgonNgu");
                });

            modelBuilder.Entity("EntityModel.Models.xNhanVien", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("KeyID");

                    b.ToTable("xNhanVien");
                });

            modelBuilder.Entity("EntityModel.Models.xNhomQuyen", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("KeyID");

                    b.ToTable("xNhomQuyen");
                });

            modelBuilder.Entity("EntityModel.Models.xPhanQuyen", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IDNhanVien");

                    b.Property<int>("IDNhomQuyen");

                    b.HasKey("KeyID");

                    b.ToTable("xChiTietQuyen");
                });

            modelBuilder.Entity("EntityModel.Models.xQuyen", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("KeyID");

                    b.ToTable("xQuyen");
                });

            modelBuilder.Entity("EntityModel.Models.xTaiKhoan", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int>("IDNhanVien");

                    b.Property<string>("NhanVien");

                    b.Property<string>("Password");

                    b.HasKey("KeyID");

                    b.ToTable("xTaiKhoan");
                });
        }
    }
}
