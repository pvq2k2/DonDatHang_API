using DonDatHang_API.Entities;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.LoaiSanPhamRequest;

namespace DonDatHang_API.Handle.Converter
{
    public class LoaiSanPhamConverter
    {
        public LoaiSanPhamDTO EntityLoaiSanPhamToDTO(LoaiSanPham loaiSanPham)
        {
            return new LoaiSanPhamDTO {
                TenLoaiSanPham = loaiSanPham.TenLoaiSanPham
            };
        }

        public List<LoaiSanPhamDTO> ListLoaiSanPhamToDTO(List<LoaiSanPham> listLoaiSanPham)
        {
            var listLoaiSanPhamDTO = new List<LoaiSanPhamDTO>();
            foreach (var loaiSanPham in listLoaiSanPham)
            {
                listLoaiSanPhamDTO.Add(EntityLoaiSanPhamToDTO(loaiSanPham));
            }

            return listLoaiSanPhamDTO;
        }

        public LoaiSanPham CreateLoaiSanPham(CreateLoaiSanPhamRequest request)
        {
            return new LoaiSanPham {
                TenLoaiSanPham = request.TenLoaiSanPham
            };
        }

        public LoaiSanPham UpdateLoaiSanPham(LoaiSanPham loaiSanPham, UpdateLoaiSanPhamRequest request)
        {
            loaiSanPham.TenLoaiSanPham = request.TenLoaiSanPham;

            return loaiSanPham;
        }
    }
}
