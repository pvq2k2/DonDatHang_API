﻿// <auto-generated />
using System;
using DonDatHang_API.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DonDatHang_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DonDatHang_API.Entities.ChiTietHoaDon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DVT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HoaDonID")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<double?>("ThanhTien")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("HoaDonID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.HoaDon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhachHangID")
                        .HasColumnType("int");

                    b.Property<string>("MaGiaoDich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHoaDon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ThoiGianCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("KhachHangID");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.KhachHang", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.LoaiSanPham", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TenLoaiSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("LoaiSanPham");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.SanPham", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("GiaThanh")
                        .HasColumnType("float");

                    b.Property<string>("KyHieuSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiSanPhamID")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayHetHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LoaiSanPhamID");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.ChiTietHoaDon", b =>
                {
                    b.HasOne("DonDatHang_API.Entities.HoaDon", "HoaDon")
                        .WithMany("ListChiTietHoaDon")
                        .HasForeignKey("HoaDonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DonDatHang_API.Entities.SanPham", "SanPham")
                        .WithMany("ListChiTietHoaDon")
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.HoaDon", b =>
                {
                    b.HasOne("DonDatHang_API.Entities.KhachHang", "KhachHang")
                        .WithMany("ListHoaDon")
                        .HasForeignKey("KhachHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.SanPham", b =>
                {
                    b.HasOne("DonDatHang_API.Entities.LoaiSanPham", "LoaiSanPham")
                        .WithMany("ListSanPham")
                        .HasForeignKey("LoaiSanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSanPham");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.HoaDon", b =>
                {
                    b.Navigation("ListChiTietHoaDon");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.KhachHang", b =>
                {
                    b.Navigation("ListHoaDon");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.LoaiSanPham", b =>
                {
                    b.Navigation("ListSanPham");
                });

            modelBuilder.Entity("DonDatHang_API.Entities.SanPham", b =>
                {
                    b.Navigation("ListChiTietHoaDon");
                });
#pragma warning restore 612, 618
        }
    }
}
