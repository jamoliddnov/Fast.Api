namespace FastFood_Web.Service.Services.Common.PaginationService
{
    public class PaginationMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public PaginationMetaData(int currentPage, int pageSize, int totalItems)
        {
            CurrentPage = currentPage;
            TotalPage = (int)(double)((totalItems + pageSize - 1) / pageSize);
            HasNext = TotalPage > currentPage;
            HasPrevious = currentPage > 1;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
    }
}
