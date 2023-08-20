using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.HoaDonRequest;
using DonDatHang_API.Handle.Response;
using DonDatHang_API.Helper;

namespace DonDatHang_API.Service.Interface
{
    public interface IHoaDonService
    {
        public PageResult<HoaDonDTO> GetAllHoaDon(Pagination pagination);
        public PageResult<HoaDonDTO> GetHoaDonByKeyword(string keyWord, Pagination pagination);
        public PageResult<HoaDonDTO> GetHoaDonByYearAndMonth(int year, int month, Pagination pagination);
        public PageResult<HoaDonDTO> GetHoaDonByTimePeriod(DateTime dateFrom, DateTime dateTo, Pagination pagination);
        public PageResult<HoaDonDTO> GetHoaDonByPriceRange(int priceFrom, int priceTo, Pagination pagination);
        public ResponseData<HoaDonDTO> GetHoaDonByID(int hoaDonID);
        public ResponseData<HoaDonDTO> CreateHoaDon(CreateHoaDonRequest request);
        public ResponseData<HoaDonDTO> UpadateHoaDon(UpdateHoaDonRequest request);
        public ResponseData<ActionStatus> RemoveHoaDon(int hoaDonID);
    }
}
