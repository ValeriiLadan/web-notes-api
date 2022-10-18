using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.EnumMapping;
using Xunit;

namespace CDC.WebNotes.UnitTests.MappingTests
{
    public class MappingTests
    {
        [Fact]
        public void TestMappingProfiles()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddMaps(typeof(Api.Mapping.ApiProfile),
                               typeof(Application.Mapping.ApplicationProfile));

                config.AddCollectionMappers();

                config.EnableEnumMappingValidation();
            });

            //assert
            configuration.AssertConfigurationIsValid();
        }
    }
}
