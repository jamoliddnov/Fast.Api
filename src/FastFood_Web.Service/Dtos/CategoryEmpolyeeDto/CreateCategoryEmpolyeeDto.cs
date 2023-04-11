using FastFood_Web.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FastFood_Web.Service.Dtos.CategoryEmpolyeeDto
{
    public class CreateCategoryEmpolyeeDto
    {
        [Required]
        public string StatusEmpolyee { get; set; } = String.Empty;

        public static implicit operator CategoryEmpolyee(CreateCategoryEmpolyeeDto createCategory)
        {
            return new CategoryEmpolyee()
            {
                StatusEmpolyee = createCategory.StatusEmpolyee,
            };
        }
    }
}
