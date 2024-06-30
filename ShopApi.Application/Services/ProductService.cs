using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Entity;
using ShopApi.Domain.Interfaces.Interactors;
using ShopApi.Domain.Interfaces.Services;

namespace ShopApi.Application.Services
{
    public class ProductService : ICommonService<ProductDto, int>
    {
        private readonly ICommonInteractor<Product> _productInteractor;

        public ProductService(ICommonInteractor<Product> productInteractor)
        {
            _productInteractor = productInteractor;
        }

        public async Task<ProductDto> CreateAsync(ProductDto model)
        {
            if (model == null) return new ProductDto();

            try
            {
                var result = await _productInteractor.CreateAsync(new(model));

                return new()
                {
                    Name = result.Name,
                    CategoryId = result.CategoryId,
                    Firm = result.Firm,
                    Price = result.Price,
                    Id = result.Id,
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<bool> CreateMultiple(List<ProductDto> listModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> DeleteAsync(int id)
        {
            try
            {
                var product = await _productInteractor.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                    return null;

                var result = await _productInteractor.RemoveAsync(product);

                return new(result)
                {
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            ProductDto[] products;
            try
            {
                products = await _productInteractor.GetAll()
                    .Select(x => new ProductDto(x)).ToArrayAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return products.ToList();
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            Product product;
            try
            {
                product = await _productInteractor.GetAll().FirstOrDefaultAsync(x => x.Id==id);

                if (product == null)
                    return null;
            }
            catch (Exception ex)
            {
                product = null;
            }

            return new(product);
        }

        public async Task<ProductDto> UpdateAsync(ProductDto model)
        {
            if (model == null) return null;
            try
            {
                var product = await _productInteractor.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (product == null)
                    return null;

                product = await _productInteractor.UpdateAsync(new(model));

                return new(product);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
