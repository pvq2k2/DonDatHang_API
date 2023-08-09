﻿using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.HoaDonRequest;
using DonDatHang_API.Handle.Response;

namespace DonDatHang_API.Service.Interface
{
    public interface IHoaDon
    {
        public ResponseData<HoaDonDTO> GetAllHoaDon();
        public ResponseData<HoaDonDTO> GetHoaDonByID(int hoaDonID);
        public ResponseData<HoaDonDTO> CreateHoaDon(CreateHoaDonRequest request);
        public ResponseData<HoaDonDTO> UpadateHoaDon(int hoaDonID, UpdateHoaDonRequest request);
        public ResponseData<ActionStatus> RemoveHoaDon(int hoaDonID);
    }
}
