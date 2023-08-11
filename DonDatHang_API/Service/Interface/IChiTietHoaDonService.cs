using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.ChiTietHoaDonRequest;
using DonDatHang_API.Handle.Response;

namespace DonDatHang_API.Service.Interface
{
    public interface IChiTietHoaDonService
    {
        public ResponseData<ChiTietHoaDonDTO> GetAllChiTietHoaDon();
        public ResponseData<ChiTietHoaDonDTO> GetChiTietHoaDonByID(int chiTietHoaDonID);
        public ResponseData<ChiTietHoaDonDTO> CreateChiTietHoaDon(CreateChiTietHoaDonRequest request);
        public ResponseData<ChiTietHoaDonDTO> UpdateChiTietHoaDon(UpdateChiTietHoaDonRequest request);
        public ResponseData<ActionStatus> RemoveChiTietHoaDon(int chiTietHoaDonID);
    }
}
