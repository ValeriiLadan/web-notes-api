using CDC.WebNotes.Api.Models.Notes;
using FluentValidation;

namespace CDC.WebNotes.Api.Validators.Notes
{
    public class CreateNoteValidator : ValidatorBase<CreateNote>
    {
        public CreateNoteValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .MaximumLength(MaximumTitleTextLength);

            RuleFor(model => model.Description)
                .MaximumLength(MaximumDesctiptionTextLength)
                .WithMessage($"Description must be less then {MaximumDesctiptionTextLength}");
        }
    }
}
