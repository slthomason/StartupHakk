namespace ApiApplication2.Validators;

using ApiApplication2.ViewModels;
using FluentValidation;

public class SaveCarValidator : AbstractValidator<SaveCar>
{
    public SaveCarValidator()
    {
        this.RuleFor(x => x.Cylinders).InclusiveBetween(1, 20);
        this.RuleFor(x => x.Make).NotEmpty();
        this.RuleFor(x => x.Model).NotEmpty();
    }
}
