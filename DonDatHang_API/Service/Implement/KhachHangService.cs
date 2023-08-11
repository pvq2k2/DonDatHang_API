using DonDatHang_API.Entities;
using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.KhachHangRequest;
using DonDatHang_API.Handle.Response;
using DonDatHang_API.Service.Interface;

namespace DonDatHang_API.Service.Implement
{
    public class KhachHangService : BaseService, IKhachHangService
    {
        public ResponseData<KhachHangDTO> CreateKhachHang(CreateKhachHangRequest request)
        {
            var response = new ResponseData<KhachHangDTO>();
            KhachHang khachHang = khachHangConverter.CreateKhachHang(request);
            dbContext.KhachHang.Add(khachHang);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Thêm khách hàng thành công !";
            response.Data = khachHangConverter.EntityKhachHangDTO(khachHang);
            return response;
        }

        public ResponseData<KhachHangDTO> GetAllKhachHang()
        {
            var response = new ResponseData<KhachHangDTO>();
            var listKhachHang = dbContext.KhachHang.ToList();

            if (listKhachHang.Count == 0)
            {
                response.Status = ActionStatus.Success;
                response.Message = "Danh sách trống !";
                return response;
            }
            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.DataList = khachHangConverter.ListEntityKhachHangDTO(listKhachHang);
            return response;
        }

        public ResponseData<KhachHangDTO> GetKhachHangByID(int khachHangID)
        {
            var response = new ResponseData<KhachHangDTO>();
            var khachHang = dbContext.KhachHang.FirstOrDefault(x => x.ID == khachHangID);
            if (khachHang == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Khách hàng có ID '' không tồn tại !";
                return response;
            }

            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.Data = khachHangConverter.EntityKhachHangDTO(khachHang);
            return response;
        }

        public ResponseData<ActionStatus> RemoveKhachHang(int khachHangID)
        {
            var response = new ResponseData<ActionStatus>();
            var khachHang = dbContext.KhachHang.FirstOrDefault(x => x.ID == khachHangID);
            if (khachHang == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Khách hàng có ID '{khachHangID}' không tồn tại !";
                return response;
            }
            dbContext.KhachHang.Remove(khachHang);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Xóa khách hàng thành công !";
            return response;
        }

        public ResponseData<KhachHangDTO> UpdateKhachHang(UpdateKhachHangRequest request)
        {
            var response = new ResponseData<KhachHangDTO>();
            var FindKhachHang = dbContext.KhachHang.FirstOrDefault(x => x.ID == request.ID);
            if (FindKhachHang == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Khách hàng có ID '{request.ID}' không tồn tại !";
                return response;
            }
            KhachHang khachHang = khachHangConverter.UpdateKhachHang(FindKhachHang, request);
            dbContext.KhachHang.Update(khachHang);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Cập nhật khách hàng thành công !";
            response.Data = khachHangConverter.EntityKhachHangDTO(khachHang);
            return response;
        }
    }
}
