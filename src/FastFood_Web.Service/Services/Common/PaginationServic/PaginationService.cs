using FastFood_Web.Service.Interfaces.Common;
using FastFood_Web.Service.Services.Common.PaginationService;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FastFood_Web.Service.Services.Common.PaginationServic
{
    public class PaginationService : IPaginationService
    {
        private readonly IHttpContextAccessor _accessor;

        public int Page { get; }
        public int PageSize { get; }

        public PaginationService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public PaginationService(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public async Task<IList<T>> ToPagedAsync<T>(IList<T> items, int pageNumber, int pageSize)
        {
            int totalItems = items.Count();

            PaginationMetaData paginationMetaData = new PaginationMetaData(pageNumber, pageSize, totalItems)
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPage = (int)Math.Ceiling(totalItems / (double)pageSize),
                HasPrevious = pageNumber > 1
            };

            paginationMetaData.HasNext = paginationMetaData.CurrentPage < paginationMetaData.TotalPage;

            string json = JsonConvert.SerializeObject(paginationMetaData);
            _accessor.HttpContext!.Response.Headers.Add("X-Pagination", json);

            return items.Skip(pageNumber * pageSize - pageSize).Take(pageSize).ToList();
        }
    }
}