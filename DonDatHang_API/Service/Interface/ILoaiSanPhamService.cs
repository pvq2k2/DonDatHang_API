using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.LoaiSanPhamRequest;
using DonDatHang_API.Handle.Response;

namespace DonDatHang_API.Service.Interface
{
    public interface ILoaiSanPhamService
    {
        public ResponseData<LoaiSanPhamDTO> GetAllLoaiSanPham();
        public ResponseData<LoaiSanPhamDTO> GetLoaiSanPhamByID(int loaiSanPhamID);
        public ResponseData<LoaiSanPhamDTO> CreateLoaiSanPham(CreateLoaiSanPhamRequest request);
        public ResponseData<LoaiSanPhamDTO> UpdateLoaiSanPham(UpdateLoaiSanPhamRequest request);
        public ResponseData<ActionStatus> RemoveLoaiSanPham(int loaiSanPhamID);
    }
}
