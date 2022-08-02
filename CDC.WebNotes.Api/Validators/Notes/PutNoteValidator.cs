using CDC.WebNotes.Api.Models.Notes;
using FluentValidation;

namespace CDC.WebNotes.Api.Validators.Notes
{
    public class PatchNoteValidator : ValidatorBase<PutNote>
    {
        public PatchNoteValidator(IValidator<CreateNote> createNoteValidator)
        {
            Include(createNoteValidator);
        }
    }
}
