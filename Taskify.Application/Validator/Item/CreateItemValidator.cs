using FluentValidation;
using Taskify.Application.Constant;
using Taskify.Application.DTOs.Item;
using Taskify.Domain.SeedWorks;

namespace Taskify.Application.Validator.Item
{
    public class CreateItemValidator : AbstractValidator<CreateItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateItemValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .MustAsync(CategoryMustExist).WithMessage($"Category {ResponseMessage.NotFound}");
        }
        public async Task<bool> CategoryMustExist(int? id, CancellationToken cancellationToken) {
            if (id is null) return true;
            var isExist = await _unitOfWork.Categories.AnyAsync(c => c.Id == id);
            return isExist;
        }
    }
}
