using FastFood_Web.Domain.Entities;
using FastFood_Web.Service.Dtos.CategoryProductDto;
using FastFood_Web.Service.Interfaces;
using FastFood_Web.Service.Services.Common.PaginationService;

namespace FastFood_Web.Service.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        public Task<bool> CreateAsync(CreateCategoryProductDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PageList<CategoryProduct>> GetAllAsyn(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long id, CreateCategoryProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
