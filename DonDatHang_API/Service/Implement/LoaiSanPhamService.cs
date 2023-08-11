using DonDatHang_API.Entities;
using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.LoaiSanPhamRequest;
using DonDatHang_API.Handle.Response;
using DonDatHang_API.Service.Interface;

namespace DonDatHang_API.Service.Implement
{
    public class LoaiSanPhamService : BaseService, ILoaiSanPhamService
    {
        public ResponseData<LoaiSanPhamDTO> CreateLoaiSanPham(CreateLoaiSanPhamRequest request)
        {
            var response = new ResponseData<LoaiSanPhamDTO>();
            LoaiSanPham loaiSanPham = loaiSanPhamConverter.CreateLoaiSanPham(request);
            dbContext.LoaiSanPham.Add(loaiSanPham);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Thêm loại sản phẩm thành công !";
            response.Data = loaiSanPhamConverter.EntityLoaiSanPhamToDTO(loaiSanPham);
            return response;
        }

        public ResponseData<LoaiSanPhamDTO> GetAllLoaiSanPham()
        {
            var response = new ResponseData<LoaiSanPhamDTO>();
            var listLoaiSanPham = dbContext.LoaiSanPham.ToList();

            if (listLoaiSanPham.Count == 0)
            {
                response.Status = ActionStatus.Success;
                response.Message = "Danh sách trống !";
                return response;
            }
            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.DataList = loaiSanPhamConverter.ListLoaiSanPhamToDTO(listLoaiSanPham);
            return response;
        }

        public ResponseData<LoaiSanPhamDTO> GetLoaiSanPhamByID(int loaiSanPhamID)
        {
            var response = new ResponseData<LoaiSanPhamDTO>();
            var loaiSanPham = dbContext.LoaiSanPham.FirstOrDefault(x => x.ID == loaiSanPhamID);

            if (loaiSanPham == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Loại sản phẩm có ID '{loaiSanPhamID}' không tồn tại !";
                return response;
            }
            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.Data = loaiSanPhamConverter.EntityLoaiSanPhamToDTO(loaiSanPham);
            return response;
        }

        public ResponseData<ActionStatus> RemoveLoaiSanPham(int loaiSanPhamID)
        {
            var response = new ResponseData<ActionStatus>();
            var loaiSanPham = dbContext.LoaiSanPham.FirstOrDefault(x => x.ID == loaiSanPhamID);

            if (loaiSanPham == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Loại sản phẩm có ID '{loaiSanPhamID}' không tồn tại !";
                return response;
            }
            dbContext.LoaiSanPham.Remove(loaiSanPham);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Xóa loại sản phẩm thành công !";
            return response;
        }

        public ResponseData<LoaiSanPhamDTO> UpdateLoaiSanPham(UpdateLoaiSanPhamRequest request)
        {
            var response = new ResponseData<LoaiSanPhamDTO>();
            var FindLoaiSanPham = dbContext.LoaiSanPham.FirstOrDefault(x => x.ID == request.ID);

            if (FindLoaiSanPham == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Loại sản phẩm có ID '{request.ID}' không tồn tại !";
                return response;
            }
            LoaiSanPham loaiSanPham = loaiSanPhamConverter.UpdateLoaiSanPham(FindLoaiSanPham, request);
            dbContext.LoaiSanPham.Update(loaiSanPham);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Cập nhật loại sản phẩm thành công !";
            response.Data = loaiSanPhamConverter.EntityLoaiSanPhamToDTO(loaiSanPham);
            return response;
        }
    }
}
