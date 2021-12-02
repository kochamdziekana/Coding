using FluentValidation;
using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models.Validators
{
    public class RestaurantQueryValidation : AbstractValidator<RestaurantQuery>
    {
        private int[] allowedPageSizes = new[] {5,10,15}; // bo tak chcemy
        private string[] allowedSortByColumnNames = { nameof(Restaurant.Name), nameof(Restaurant.Description), nameof(Restaurant.Category) }; // możliwości sortowania kolumnami
        public RestaurantQueryValidation(RestaurantDbContext dbContext)
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.PageSize)
                .Custom((value, context) =>
                {
                    if (!allowedPageSizes.Contains(value))
                    {
                        context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",", allowedPageSizes)}]");
                    }
                });

            RuleFor(x => x.SortBy)
                .Must(value => string.IsNullOrEmpty(value) ||
                allowedSortByColumnNames.Contains(value))   
                .WithMessage($"Sort by is optional or must be in [{string.Join(",", allowedSortByColumnNames)}]");

        }
    }
}
