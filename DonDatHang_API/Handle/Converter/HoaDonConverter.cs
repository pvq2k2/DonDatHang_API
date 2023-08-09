using DonDatHang_API.Entities;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.HoaDonRequest;

namespace DonDatHang_API.Handle.Converter
{
    public class HoaDonConverter
    {
        public HoaDonDTO EntityHoaDonToDTO(HoaDon hoaDon)
        {
            return new HoaDonDTO
            {
                TenHoaDon = hoaDon.TenHoaDon,
                MaGiaoDich = hoaDon.MaGiaoDich,
                ThoiGianTao = hoaDon.ThoiGianTao,
                ThoiGianCapNhat = hoaDon.ThoiGianCapNhat,
                GhiChu = hoaDon.GhiChu,
                TongTien = hoaDon.TongTien,
                ListChiTietHoaDon = hoaDon.ListChiTietHoaDon,
            };
        }

        public HoaDon CreateHoaDon(CreateHoaDonRequest request)
        {
            return new HoaDon
            {
                KhachHangID = request.KhachHangID,
                TenHoaDon = request.TenHoaDon,
                MaGiaoDich = request.MaGiaoDich,
                ThoiGianTao = request.ThoiGianTao,
                ThoiGianCapNhat = request.ThoiGianCapNhat,
                GhiChu = request.GhiChu,
                ListChiTietHoaDon = request.ListChiTietHoaDon,
            };
        }

        public HoaDon UpdateHoaDon(HoaDon hoaDon, UpdateHoaDonRequest request)
        {
            hoaDon.TenHoaDon = request.TenHoaDon;
            hoaDon.MaGiaoDich = request.MaGiaoDich;
            hoaDon.ThoiGianCapNhat = request.ThoiGianCapNhat;
            hoaDon.GhiChu = request.GhiChu;

            return hoaDon;
        }
    }
}
