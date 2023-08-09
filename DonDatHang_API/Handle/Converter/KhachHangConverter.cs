using DonDatHang_API.Entities;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.KhachHangRequest;

namespace DonDatHang_API.Handle.Converter
{
    public class KhachHangConverter
    {
        public KhachHangDTO EntityKhachHangDTO(KhachHang khachHang)
        {
            return new KhachHangDTO
            {
                HoTen = khachHang.HoTen,
                NgaySinh = khachHang.NgaySinh,
                SDT = khachHang.SDT,
            };
        }

        public List<KhachHangDTO> ListEntityKhachHangDTO(List<KhachHang> listKhachHang)
        {
            var listKhachHangDTO = new List<KhachHangDTO>();
            foreach (var khachHang in listKhachHang)
            {
                listKhachHangDTO.Add(EntityKhachHangDTO(khachHang));
            }

            return listKhachHangDTO;
        }

        public KhachHang CreateKhachHang(CreateKhachHangRequest request)
        {
            return new KhachHang
            {
                HoTen = request.HoTen,
                NgaySinh = request.NgaySinh,
                SDT = request.SDT,
            };
        }

        public KhachHang UpdateKhachHang(KhachHang khachHang, UpdateKhachHangRequest request)
        {
            khachHang.HoTen = request.HoTen;
            khachHang.NgaySinh = request.NgaySinh;
            khachHang.SDT = request.SDT;

            return khachHang;
        }
    }
}
