using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Entity;
using ShopApi.Domain.Interfaces.Interactors;
using ShopApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Services
{
    public class PurchaseService : ICommonService<PurchaseDto, int>
    {
        private readonly ICommonInteractor<Purchase> _purchaseInteractor;

        public PurchaseService(ICommonInteractor<Purchase> purchaseInteractor)
        {
            _purchaseInteractor = purchaseInteractor;
        }

        public async Task<PurchaseDto> CreateAsync(PurchaseDto model)
        {
            if (model == null) return new PurchaseDto();

            try
            {
                var result = await _purchaseInteractor.CreateAsync(new(model));

                return new(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<bool> CreateMultiple(List<PurchaseDto> listModel)
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseDto> DeleteAsync(int id)
        {
            try
            {
                var purchase = await _purchaseInteractor.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (purchase == null)
                    return null;

                var result = await _purchaseInteractor.RemoveAsync(purchase);

                return new(result);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PurchaseDto>> GetAllAsync()
        {
            PurchaseDto[] purchaseItems;
            try
            {
                purchaseItems = await _purchaseInteractor.GetAll()
                    .Select(x => new PurchaseDto(x)).ToArrayAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return purchaseItems.ToList();
        }

        public async Task<PurchaseDto> GetByIdAsync(int id)
        {
            Purchase purchase;
            try
            {
                purchase = await _purchaseInteractor.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (purchase == null)
                    return null;
            }
            catch (Exception ex)
            {
                purchase = null;
            }

            return new(purchase);
        }

        public async Task<PurchaseDto> UpdateAsync(PurchaseDto model)
        {
            if (model == null) return null;
            try
            {
                var product = await _purchaseInteractor.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (product == null)
                    return null;

                product = await _purchaseInteractor.UpdateAsync(new(model));

                return new(product);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}