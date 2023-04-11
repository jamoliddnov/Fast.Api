namespace FastFood_Web.Service.Services.Common.PaginationService
{
    public class PaginationParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationParams(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
