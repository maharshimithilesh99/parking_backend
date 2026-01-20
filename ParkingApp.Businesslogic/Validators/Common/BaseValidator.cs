using FluentValidation;

public abstract class BaseValidator<T> : AbstractValidator<T>
{
    protected void NotEmptyRule<TProperty>(
        System.Linq.Expressions.Expression<Func<T, TProperty>> expression,
        string fieldName)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage($"{fieldName} is required");
    }

    protected void MaxLengthRule(
        System.Linq.Expressions.Expression<Func<T, string>> expression,
        int length,
        string fieldName)
    {
        RuleFor(expression)
            .MaximumLength(length)
            .WithMessage($"{fieldName} cannot exceed {length} characters");
    }

    protected void EmailRule(
        System.Linq.Expressions.Expression<Func<T, string?>> expression)
    {
        RuleFor(expression)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(expression.Compile()(x)))
            .WithMessage("Invalid email address");
    }

    protected void MobileRule(
        System.Linq.Expressions.Expression<Func<T, string?>> expression)
    {
        RuleFor(expression)
            .Matches(@"^[0-9]{10}$")
            .When(x => !string.IsNullOrEmpty(expression.Compile()(x)))
            .WithMessage("Invalid mobile number");
    }
}
