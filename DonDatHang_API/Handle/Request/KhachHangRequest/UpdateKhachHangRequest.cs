﻿namespace DonDatHang_API.Handle.Request.KhachHangRequest
{
    public class UpdateKhachHangRequest
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
    }
}
