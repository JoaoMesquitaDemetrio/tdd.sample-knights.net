using FluentValidation;
using Sample.Knights.Core.Application.DataTransferObjects.Knights;

namespace Sample.Knights.Core.Application.Validations;

public class WeaponInsertValidation : AbstractValidator<WeaponInsert>
{
    public WeaponInsertValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithMessage("O Nome não pode ser vazio e deve ter no máximo 500 caracteres.");
        RuleFor(x => x.Mod).InclusiveBetween(-2, 3).WithMessage("O Modificador deve estar entre -2 e 3.");
        RuleFor(x => x.TypeAttribute).IsInEnum().WithMessage("Os valores aceitos para o Tipo de Atributo são: STRENGTH, DEXTERITY, CONSTITUTION, INTELLIGENCE, WISDOM e CHARISMA.");
    }
}
