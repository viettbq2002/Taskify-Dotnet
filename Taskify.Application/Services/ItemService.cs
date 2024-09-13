using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.Common;
using Taskify.Application.Constant;
using Taskify.Application.DTOs.Item;
using Taskify.Application.Exceptions;
using Taskify.Application.Interfaces;
using Taskify.Domain.Entities;
using Taskify.Domain.SeedWorks;
using Taskify.Domain.Specifications.Item;
namespace Taskify.Application.Services
{
    public sealed class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateItem> _createItemValidator;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateItem> createItemValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createItemValidator = createItemValidator;
        }

        public async Task ClearCompletedItemsAsync()
        {
            await _unitOfWork.Items.ExecuteRawSQLAsync($"UPDATE [Items] SET [IsArchived ] = 1 WHERE [IsCompleted] = 1");
          
        }

        public async Task<ApiResponse<ItemResponse>> CreateAsync(CreateItem request)
        {
            if(request.CategoryId != null)
            {
                var validateResult =  await _createItemValidator.ValidateAsync(request);
                if (!validateResult.IsValid)
                {
                    throw new BadRequestException(ResponseMessage.CreateFailure, validateResult);
                }
            }
            var item = _mapper.Map<Item>(request);
            var createdItem = await _unitOfWork.Items.AddAsync(item);
            await _unitOfWork.SaveAsync();
            var mappedResponse = _mapper.Map<ItemResponse>(createdItem);
            var response = ApiResponse<ItemResponse>.Created(ResponseMessage.Created, mappedResponse);
            return response;
        }

        public async Task DeleteArchiveItemsAsync()
        {
            var query = new ArchivedTask(true);
            await _unitOfWork.Items.DeleteManyAsync(query);
        }

        public Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<ItemResponse>>> GetListAsync(bool isArchived)
        {
            var items =_unitOfWork.Items.GetAll(x => x.IsArchived == isArchived).ProjectTo<ItemResponse>(_mapper.ConfigurationProvider);
            var mappedItems = await items.OrderByDescending(e => e.CreatedAt).ToListAsync();
            var response = ApiResponse<ItemResponse>.GetListSuccess(ResponseMessage.Success,mappedItems);
            return response;
        }

        public async Task<ApiResponse<ItemResponse>> UpdateAsync(int key, UpdateItem request)
        {
            var item = await _unitOfWork.Items.GetByIdAsync(key) ?? throw new NotFoundException(ResponseMessage.NotFound);
            var updatedItem =  _mapper.Map(request, item);
            await _unitOfWork.Items.UpdateAsync(item);
            await _unitOfWork.SaveAsync();
            var mappedResponse = _mapper.Map<ItemResponse>(updatedItem);
            var response = ApiResponse<ItemResponse>.Success(ResponseMessage.Success, mappedResponse);
            return response;
            

        }
    }
}
