using FluentValidation;
using Sample.Knights.Core.Application.DataTransferObjects.Knights;
using Sample.Utils.Extensions;

namespace Sample.Knights.Core.Application.Validations;

public class KnightInsertValidation : AbstractValidator<KnightInsert>
{
    public KnightInsertValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(500).WithMessage("O Nome não pode ser vazio e deve ter no máximo 500 caracteres.") ;
        RuleFor(x => x.Nickname).NotEmpty().MaximumLength(250).WithMessage("O Apelido não pode ser vazio e deve ter no máximo 250 caracteres.") ;
        RuleFor(x => x.Birthday).Custom((birthday, context) =>
        {
            if (birthday.IsNullDateTime())
                context.AddFailure("Birthday", "Informe a data de nascimento válida.");
        });

        RuleFor(x => x.Attributes).NotNull().SetValidator(new AttributesInsertValidation()).WithMessage("Informe os atributos do cavaleiro.");
        RuleForEach(x => x.Weapons).NotNull().SetValidator(new WeaponInsertValidation()).WithMessage("Informe as armas do cavaleiro.");
        RuleFor(x => x.KeyAttribute).IsInEnum().WithMessage("Os valores aceitos para o Tipo de Atributo são: STRENGTH, DEXTERITY, CONSTITUTION, INTELLIGENCE, WISDOM e CHARISMA.");
    }
}
