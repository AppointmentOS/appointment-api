using FluentValidation;

namespace Bookeasy.Api.RequestSchemas
{
    public class NewBusinessUserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string BusinessName { get; set; }
    }

    public class NewUserDtoValidator : AbstractValidator<NewBusinessUserDto>
    {
        public NewUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.FirstName).MinimumLength(2).MaximumLength(15);
            RuleFor(x => x.LastName).MinimumLength(2).MaximumLength(15);
            RuleFor(x => x.BusinessName).NotEmpty();
        }
    }
}
