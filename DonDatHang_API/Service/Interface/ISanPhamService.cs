using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.SanPhamRequest;
using DonDatHang_API.Handle.Response;

namespace DonDatHang_API.Service.Interface
{
    public interface ISanPhamService
    {
        public ResponseData<SanPhamDTO> GetAllSanPham();
        public ResponseData<SanPhamDTO> GetSanPhamByID(int sanPhamID);
        public ResponseData<SanPhamDTO> CreateSanPham(CreateSanPhamRequest request);
        public ResponseData<SanPhamDTO> UpdateSanPham(int sanPhamID, UpdateSanPhamRequest request);
        public ResponseData<ActionStatus> RemoveSanPham(int sanPhamID);
    }
}
