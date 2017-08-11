using EntityModel.Models;
using Microsoft.EntityFrameworkCore;

namespace WebDemo.Model
{
    public class zModel : DbContext
    {
        /*
         * 1. Add new DB
         * Add-Migration "Name not exist"
         * Enable-Migrations 
         * Update-Database –Verbose
         * -----------------------------------
         * 2. Update DB
         * Add-Migration "Name not exist"
         * Update-Database –Verbose
         */

        public zModel(DbContextOptions<zModel> option) : base(option) { }

        public zModel() { }

        public DbSet<xNhanVien> xNhanVien { get; set; }
        public DbSet<xTaiKhoan> xTaiKhoan { get; set; }
        public DbSet<xQuyen> xQuyen { get; set; }
        public DbSet<xNhomQuyen> xNhomQuyen { get; set; }
        public DbSet<xPhanQuyen> xChiTietQuyen { get; set; }
        public DbSet<xNgonNgu> xNgonNgu { get; set; }
        public DbSet<eDM_KhachHang> eDM_KhachHang { get; set; }
        public DbSet<eDM_NhomKhachHang> eDM_NhomKhachHang { get; set; }
        public DbSet<eDM_TinhThanh> eDM_TinhThanh { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region PrimaryKey
            modelBuilder.Entity<xNhanVien>().HasKey(e => e.KeyID);
            modelBuilder.Entity<xTaiKhoan>().HasKey(e => e.KeyID);
            modelBuilder.Entity<xQuyen>().HasKey(e => e.KeyID);
            modelBuilder.Entity<xNhomQuyen>().HasKey(e => e.KeyID);
            modelBuilder.Entity<xPhanQuyen>().HasKey(e => e.KeyID);
            modelBuilder.Entity<xNgonNgu>().HasKey(e => e.KeyID);
            modelBuilder.Entity<eDM_KhachHang>().HasKey(e => e.KeyID);
            modelBuilder.Entity<eDM_NhomKhachHang>().HasKey(e => e.KeyID);
            modelBuilder.Entity<eDM_TinhThanh>().HasKey(e => e.KeyID);
            #endregion

            #region FieldRequired
            modelBuilder.Entity<xTaiKhoan>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<xTaiKhoan>().Property(x => x.NhanVien).IsRequired();

            modelBuilder.Entity<xNhanVien>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<xNhanVien>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<xQuyen>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<xQuyen>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<xNhomQuyen>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<xNhomQuyen>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<eDM_KhachHang>().Property(x => x.Ma).IsRequired();
            modelBuilder.Entity<eDM_KhachHang>().Property(x => x.Ho).IsRequired();
            modelBuilder.Entity<eDM_KhachHang>().Property(x => x.Ten).IsRequired();
            modelBuilder.Entity<eDM_KhachHang>().Property(x => x.GioiTinh).IsRequired();

            modelBuilder.Entity<eDM_NhomKhachHang>().Property(x => x.Ma).IsRequired();
            modelBuilder.Entity<eDM_NhomKhachHang>().Property(x => x.Ten).IsRequired();

            //modelBuilder.Entity<eDM_TinhThanh>().Property(x => x.Ma).IsRequired();
            modelBuilder.Entity<eDM_TinhThanh>().Property(x => x.Ten).IsRequired();
            #endregion
        }
    }
}
