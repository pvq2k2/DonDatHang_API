using DonDatHang_API.Entities;
using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.ChiTietHoaDonRequest;
using DonDatHang_API.Handle.Response;
using DonDatHang_API.Service.Interface;

namespace DonDatHang_API.Service.Implement
{
    public class ChiTietHoaDonService : BaseService, IChiTietHoaDonService
    {
        public ResponseData<ChiTietHoaDonDTO> CreateChiTietHoaDon(CreateChiTietHoaDonRequest request)
        {
            var response = new ResponseData<ChiTietHoaDonDTO>();
            if (!dbContext.HoaDon.Any(hoaDon => hoaDon.ID == request.HoaDonID))
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Hóa đơn có ID '{request.HoaDonID}' không tồn tại !";
                return response;
            }
            var sanPham = dbContext.SanPham.FirstOrDefault(sanPham => sanPham.ID == request.SanPhamID);
            if (sanPham == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Sản phẩm có ID '{request.SanPhamID}' không tồn tại !";
                return response;
            }

            ChiTietHoaDon chiTietHoaDon = chiTietHoaDonConverter.CreateChiTietHoaDon(request);
            chiTietHoaDon.ThanhTien = sanPham.GiaThanh * request.SoLuong;
            dbContext.ChiTietHoaDon.Add(chiTietHoaDon);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Thêm chi tiết hóa đơn thành công !";
            response.Data = chiTietHoaDonConverter.EntityChiTietHoaDonToDTO(chiTietHoaDon);
            return response;
        }

        public ResponseData<ChiTietHoaDonDTO> GetAllChiTietHoaDon()
        {
            var response = new ResponseData<ChiTietHoaDonDTO>();
            var listChiTietHoaDon = dbContext.ChiTietHoaDon.ToList();
            if (listChiTietHoaDon.Count == 0)
            {
                response.Status = ActionStatus.Success;
                response.Message = "Danh sách trống !";
                return response;
            }
            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.DataList = chiTietHoaDonConverter.ListEntityChiTietHoaDonToDTO(listChiTietHoaDon);
            return response;
        }

        public ResponseData<ChiTietHoaDonDTO> GetChiTietHoaDonByID(int chiTietHoaDonID)
        {
            var response = new ResponseData<ChiTietHoaDonDTO>();
            var findChiTietHoaDon = dbContext.ChiTietHoaDon.FirstOrDefault(chiTietHoaDon => chiTietHoaDon.ID == chiTietHoaDonID);
            if (findChiTietHoaDon == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Chi tiết hóa đơn có ID '{chiTietHoaDonID}' không tồn tại !";
                return response;
            }

            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.Data = chiTietHoaDonConverter.EntityChiTietHoaDonToDTO(findChiTietHoaDon);
            return response;
        }

        public ResponseData<ActionStatus> RemoveChiTietHoaDon(int chiTietHoaDonID)
        {
            var response = new ResponseData<ActionStatus>();
            var findChiTietHoaDon = dbContext.ChiTietHoaDon.FirstOrDefault(chiTietHoaDon => chiTietHoaDon.ID == chiTietHoaDonID);
            if (findChiTietHoaDon == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Chi tiết hóa đơn có ID '{chiTietHoaDonID}' không tồn tại !";
                return response;
            }
            dbContext.ChiTietHoaDon.Remove(findChiTietHoaDon);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Xóa chi tiết hóa đơn thành công !";
            return response;
        }

        public ResponseData<ChiTietHoaDonDTO> UpdateChiTietHoaDon(UpdateChiTietHoaDonRequest request)
        {
            var response = new ResponseData<ChiTietHoaDonDTO>();
            var findChiTietHoaDon = dbContext.ChiTietHoaDon.FirstOrDefault(chiTietHoaDon => chiTietHoaDon.ID == request.ID);

            if (findChiTietHoaDon == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Chi tiết hóa đơn có ID '{request.ID}' không tồn tại !";
                return response;
            }
            var sanPham = dbContext.SanPham.FirstOrDefault(sanPham => sanPham.ID == request.SanPhamID);
            if (sanPham == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Sản phẩm có ID '{request.SanPhamID}' không tồn tại !";
                return response;
            }
            ChiTietHoaDon chiTietHoaDon = chiTietHoaDonConverter.UpdateChiTietHoaDon(findChiTietHoaDon, request);
            chiTietHoaDon.ThanhTien = sanPham.GiaThanh * request.SoLuong;
            dbContext.ChiTietHoaDon.Update(chiTietHoaDon);
            dbContext.SaveChanges();

            response.Status = ActionStatus.Success;
            response.Message = "Cập nhật chi tiết hóa đơn thành công !";
            response.Data = chiTietHoaDonConverter.EntityChiTietHoaDonToDTO(chiTietHoaDon);
            return response;
        }
    }
}
