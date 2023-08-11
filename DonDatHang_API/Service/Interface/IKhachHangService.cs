using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.KhachHangRequest;
using DonDatHang_API.Handle.Response;

namespace DonDatHang_API.Service.Interface
{
    public interface IKhachHangService
    {
        public ResponseData<KhachHangDTO> GetAllKhachHang();
        public ResponseData<KhachHangDTO> GetKhachHangByID(int khachHangID);
        public ResponseData<KhachHangDTO> CreateKhachHang(CreateKhachHangRequest request);
        public ResponseData<KhachHangDTO> UpdateKhachHang(UpdateKhachHangRequest request);
        public ResponseData<ActionStatus> RemoveKhachHang(int khachHangID);
    }
}
