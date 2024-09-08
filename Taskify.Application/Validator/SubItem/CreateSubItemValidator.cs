using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Entities;
using Taskify.Domain.SeedWorks;
namespace Taskify.Application.Validator.SubItem
{
    public class CreateSubItemValidator : AbstractValidator<Domain.Entities.SubItem>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubItemValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.ItemId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(ItemMustExistAsync)
                .WithMessage("Cannot create Sub Item because not found or invalid Item");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Cannot create sub item wihtout title");
        }
        public async Task<bool> ItemMustExistAsync(int itemId, CancellationToken cancellationToken)
        {
            bool isExist = await _unitOfWork.Items.AnyAsync(x => x.Id == itemId);
            return isExist;

        }


    }
}
