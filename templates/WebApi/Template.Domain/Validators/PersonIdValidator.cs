using FluentValidation;
using Template.Domain.Resources;

namespace Template.Domain.Validators
{
    /// <summary>
    /// Validates the id of a person
    /// </summary>
    /// <shouldpass value="87554"/>
    /// <shouldfail value="0"/>
    /// <shouldfail value="-1"/>
    public class PersonIdValidator : AbstractValidator<int>
    {        
        /// <inheritdoc/>
        public PersonIdValidator()
        {
            RuleFor(i => i).GreaterThan(0).WithMessage(DomainResources.MustBeGreaterThanZero);
        }
    }
}
