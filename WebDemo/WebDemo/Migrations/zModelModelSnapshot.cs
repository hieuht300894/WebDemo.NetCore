using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebDemo.Model;

namespace WebDemo.Migrations
{
    [DbContext(typeof(zModel))]
    partial class zModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityModel.Models.eDM_KhachHang", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiaChi");

                    b.Property<string>("Email");

                    b.Property<string>("GhiChu");

                    b.Property<string>("GioiTinh")
                        .IsRequired();

                    b.Property<byte[]>("HinhAnh");

                    b.Property<string>("Ho")
                        .IsRequired();

                    b.Property<int>("IDGioiTinh");

                    b.Property<int>("IDNhomKhachHang");

                    b.Property<int>("IDTinhThanh");

                    b.Property<string>("Ma")
                        .IsRequired();

                    b.Property<DateTime>("NgaySinh");

                    b.Property<string>("NhomKhachHang");

                    b.Property<string>("SoDienThoai");

                    b.Property<string>("Ten")
                        .IsRequired();

                    b.Property<string>("TinhThanh");

                    b.HasKey("KeyID");

                    b.ToTable("eDM_KhachHang");
                });

            modelBuilder.Entity("EntityModel.Models.eDM_NhomKhachHang", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ma")
                        .IsRequired();

                    b.Property<string>("Ten")
                        .IsRequired();

                    b.HasKey("KeyID");

                    b.ToTable("eDM_NhomKhachHang");
                });

            modelBuilder.Entity("EntityModel.Models.eDM_TinhThanh", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DienGiai");

                    b.Property<int>("IDLoai");

                    b.Property<int>("IDTinhThanh");

                    b.Property<string>("Loai");

                    b.Property<string>("LocationCode");

                    b.Property<string>("Ma");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Ten")
                        .IsRequired();

                    b.Property<string>("TinhThanh");

                    b.Property<string>("ZipCode");

                    b.HasKey("KeyID");

                    b.ToTable("eDM_TinhThanh");
                });

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

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("KeyID");

                    b.ToTable("xNhanVien");
                });

            modelBuilder.Entity("EntityModel.Models.xNhomQuyen", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

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

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("KeyID");

                    b.ToTable("xQuyen");
                });

            modelBuilder.Entity("EntityModel.Models.xTaiKhoan", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<int>("IDNhanVien");

                    b.Property<string>("NhanVien")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.HasKey("KeyID");

                    b.ToTable("xTaiKhoan");
                });
        }
    }
}
