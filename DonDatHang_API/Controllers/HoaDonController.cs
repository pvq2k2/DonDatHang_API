using DonDatHang_API.Handle.Request.HoaDonRequest;
using DonDatHang_API.Helper;
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
        public IActionResult GetAllHoaDon([FromQuery] Pagination pagination) {
            return Ok(iHoaDonService.GetAllHoaDon(pagination));
        }

        [HttpGet("GetHoaDonByKeyword")]
        public IActionResult GetHoaDonByKeyword([FromQuery] string keyWord, [FromQuery] Pagination pagination)
        {
            return Ok(iHoaDonService.GetHoaDonByKeyword(keyWord, pagination));
        }

        [HttpGet("GetHoaDonByYearAndMonth")]
        public IActionResult GetHoaDonByYearAndMonth([FromQuery] int year, [FromQuery] int month, [FromQuery] Pagination pagination)
        {
            return Ok(iHoaDonService.GetHoaDonByYearAndMonth(year, month, pagination));
        }

        [HttpGet("GetHoaDonByTimePeriod")]
        public IActionResult GetHoaDonByTimePeriod([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo, [FromQuery] Pagination pagination)
        {
            return Ok(iHoaDonService.GetHoaDonByTimePeriod(dateFrom, dateTo, pagination));
        }

        [HttpGet("GetHoaDonByPriceRange")]
        public IActionResult GetHoaDonByPriceRange([FromQuery] int priceFrom, [FromQuery] int priceTo, [FromQuery] Pagination pagination)
        {
            return Ok(iHoaDonService.GetHoaDonByPriceRange(priceFrom, priceTo, pagination));
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
