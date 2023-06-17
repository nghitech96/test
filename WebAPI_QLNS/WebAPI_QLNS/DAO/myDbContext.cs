using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Principal;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Helpers;

namespace WebAPI_QLNS.DAO
{
    public partial class myDbContext:DbContext
    {
        string DbConnection = "";
        //private IConfigurationManager configurationManager;
        public myDbContext()
        {
            DbConnection = AppSetting.ConnectString;// ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public myDbContext(DbContextOptions<myDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=myShop;Integrated Security=True");
                optionsBuilder.UseSqlServer(DbConnection);
            }
        }

        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<VaiTro> VaiTro{ get; set; }

        public virtual DbSet<TheLoai> TheLoai { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<QuyDinh> QuyDinh { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<PhieuNhapSach> PhieuNhapSach { get; set; }
        public virtual DbSet<PhieuThuTien> PhieuThuTien { get; set; }
        public virtual DbSet<HoaDonBanHang> HoaDonBanHang { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<ChiTietNhapSach> ChiTietNhapSach { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.NguoiDungId);
                entity.Property(e => e.TaiKhoan).IsUnicode(false);

                entity.Property(e => e.TaiKhoan).IsUnicode(true);

                entity.Property(e => e.MatKhau).IsUnicode(true);

                entity.Property(e => e.TrangThai).IsUnicode(true);
                entity.Property(e => e.VaiTroId).IsUnicode(true);
                entity.Property(e => e.NhanVienId).IsUnicode(true);

                //entity.HasOne<NhanVien>(n => n.NhanVien)
                //.WithMany(a => a.NguoiDungs)
                //.HasForeignKey(k => k.NhanVienId);
            });
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TenNhanVien).IsUnicode(true);
                entity.Property(e => e.ChucVu).IsUnicode(true);
                entity.Property(e => e.Email).IsUnicode(true);
                entity.Property(e => e.SoDT).IsUnicode(true);

                //entity.HasMany<NguoiDung>(n => n.NguoiDungs)
                //.WithOne(e => e.NhanVien)
                //.HasForeignKey(k => k.NhanVienId);

            });

            modelBuilder.Entity<VaiTro>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TenVaiTro).IsUnicode(true);

            });

            modelBuilder.Entity<QuyDinh>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ten).IsUnicode(true);
                entity.Property(e => e.GiaTri).IsUnicode(true);
                entity.Property(e => e.Kieu).IsUnicode(true);

            });
            modelBuilder.Entity<TheLoai>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ten).IsUnicode(true);

                entity.HasMany<Sach>(s => s.Saches)
                .WithOne(t => t.TheLoai)
                .HasForeignKey(k => k.IdTheLoai);
            });
            modelBuilder.Entity<TacGia>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ten).IsUnicode(true);

                entity.HasMany<Sach>(s => s.Saches)
                .WithOne(t => t.TacGia)
                .HasForeignKey(k => k.IdTacGia);
            });
            
            modelBuilder.Entity<KhachHang>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ten).IsUnicode(true);
                entity.Property(e => e.DiaChi).IsUnicode(true);
                entity.Property(e => e.DienThoai).IsUnicode(true);
                entity.Property(e => e.Email).IsUnicode(true);

                entity.HasMany<HoaDonBanHang>(h => h.HoaDonBanHangs)
                .WithOne(t => t.KhachHang)
                .HasForeignKey(k => k.IdKhachHang);
            });
            modelBuilder.Entity<HoaDonBanHang>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ngay).IsUnicode(true);
                entity.Property(e => e.IdKhachHang).IsUnicode(false);
                entity.Property(e => e.ThanhTien).IsUnicode(false);

                entity.HasMany<ChiTietHoaDon>(h => h.ChiTietHoaDons)
                .WithOne(t => t.HoaDonBanHang)
                .HasForeignKey(k => k.IdHoaDon);
                entity.HasOne<KhachHang>(k => k.KhachHang)
                .WithMany(h => h.HoaDonBanHangs)
                .HasForeignKey(k => k.IdKhachHang);
            });
            modelBuilder.Entity<ChiTietHoaDon>(entity => {
                entity.HasKey(e => e.Id);
                //entity.HasKey(e => e.IdHoaDon);
                //entity.HasKey(e => e.IdSach);

                entity.Property(e => e.IdHoaDon).IsUnicode(true);
                entity.Property(e => e.IdSach).IsUnicode(true);
                entity.Property(e => e.SoLuong).IsUnicode(true);
                entity.Property(e => e.DonGia).IsUnicode(true);


                entity.HasOne<HoaDonBanHang>(h => h.HoaDonBanHang)
                .WithMany(t => t.ChiTietHoaDons)
                .HasForeignKey(k => k.IdHoaDon);

                entity.HasOne<Sach>(s => s.Sach)
                .WithMany(h => h.ChiTietHoaDons)
                .HasForeignKey(k => k.IdSach);
            });

            modelBuilder.Entity<PhieuNhapSach>(entity => {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).IsUnicode(true);
                entity.Property(e => e.Ngay).IsUnicode(true);

                entity.HasMany<ChiTietNhapSach>(h => h.ChiTietNhapSaches)
                .WithOne(t => t.PhieuNhapSach)
                .HasForeignKey(k => k.IdPhieuNhap);
            });
            modelBuilder.Entity<ChiTietNhapSach>(entity => {

                entity.HasKey(e => e.Id);
                //entity.HasKey(e => e.IdPhieuNhap);
                //entity.HasKey(e => e.IdSach);

                entity.Property(e => e.IdPhieuNhap).IsUnicode(true);
                entity.Property(e => e.IdSach).IsUnicode(true);
                entity.Property(e => e.SoLuong).IsUnicode(true);

                entity.HasOne<PhieuNhapSach>(h => h.PhieuNhapSach)
                    .WithMany(c => c.ChiTietNhapSaches)
                    .HasForeignKey(k => k.IdPhieuNhap);

                entity.HasOne<Sach>(s => s.Sach)
                    .WithMany(c => c.ChiTietNhapSachs)
                    .HasForeignKey(k => k.IdSach);
            });

            modelBuilder.Entity<PhieuThuTien>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).IsUnicode(true);
                entity.Property(e => e.Tien).IsUnicode(true);
                entity.Property(e => e.IdKhachHang).IsUnicode(true);
                entity.Property(e => e.Ngay).IsUnicode(true);
                entity.HasOne<KhachHang>(k => k.KhachHang)
                    .WithMany(p => p.PhieuThuTiens)
                    .HasForeignKey(k => k.IdKhachHang);

            });
                modelBuilder.Entity<Sach>(entity => {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Ten).IsUnicode(true);
                entity.Property(e => e.IdTheLoai).IsUnicode(true);
                entity.Property(e => e.IdTacGia).IsUnicode(true);
                entity.Property(e => e.SoluongTon).IsUnicode(true);

                entity.HasOne<TheLoai>(h => h.TheLoai)
                    .WithMany(c => c.Saches)
                    .HasForeignKey(k => k.IdTheLoai);
                entity.HasOne<TacGia>(s => s.TacGia)
                    .WithMany(c => c.Saches)
                    .HasForeignKey(k => k.IdTacGia);
                entity.HasMany<ChiTietNhapSach>(h => h.ChiTietNhapSachs)
                    .WithOne(t => t.Sach)
                    .HasForeignKey(k => k.IdSach);
                entity.HasMany<ChiTietHoaDon>(h => h.ChiTietHoaDons)
                    .WithOne(t => t.Sach)
                    .HasForeignKey(k => k.IdSach);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
