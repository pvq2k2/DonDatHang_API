using DonDatHang_API.Handle.Request.HoaDonRequest;
using DonDatHang_API.Service.Implement;
using DonDatHang_API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DonDatHang_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonService iHoaDonService;

        public HoaDonController()
        {
            iHoaDonService = new HoaDonService();
        }

        [HttpGet("GetAllHoaDon")]
        public IActionResult GetAllHoaDon(string? keyWord = "",
            int? year = null,
            int? month = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            int? priceFrom = null,
            int? priceTo = null) {
            return Ok(iHoaDonService.GetAllHoaDon(keyWord, year, month, dateFrom, dateTo, priceFrom, priceTo));
        }

        [HttpGet("GetHoaDonByID")]
        public IActionResult GetHoaDonByID(int hoaDonID)
        {
            return Ok(iHoaDonService.GetHoaDonByID(hoaDonID));
        }

        [HttpPost("CreateHoaDon")]
        public IActionResult CreateHoaDon(CreateHoaDonRequest request)
        {
            return Ok(iHoaDonService.CreateHoaDon(request));
        }

        [HttpPut("UpdateHoaDon")]
        public IActionResult UpdateHoaDon(UpdateHoaDonRequest request)
        {
            return Ok(iHoaDonService.UpadateHoaDon(request));
        }

        [HttpDelete("RemoveHoaDon")]
        public IActionResult RemoveHoaDon(int hoaDonID) {
            return Ok(iHoaDonService.RemoveHoaDon(hoaDonID));
        }
    }
}
