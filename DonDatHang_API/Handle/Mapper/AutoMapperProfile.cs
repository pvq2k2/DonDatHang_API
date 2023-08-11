using AutoMapper;
using DonDatHang_API.Entities;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.ChiTietHoaDonRequest;
using DonDatHang_API.Handle.Request.HoaDonRequest;

namespace DonDatHang_API.Handle.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HoaDon, HoaDonDTO>();
            CreateMap<List<HoaDon>, List<HoaDonDTO>>();
            CreateMap<CreateHoaDonRequest, HoaDon>();
            CreateMap<UpdateHoaDonRequest, HoaDon>();

            CreateMap<ChiTietHoaDon, ChiTietHoaDonDTO>();
            CreateMap<List<ChiTietHoaDon>, List<ChiTietHoaDonDTO>>();
            CreateMap<CreateChiTietHoaDonRequest, ChiTietHoaDon>();
            CreateMap<UpdateChiTietHoaDonRequest, ChiTietHoaDon>();
        }
    }
}
