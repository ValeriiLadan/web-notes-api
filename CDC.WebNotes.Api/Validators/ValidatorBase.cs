using FluentValidation;

namespace CDC.WebNotes.Api.Validators
{
    public abstract class ValidatorBase<TModel> : AbstractValidator<TModel>
    {
        protected const int MaximumTitleTextLength = 60;
        protected const int MaximumDesctiptionTextLength = 255;
    }
}
