using AutoMapper;
using DonDatHang_API.Entities;
using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.HoaDonRequest;
using DonDatHang_API.Handle.Response;
using DonDatHang_API.Service.Interface;

namespace DonDatHang_API.Service.Implement
{
    public class HoaDonService : BaseService, IHoaDonService
    {
        private string GetMaGiaoDich()
        {
            var maGiaoDich = DateTime.Now.ToString("YYYYMMDD") + "_";
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
        public ResponseData<HoaDonDTO> CreateHoaDon(CreateHoaDonRequest request)
        {
            var response = new ResponseData<HoaDonDTO>();
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (!dbContext.KhachHang.Any(khachHang => khachHang.ID == request.KhachHangID))
                {
                    response.Status = ActionStatus.NotFound;
                    response.Message = $"Khách hàng có ID '{request.KhachHangID}' không tồn tại !";
                    return response;
                }
                HoaDon hoaDon = hoaDonConverter.CreateHoaDon(request);
                hoaDon.ThoiGianTao = DateTime.Now;
                hoaDon.MaGiaoDich = GetMaGiaoDich();
                hoaDon.ListChiTietHoaDon = null;
                dbContext.HoaDon.Add(hoaDon);
                dbContext.SaveChanges();
                var lsCTHoaDon = new List<ChiTietHoaDon>();
                foreach (var chiTietHoaDon in request.ListChiTietHoaDon)
                {
                    if (dbContext.SanPham.Any(sanPham => sanPham.ID == chiTietHoaDon.SanPhamID))
                    {
                        chiTietHoaDon.HoaDonID = hoaDon.ID;
                        var sanPham = dbContext.SanPham.FirstOrDefault(sanPham => sanPham.ID == chiTietHoaDon.SanPhamID);
                        chiTietHoaDon.ThanhTien = chiTietHoaDon.SoLuong * sanPham.GiaThanh;
                        lsCTHoaDon.Add(chiTietHoaDon);
                    }
                    else
                    {
                        if (lsCTHoaDon.Count > 0)
                        {
                            dbContext.ChiTietHoaDon.AddRange(lsCTHoaDon);
                            dbContext.SaveChanges();
                            hoaDon.TongTien = lsCTHoaDon.Sum(x => x.ThanhTien);
                            dbContext.SaveChanges();
                            trans.Commit();
                        } else
                        {
                            hoaDon.TongTien = 0;
                            dbContext.SaveChanges();
                            trans.Commit();
                        }
                        response.Status = ActionStatus.NotFound;
                        response.Message = $"Sản phẩm có ID '{chiTietHoaDon.SanPhamID}' không tồn tại !";
                        return response;
                    }
                }
                dbContext.ChiTietHoaDon.AddRange(lsCTHoaDon);
                dbContext.SaveChanges();
                hoaDon.TongTien = lsCTHoaDon.Sum(x => x.ThanhTien);
                dbContext.SaveChanges();
                trans.Commit();

                response.Status = ActionStatus.Success;
                response.Message = "Thêm hóa đơn thành công !";
                response.Data = hoaDonConverter.EntityHoaDonToDTO(hoaDon);
                return response;
            }
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
            if (lsCTHDHienTai != null && lsCTHDHienTai.Count() > 0)
            {
                hoaDon.TongTien = lsCTHDHienTai.Sum(x => x.ThanhTien);
                hoaDon.ThoiGianCapNhat = DateTime.Now;
                hoaDon = hoaDonConverter.UpdateHoaDon(hoaDon, request);
                dbContext.HoaDon.Update(hoaDon);
                dbContext.SaveChanges();
                response.Status = ActionStatus.Success;
                response.Message = "Cập nhật hóa đơn thành công !";
                response.Data = hoaDonConverter.EntityHoaDonToDTO(hoaDon);
                return response;
            }
            else
            {
                hoaDon.TongTien = 0;
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
}
