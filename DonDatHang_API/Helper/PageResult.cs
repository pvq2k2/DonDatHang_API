namespace DonDatHang_API.Helper
{
    public class PageResult<T>
    {
        public Pagination Pagination { get; set; }
        public IEnumerable<T> Data { get; set; }

        public PageResult(Pagination pagination, IEnumerable<T> data)
        {
            Pagination = pagination;
            Data = data;
        }

        public static IEnumerable<T> ToPageResult(Pagination pagination, IEnumerable<T> data)
        {
            pagination.pageNumber = pagination.pageNumber < 1 ? 1 : pagination.pageNumber;
            data = data.Skip(pagination.pageSize * (pagination.pageNumber -1)).Take(pagination.pageSize).AsQueryable();
            return data;
        }
    }
}
