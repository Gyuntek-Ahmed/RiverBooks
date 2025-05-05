using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.Endpoints
{
    public record UpdateBookPriceRequest(Guid Id, decimal NewPrice);

    public class UpdateBookPriceRequestValidator : Validator<UpdateBookPriceRequest>
    {
        public UpdateBookPriceRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage("Book ID is required.");

            RuleFor(x => x.NewPrice)
                .GreaterThan(0)
                .WithMessage("Book prices must be greater than zero.");
        }
    }
}
