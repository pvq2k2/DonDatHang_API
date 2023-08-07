using DonDatHang_API.Enums;

namespace DonDatHang_API.Handle.Response
{
    public class ResponseData <T>
    {
        public ActionStatus Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<T> DataList { get; set; }
    }
}
