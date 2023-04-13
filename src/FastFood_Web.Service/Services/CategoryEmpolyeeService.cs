using AutoMapper;
using FastFood_Web.DataAccess.Interfaces.Common;
using FastFood_Web.Domain.Entities;
using FastFood_Web.Service.Dtos.CategoryEmpolyeeDto;
using FastFood_Web.Service.Interfaces;
using FastFood_Web.Service.Services.Common.PaginationService;

namespace FastFood_Web.Service.Services
{
    public class CategoryEmpolyeeService : ICategoryEmpolyeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper; 

        public CategoryEmpolyeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            //this._mapper = mapper;
        }

        public async Task<bool> CreateAsync(CreateCategoryEmpolyeeDto empolyeeDto)
        {
            _unitOfWork.CategoryEmpolyees.Add(empolyeeDto);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _unitOfWork.CategoryEmpolyees.Delete(id);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<PageList<CategoryEmpolyee>> GetAllAsync(PaginationParams @params)
        {
            var query = from categoryEmpolyee in _unitOfWork.CategoryEmpolyees.GetAll().OrderBy(x => x.Id)
                        select categoryEmpolyee;

            return await PageList<CategoryEmpolyee>.ToPageListAsync(query, @params);
        }

        public async Task<bool> UpdateAsync(long id, CreateCategoryEmpolyeeDto categoryEmpolyee)
        {
            _unitOfWork.CategoryEmpolyees.Update(id, categoryEmpolyee);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }
    }
}

