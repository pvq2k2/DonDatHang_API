using DonDatHang_API.Entities;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.SanPhamRequest;

namespace DonDatHang_API.Handle.Converter
{
    public class SanPhamConverter
    {
        public SanPhamDTO EntitySanPhamToDTO(SanPham sanPham)
        {
            return new SanPhamDTO
            {
                TenSanPham = sanPham.TenSanPham,
                GiaThanh = sanPham.GiaThanh,
                MoTa = sanPham.MoTa,
                NgayHetHan = sanPham.NgayHetHan,
                KyHieuSanPham = sanPham.KyHieuSanPham,
            };
        }

        public List<SanPhamDTO> ListEntitySanPhamToDTO(List<SanPham> listSanPham)
        {
            var listSanPhamDTO = new List<SanPhamDTO>();
            foreach (var sanPham in listSanPham)
            {
                listSanPhamDTO.Add(EntitySanPhamToDTO(sanPham));
            }

            return listSanPhamDTO;
        }

        public SanPham CreateSanPham(CreateSanPhamRequest request)
        {
            return new SanPham
            {
                TenSanPham = request.TenSanPham,
                GiaThanh = request.GiaThanh,
                MoTa = request.MoTa,
                NgayHetHan = request.NgayHetHan,
                KyHieuSanPham = request.KyHieuSanPham,
            };
        }

        public SanPham UpdateSanPham(SanPham sanPham, UpdateSanPhamRequest request)
        {
            sanPham.TenSanPham = request.TenSanPham;
            sanPham.GiaThanh = request.GiaThanh;
            sanPham.MoTa = request.MoTa;
            sanPham.NgayHetHan = request.NgayHetHan;
            sanPham.KyHieuSanPham = request.KyHieuSanPham;

            return sanPham;
        }
    }
}
