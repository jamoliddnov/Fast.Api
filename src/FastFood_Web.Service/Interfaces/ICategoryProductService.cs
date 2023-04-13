using FastFood_Web.Domain.Entities;
using FastFood_Web.Service.Dtos.CategoryProductDto;
using FastFood_Web.Service.Services.Common.PaginationService;

namespace FastFood_Web.Service.Interfaces
{
    public interface ICategoryProductService
    {
        public Task<PageList<CategoryProduct>> GetAllAsyn(PaginationParams @params);
        public Task<bool> CreateAsync(CreateCategoryProductDto dto);
        public Task<bool> UpdateAsync(long id, CreateCategoryProductDto dto);
        public Task<bool> DeleteAsync(long id);

    }
}
