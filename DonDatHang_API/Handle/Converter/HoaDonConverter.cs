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
            };
        }

        public List<HoaDonDTO> ListEntityHoaDonToDTO(List<HoaDon> listHoaDon)
        {
            var listHoaDonDTO = new List<HoaDonDTO>();
            foreach (var hoaDon in listHoaDon)
            {
                listHoaDonDTO.Add(EntityHoaDonToDTO(hoaDon));
            }
            
            return listHoaDonDTO;
        }

        public HoaDon CreateHoaDon(CreateHoaDonRequest request)
        {
            return new HoaDon
            {
                KhachHangID = request.KhachHangID,
                TenHoaDon = request.TenHoaDon,
                GhiChu = request.GhiChu,
            };
        }

        public HoaDon UpdateHoaDon(HoaDon hoaDon, UpdateHoaDonRequest request)
        {
            hoaDon.TenHoaDon = request.TenHoaDon;
            hoaDon.GhiChu = request.GhiChu;

            return hoaDon;
        }
    }
}
