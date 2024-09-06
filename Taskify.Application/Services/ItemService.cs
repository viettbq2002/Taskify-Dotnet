using AutoMapper;
using FluentValidation;
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

        public Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<ItemResponse>>> GetListAsync(bool isArchived)
        {
            var items = await _unitOfWork.Items.GetAllAsync(c => c.IsArchived == isArchived);
            var mappedItems = _mapper.Map<IEnumerable<ItemResponse>>(items);
            var response = ApiResponse<ItemResponse>.GetListSuccess(ResponseMessage.Success,mappedItems);
            return response;
        }

        public  Task<ApiResponse<IEnumerable<ItemResponse>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ItemResponse>> UpdateAsync(UpdateItem request)
        {
            throw new NotImplementedException();
        }
    }
}
