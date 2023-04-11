using FastFood_Web.Domain.Entities;
using FastFood_Web.Service.Dtos.CategoryEmpolyeeDto;
using FastFood_Web.Service.Services.Common.PaginationService;

namespace FastFood_Web.Service.Interfaces
{
    public interface ICategoryEmpolyeeService
    {
        public Task<PageList<CategoryEmpolyee>> GetAllAsync(PaginationParams @params);
        public Task<bool> CreateAsync(CreateCategoryEmpolyeeDto categoryEmpolyee);
        public Task<bool> UpdateAsync(long id, CreateCategoryEmpolyeeDto categoryEmpolyee);
        public Task<bool> DeleteAsync(long id);

    }
}
