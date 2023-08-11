using DonDatHang_API.Entities;
using DonDatHang_API.Enums;
using DonDatHang_API.Handle.DTOs;
using DonDatHang_API.Handle.Request.SanPhamRequest;
using DonDatHang_API.Handle.Response;
using DonDatHang_API.Service.Interface;

namespace DonDatHang_API.Service.Implement
{
    public class SanPhamService : BaseService, ISanPhamService
    {
        public ResponseData<SanPhamDTO> CreateSanPham(CreateSanPhamRequest request)
        {
            var response = new ResponseData<SanPhamDTO>();
            if (!dbContext.LoaiSanPham.Any(x => x.ID == request.LoaiSanPhamID))
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Loại sản phẩm có ID '{request.LoaiSanPhamID}' không tồn tại !";
                return response;
            }
            SanPham sanPham = sanPhamConverter.CreateSanPham(request);
            dbContext.SanPham.Add(sanPham);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Thêm sản phẩm thành công !";
            response.Data = sanPhamConverter.EntitySanPhamToDTO(sanPham);
            return response;
        }

        public ResponseData<SanPhamDTO> GetAllSanPham()
        {
            var response = new ResponseData<SanPhamDTO>();
            var listSanPham = dbContext.SanPham.ToList();

            if (listSanPham == null)
            {
                response.Status = ActionStatus.Success;
                response.Message = "Danh sách trống !";
                return response;
            }
            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.DataList = sanPhamConverter.ListEntitySanPhamToDTO(listSanPham);
            return response;
        }

        public ResponseData<SanPhamDTO> GetSanPhamByID(int sanPhamID)
        {
            var response = new ResponseData<SanPhamDTO>();
            var sanPham = dbContext.SanPham.FirstOrDefault(x => x.ID == sanPhamID);

            if (sanPham == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Sản phẩm có ID '' không tồn tại !";
                return response;
            }
            response.Status = ActionStatus.Success;
            response.Message = "Thành công !";
            response.Data = sanPhamConverter.EntitySanPhamToDTO(sanPham);
            return response;
        }

        public ResponseData<ActionStatus> RemoveSanPham(int sanPhamID)
        {
            var response = new ResponseData<ActionStatus>();
            var sanPham = dbContext.SanPham.FirstOrDefault(x => x.ID == sanPhamID);

            if (sanPham == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Sản phẩm có ID '{sanPhamID}' không tồn tại !";
                return response;
            }
            dbContext.SanPham.Remove(sanPham);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Xóa sản phẩm thành công !";
            return response;
        }

        public ResponseData<SanPhamDTO> UpdateSanPham(UpdateSanPhamRequest request)
        {
            var response = new ResponseData<SanPhamDTO>();
            var findSanPham = dbContext.SanPham.FirstOrDefault(x => x.ID == request.ID);

            if (findSanPham == null)
            {
                response.Status = ActionStatus.NotFound;
                response.Message = $"Sản phẩm có ID '{request.ID}' không tồn tại !";
                return response;
            }

            SanPham sanPham = sanPhamConverter.UpdateSanPham(findSanPham, request);
            dbContext.SanPham.Update(sanPham);
            dbContext.SaveChanges();
            response.Status = ActionStatus.Success;
            response.Message = "Cập nhật sản phẩm thành công !";
            response.Data = sanPhamConverter.EntitySanPhamToDTO(sanPham);
            return response;
        }
    }
}
