using AutoMapper;
using Azure.Core;
using Azure;
using DonDatHang_API.Entities;
using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.HoaDonRequest;
using DonDatHang_API.Handle.Response;
using DonDatHang_API.Service.Interface;
using System.Diagnostics;
using DonDatHang_API.Handle.Request.ChiTietHoaDonRequest;

namespace DonDatHang_API.Service.Implement
{
    public class HoaDonService : BaseService, IHoaDonService
    {
        private string GetMaGiaoDich()
        {
            var maGiaoDich = DateTime.Now.ToString("yyyMMdd") + "_";
            int countSoGiaoDichHomNay = dbContext.HoaDon.Count(hoaDon => hoaDon.ThoiGianTao.Date == DateTime.Now.Date);
            if (countSoGiaoDichHomNay > 0)
            {
                int temp = countSoGiaoDichHomNay + 1;
                if (temp < 10) return maGiaoDich + "00" + temp.ToString();
                else if (temp < 100) return maGiaoDich + "0" + temp.ToString();
                else return maGiaoDich + temp.ToString();
            }
            else return maGiaoDich + "001";
        }

        private List<ChiTietHoaDon> CreateListChiTietHoaDon(int hoaDonID, List<ChiTietHoaDon> listCT)
        {
            var checkHoaDon = dbContext.HoaDon.FirstOrDefault(x => x.ID == hoaDonID);
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            if (checkHoaDon == null)
            {
                return null;
            }
            else
            {

                for (int i = 0; i < listCT.Count(); i++)
                {
                    if (dbContext.SanPham.Any(x => x.ID == listCT[i].SanPhamID))
                    {
                        ChiTietHoaDon chiTiet = new ChiTietHoaDon();
                        chiTiet.HoaDonID = hoaDonID;
                        chiTiet.SanPhamID = listCT[i].SanPhamID;
                        chiTiet.SoLuong = listCT[i].SoLuong;
                        chiTiet.DVT = listCT[i].DVT;

                        var sanPham = dbContext.SanPham.FirstOrDefault(x => x.ID == chiTiet.SanPhamID);
                        chiTiet.ThanhTien = chiTiet.SoLuong * sanPham.GiaThanh;
                        list.Add(chiTiet);
                        dbContext.ChiTietHoaDon.Add(chiTiet);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        return list;
                    }
                }
               
                return list;
            }

        }
        public ResponseData<HoaDonDTO> CreateHoaDon(CreateHoaDonRequest request)
        {
            var response = new ResponseData<HoaDonDTO>();
            if (!dbContext.KhachHang.Any(khachHang => khachHang.ID == request.KhachHangID))
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Khách hàng có ID '{request.KhachHangID}' không tồn tại !";
                return response;
            }
            HoaDon hoaDon = hoaDonConverter.CreateHoaDon(request);
            hoaDon.ThoiGianTao = DateTime.Now;
            hoaDon.MaGiaoDich = GetMaGiaoDich();
            dbContext.HoaDon.Add(hoaDon);
            dbContext.SaveChanges();

            hoaDon.ListChiTietHoaDon = CreateListChiTietHoaDon(hoaDon.ID, request.ListChiTietHoaDon);
            var lsCTHD = dbContext.ChiTietHoaDon.Where(x => x.HoaDonID == hoaDon.ID).ToList();

            if (lsCTHD.Count > 0) hoaDon.TongTien = lsCTHD.Sum(x => x.ThanhTien);
            else hoaDon.TongTien = 0;

            dbContext.HoaDon.Update(hoaDon);
            dbContext.SaveChanges();

            response.Status = ActionStatus.Success;
            response.Message = "Thêm hóa đơn thành công !";
            response.Data = hoaDonConverter.EntityHoaDonToDTO(hoaDon);
            return response;
        }


        public ResponseData<HoaDonDTO> GetAllHoaDon()
        {
            var response = new ResponseData<HoaDonDTO>();
            var listHoaDon = dbContext.HoaDon.ToList();

            if (listHoaDon.Count() == 0)
            {
                response.Status = ActionStatus.Success;
                response.Message = "Danh sách trống !";
                return response;
            }
            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.DataList = hoaDonConverter.ListEntityHoaDonToDTO(listHoaDon);
            return response;
        }

        public ResponseData<HoaDonDTO> GetHoaDonByID(int hoaDonID)
        {
            var response = new ResponseData<HoaDonDTO>();
            var listHoaDon = dbContext.HoaDon.ToList();

            if (listHoaDon.Count == 0)
            {
                response.Status = ActionStatus.Success;
                response.Message = "Danh sách trống !";
                return response;
            }
            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.DataList = hoaDonConverter.ListEntityHoaDonToDTO(listHoaDon);
            return response;
        }

        public ResponseData<ActionStatus> RemoveHoaDon(int hoaDonID)
        {
            var response = new ResponseData<ActionStatus>();
            var hoaDon = dbContext.HoaDon.FirstOrDefault(x => x.ID == hoaDonID);
            if (hoaDon == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Hóa đơn có ID '{hoaDonID}' không tồn tại !";
                return response;
            }
            var lsCTHD = dbContext.ChiTietHoaDon.Where(x => x.HoaDonID == hoaDonID).ToList();
            dbContext.ChiTietHoaDon.RemoveRange(lsCTHD);
            dbContext.SaveChanges();

            dbContext.HoaDon.Remove(hoaDon);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Xóa hóa đơn thành công !";
            return response;
        }

        public ResponseData<HoaDonDTO> UpadateHoaDon(UpdateHoaDonRequest request)
        {
            var response = new ResponseData<HoaDonDTO>();
            var hoaDon = dbContext.HoaDon.FirstOrDefault(hoaDon => hoaDon.ID == request.ID);
            if (hoaDon == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Hóa đơn có ID '{request.ID}' không tồn tại !";
                return response;
            }
            var lsCTHDHienTai = dbContext.ChiTietHoaDon.Where(cthd => cthd.HoaDonID == request.ID).ToList();
            if (lsCTHDHienTai != null && lsCTHDHienTai.Count() > 0) hoaDon.TongTien = lsCTHDHienTai.Sum(x => x.ThanhTien);
            else hoaDon.TongTien = 0;

            hoaDon.ThoiGianCapNhat = DateTime.Now;
            hoaDon = hoaDonConverter.UpdateHoaDon(hoaDon, request);
            dbContext.HoaDon.Update(hoaDon);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Cập nhật hóa đơn thành công !";
            response.Data = hoaDonConverter.EntityHoaDonToDTO(hoaDon);
            return response;
        }
    }
}
