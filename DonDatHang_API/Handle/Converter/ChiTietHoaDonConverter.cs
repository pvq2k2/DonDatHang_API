using DonDatHang_API.Entities;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.ChiTietHoaDonRequest;

namespace DonDatHang_API.Handle.Converter
{
    public class ChiTietHoaDonConverter
    {
        public ChiTietHoaDonDTO EntityChiTietHoaDonToDTO(ChiTietHoaDon chiTietHoaDon)
        {
            return new ChiTietHoaDonDTO
            {
                SanPhamID = chiTietHoaDon.SanPhamID,
                DVT = chiTietHoaDon.DVT,
                SoLuong = chiTietHoaDon.SoLuong,
                ThanhTien = chiTietHoaDon.ThanhTien
            };
        }

        public List<ChiTietHoaDonDTO> ListEntityChiTietHoaDonToDTO(List<ChiTietHoaDon> listChiTietHoaDon)
        {
            var listChiTietHoaDonDTO = new List<ChiTietHoaDonDTO>();
            foreach (var chiTietHoaDon in listChiTietHoaDon)
            {
                listChiTietHoaDonDTO.Add(EntityChiTietHoaDonToDTO(chiTietHoaDon));
            }

            return listChiTietHoaDonDTO;
        }

        public ChiTietHoaDon CreateChiTietHoaDon(CreateChiTietHoaDonRequest request)
        {
            return new ChiTietHoaDon
            {
                HoaDonID = request.HoaDonID,
                SanPhamID = request.SanPhamID,
                SoLuong = request.SoLuong,
                DVT = request.DVT,
            };
        }

        public ChiTietHoaDon UpdateChiTietHoaDon(ChiTietHoaDon chiTietHoaDon, UpdateChiTietHoaDonRequest request)
        {
            chiTietHoaDon.SanPhamID = request.SanPhamID;
            chiTietHoaDon.SoLuong = request.SoLuong;
            chiTietHoaDon.DVT = request.DVT;

            return chiTietHoaDon;
        }
    }
}
