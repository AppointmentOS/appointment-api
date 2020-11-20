using Bookeasy.Domain.Entities;
using FluentValidation;
using System;

namespace Bookeasy.Api.DTOs
{
    public class NewPostDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string PostType { get; set; }
    }

    public class NewPostValidators : AbstractValidator<NewPostDto>
    {
        public NewPostValidators()
        {
            RuleFor(x => x.Title).MinimumLength(10).MaximumLength(100);
            RuleFor(x => x.Body).MinimumLength(10).MaximumLength(5000);
        }
    }
}
