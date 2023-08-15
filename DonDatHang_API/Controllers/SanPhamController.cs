using DonDatHang_API.Handle.Request.SanPhamRequest;
using DonDatHang_API.Service.Implement;
using DonDatHang_API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DonDatHang_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamService iSanPhamService;

        public SanPhamController()
        {
            iSanPhamService = new SanPhamService();
        }

        [HttpGet("GetAllSanPham")]
        public IActionResult GetAllSanPham()
        {
            return Ok(iSanPhamService.GetAllSanPham());
        }

        [HttpGet("GetSanPhamByID")]
        public IActionResult GetSanPhamByID(int loaiSanPhamID)
        {
            return Ok(iSanPhamService.GetSanPhamByID(loaiSanPhamID));
        }

        [HttpPost("CreateSanPham")]
        public IActionResult CreateSanPham(CreateSanPhamRequest request)
        {
            return Ok(iSanPhamService.CreateSanPham(request));
        }

        [HttpPut("UpdateSanPham")]
        public IActionResult UpdateSanPham(UpdateSanPhamRequest request)
        {
            return Ok(iSanPhamService.UpdateSanPham(request));
        }

        [HttpDelete("RemoveSanPham")]
        public IActionResult RemoveSanPham(int loaiSanPhamID)
        {
            return Ok(iSanPhamService.RemoveSanPham(loaiSanPhamID));
        }
    }
}
