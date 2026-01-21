using FluentValidation;

namespace Marketplace.Modules.ItemListings.Application.UseCases.Items.Queries.GetItemsWithPagination;

internal class GetItemsWithPaginationQueryValidator : AbstractValidator<GetItemsWithPaginationQuery>
{
    public GetItemsWithPaginationQueryValidator()
    {
        RuleFor(q => q.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber must be greater than or equal to 1.");

        RuleFor(q => q.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize must be greater than or equal to 1.");
    }
}
