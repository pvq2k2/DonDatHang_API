using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.HoaDonRequest;
using DonDatHang_API.Handle.Response;

namespace DonDatHang_API.Service.Interface
{
    public interface IHoaDonService
    {
        public ResponseData<HoaDonDTO> GetAllHoaDon(string? keyWord = "",
            int? year = null,
            int? month = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            int? priceFrom = null,
            int? priceTo = null);
        public ResponseData<HoaDonDTO> GetHoaDonByID(int hoaDonID);
        public ResponseData<HoaDonDTO> CreateHoaDon(CreateHoaDonRequest request);
        public ResponseData<HoaDonDTO> UpadateHoaDon(UpdateHoaDonRequest request);
        public ResponseData<ActionStatus> RemoveHoaDon(int hoaDonID);
    }
}
