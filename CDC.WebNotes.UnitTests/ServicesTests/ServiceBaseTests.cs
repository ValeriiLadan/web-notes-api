using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Bogus;
using CDC.WebNotes.Application.Mapping;
using CDC.WebNotes.Domain;
using Moq.AutoMock;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

[assembly: ExcludeFromCodeCoverage]

namespace CDC.WebNotes.UnitTests.ServicesTests
{
    public abstract class ServiceBaseTests<TContract, TService>
       where TContract : class
       where TService : class, TContract
    {
        protected TContract Target { get; }
        protected AutoMocker Mocker { get; } = new AutoMocker();
        protected static Faker Faker { get; } = new Faker();
        protected Fixture Fixture { get; }

        protected ServiceBaseTests()
        {
            Fixture = CreateFixture();

            Customize();

            MockDefaultAppMapper();

            Target = Mocker.CreateInstance<TService>();
        }

        protected virtual void Customize() { }

        protected void MockDefaultAppMapper()
        {
            var mapperConfig = new MapperConfiguration(expression =>
            {
                expression.AddMaps(typeof(ApplicationProfile));
                expression.AddCollectionMappers();
            });

            Mocker.Use<IMapper>(new Mapper(mapperConfig));
        }

        private Fixture CreateFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(behavior => fixture.Behaviors.Remove(behavior));

            //TODO Do I realy need it?
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture;
        }
    }
}
