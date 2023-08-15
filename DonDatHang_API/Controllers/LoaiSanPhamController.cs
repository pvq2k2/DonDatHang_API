using DonDatHang_API.Handle.Request.LoaiSanPhamRequest;
using DonDatHang_API.Service.Implement;
using DonDatHang_API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DonDatHang_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        private readonly ILoaiSanPhamService iLoaiSanPhamService;

        public LoaiSanPhamController()
        {
            iLoaiSanPhamService = new LoaiSanPhamService();
        }

        [HttpGet("GetAllLoaiSanPham")]
        public IActionResult GetAllLoaiSanPham() { 
            return Ok(iLoaiSanPhamService.GetAllLoaiSanPham());
        }

        [HttpGet("GetLoaiSanPhamByID")]
        public IActionResult GetLoaiSanPhamByID(int loaiSanPhamID)
        {
            return Ok(iLoaiSanPhamService.GetLoaiSanPhamByID(loaiSanPhamID));
        }

        [HttpPost("CreateLoaiSanPham")]
        public IActionResult CreateLoaiSanPham(CreateLoaiSanPhamRequest request)
        {
            return Ok(iLoaiSanPhamService.CreateLoaiSanPham(request));
        }

        [HttpPut("UpdateLoaiSanPham")]
        public IActionResult UpdateLoaiSanPham(UpdateLoaiSanPhamRequest request)
        {
            return Ok(iLoaiSanPhamService.UpdateLoaiSanPham(request));
        }

        [HttpDelete("RemoveLoaiSanPham")]
        public IActionResult RemoveLoaiSanPham(int loaiSanPhamID)
        {
            return Ok(iLoaiSanPhamService.RemoveLoaiSanPham(loaiSanPhamID));
        }
    }
}
