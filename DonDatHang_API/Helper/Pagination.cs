namespace DonDatHang_API.Helper
{
    public class Pagination
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public int totalCount { get; set; }
        public int totalPage { 
            get { 
                if (totalCount == 0) return 0;
                var total = pageSize / pageNumber;
                if (pageSize % pageNumber != 0) total++;
                    return total;
            } 
        }

        public Pagination() { 
            pageSize = -1;
            pageNumber = 1;
        }
    }
}
