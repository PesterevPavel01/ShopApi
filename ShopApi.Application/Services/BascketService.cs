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
    internal class BascketService : ICommonService<BascketDto, int>
    {
        private readonly ICommonInteractor<Bascket> _bascketInteractor;

        public BascketService(ICommonInteractor<Bascket> bascketInteractor)
        {
            _bascketInteractor = bascketInteractor;
        }

        public async Task<BascketDto> CreateAsync(BascketDto model)
        {
            if (model == null) return new BascketDto();

            try
            {
                Bascket bascket = new Bascket(model);

                Bascket result = await _bascketInteractor.CreateAsync(bascket);

                return new(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<bool> CreateMultiple(List<BascketDto> listModel)
        {
            throw new NotImplementedException();
        }

        public async Task<BascketDto> DeleteAsync(int id)
        {

            try
            {
                var bascket = await _bascketInteractor.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (bascket == null)
                    return null;

                Bascket result = await _bascketInteractor.RemoveAsync(bascket);

                return new(result);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BascketDto>> GetAllAsync()
        {
            BascketDto[] basckets;
            try
            {
                basckets = await _bascketInteractor.GetAll()
                    .Select(x => new BascketDto(x)).ToArrayAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return basckets.ToList();
        }

        public async Task<BascketDto> GetByIdAsync(int id)
        {
            Bascket bascket;
            try
            {
                bascket = await _bascketInteractor.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (bascket == null)
                    return null;
            }
            catch (Exception ex)
            {
                bascket = null;
            }

            return new(bascket);
        }

        public async Task<BascketDto> UpdateAsync(BascketDto model)
        {
            if (model == null) return null;
            try
            {
                Bascket bascket = await _bascketInteractor.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (bascket == null)
                    return null;

                bascket = new(model);

                await _bascketInteractor.UpdateAsync(bascket);

                return new(bascket);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DeleteEmployeeEntitysAsync(int EmployeeId)
        {
            var basckets = await _bascketInteractor.GetAll().Where(p => p.EmployeeId == EmployeeId).ExecuteDeleteAsync();
            return basckets;
        }
    }
}