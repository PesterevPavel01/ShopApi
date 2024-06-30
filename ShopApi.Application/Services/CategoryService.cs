using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Entity;
using ShopApi.Domain.Interfaces.Interactors;
using ShopApi.Domain.Interfaces.Services;

namespace ShopApi.Application.Services
{
    public class CategoryService : ICommonService<CategoryDto, int>
    {
        private readonly ICommonInteractor<Category> _categoryinteractor;

        public CategoryService(ICommonInteractor<Category> categoryinteractor)
        {
            _categoryinteractor = categoryinteractor;
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto model)
        {
            if (model == null) return new CategoryDto();

            try
            {
                var category = await _categoryinteractor.GetAll().FirstOrDefaultAsync(x => x.NameCategory== model.NameCategory);

                if (category  != null)
                    return null;

                category = new Category()
                {
                    NameCategory = model.NameCategory,
                    ExtraCharge = model.ExtraCharge,
                    Description = model.Description,
                };

                var result = await _categoryinteractor.CreateAsync(category);

                return new()
                {
                    NameCategory = result.NameCategory,
                    ExtraCharge = result.ExtraCharge,
                    Description = result.Description,
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task <bool> CreateMultiple(List<CategoryDto> categoryDtos)
        {
            if (categoryDtos == null)  return false;

            List<Category> newCategory = new List<Category>();
            try
            {
                foreach( var currentCategori in categoryDtos)
                {
                    var category = await _categoryinteractor.GetAll()
                        .FirstOrDefaultAsync(x => x.NameCategory == currentCategori.NameCategory);

                    if (category == null) continue;

                    newCategory.Add(new Category()
                    {
                        NameCategory = currentCategori.NameCategory,
                        ExtraCharge = currentCategori.ExtraCharge,
                        Description = currentCategori.Description,
                    });
                }
                return await _categoryinteractor.CreateMultipleAsync(newCategory);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<CategoryDto> DeleteAsync(int id)
        {

            try
            {
                var category = await _categoryinteractor.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return null;

                var result = await _categoryinteractor.RemoveAsync(category);

                return new()
                {
                    NameCategory = result.NameCategory,
                    ExtraCharge = result.ExtraCharge,
                    Description = result.Description,
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            CategoryDto[] category;
            try
            {
                category = await _categoryinteractor.GetAll()
                    .Select(x => new CategoryDto(x.Id, x.Description,x.NameCategory, x.ExtraCharge)).ToArrayAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return category.ToList();
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            Category category;
            try
            {
                category = await _categoryinteractor.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return null;
            }
            catch (Exception ex)
            {
                category = null;
            }

            return new()
            {
                NameCategory = category.NameCategory,
                ExtraCharge = category.ExtraCharge,
                Description = category.Description,
            };
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto model)
        {
            if (model == null) return null;
            try
            {
                var category = await _categoryinteractor.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (category == null)
                    return null;

                category.NameCategory = model.NameCategory;
                category.ExtraCharge = model.ExtraCharge;
                category.Description = model.Description;


                await _categoryinteractor.UpdateAsync(category);

                return new()
                {
                    NameCategory = category.NameCategory,
                    ExtraCharge = category.ExtraCharge,
                    Description = category.Description,
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
