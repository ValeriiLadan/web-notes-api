using AutoFixture;

namespace CDC.WebNotes.DataFactories.EntityBuilders
{
    public class BuilderBase<TModel>
    {
        protected TModel _model;

        public virtual TModel Build()
        {
            return _model ?? new Fixture().Create<TModel>(); ;
        }
    }
}
