using DonDatHang_API.Handle.Request.KhachHangRequest;
using DonDatHang_API.Service.Implement;
using DonDatHang_API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DonDatHang_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService iKhachHangService;

        public KhachHangController()
        {
            iKhachHangService = new KhachHangService();
        }

        [HttpGet("GetAllKhachHang")]
        public IActionResult GetAllKhachHang()
        {
            return Ok(iKhachHangService.GetAllKhachHang());
        }

        [HttpGet("GetKhachHangByID")]
        public IActionResult GetKhachHangByID(int khachHangID) {
            return Ok(iKhachHangService.GetKhachHangByID(khachHangID));
        }

        [HttpPost("CreateKhachHang")]
        public IActionResult CreateKhachHang(CreateKhachHangRequest request)
        {
            return Ok(iKhachHangService.CreateKhachHang(request));
        }

        [HttpPut("UpdateKhachHang")]
        public IActionResult UpdateKhachHang(UpdateKhachHangRequest request)
        {
            return Ok(iKhachHangService.UpdateKhachHang(request));
        }

        [HttpDelete("RemoveKhachHang")]
        public IActionResult RemoveKhachHang(int khachHangID)
        {
            return Ok(iKhachHangService.RemoveKhachHang(khachHangID));
        }
    }
}
