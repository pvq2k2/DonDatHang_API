using DonDatHang_API.Handle.Request.ChiTietHoaDonRequest;
using DonDatHang_API.Service.Implement;
using DonDatHang_API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DonDatHang_API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonController : ControllerBase
    {
        private readonly IChiTietHoaDonService iChiTietHoaDonService;

        public ChiTietHoaDonController()
        {
            iChiTietHoaDonService = new ChiTietHoaDonService();
        }

        [HttpGet("GetAllChiTietHoaDon")]
        public IActionResult GetAllChiTietHoaDon()
        {
            return Ok(iChiTietHoaDonService.GetAllChiTietHoaDon());
        }

        [HttpGet("GetChiTietHoaDonByID")]
        public IActionResult GetChiTietHoaDonByID(int chiTietHoaDonID)
        {
            return Ok(iChiTietHoaDonService.GetChiTietHoaDonByID(chiTietHoaDonID));
        }

        [HttpPost("CreateChiTietHoaDon")]
        public IActionResult CreateChiTietHoaDon(CreateChiTietHoaDonRequest request)
        {
            return Ok(iChiTietHoaDonService.CreateChiTietHoaDon(request));
        }

        [HttpPut("UpdateChiTietHoaDon")]
        public IActionResult UpdateChiTietHoaDon(UpdateChiTietHoaDonRequest request)
        {
            return Ok(iChiTietHoaDonService.UpdateChiTietHoaDon(request));
        }

        [HttpDelete("RemoveChiTietHoaDon")]
        public IActionResult RemoveChiTietHoaDon(int chiTietHoaDonID)
        {
            return Ok(iChiTietHoaDonService.RemoveChiTietHoaDon(chiTietHoaDonID));
        }
    }
}
