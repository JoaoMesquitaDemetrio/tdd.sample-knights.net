using FluentValidation;
using Sample.Knights.Core.Application.DataTransferObjects.Knights;

namespace Sample.Knights.Core.Application.Validations;

public class AttributesInsertValidation : AbstractValidator<AttributesInsert>
{
    public AttributesInsertValidation()
    {
        RuleFor(x => x.Strength).InclusiveBetween(0, 20).WithMessage("A Força deve estar entre 0 e 20.");
        RuleFor(x => x.Dexterity).InclusiveBetween(0, 20).WithMessage("A Destreza deve estar entre 0 e 20.");
        RuleFor(x => x.Intelligence).InclusiveBetween(0, 20).WithMessage("A Inteligência deve estar entre 0 e 20.");
        RuleFor(x => x.Constitution).InclusiveBetween(0, 20).WithMessage("A Constituição deve estar entre 0 e 20.");
        RuleFor(x => x.Charisma).InclusiveBetween(0, 20).WithMessage("O Carisma deve estar entre 0s e 20.");
    }
}
