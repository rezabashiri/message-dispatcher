using AutoMapper;
using Message.Dispatcher.Mapping.Helpers;
using Xunit;

namespace Message.Dispatcher.MappingTests
{
    public class MapperAssertion
    {

        [Fact]
        public void Verify_AutoMapper_Config()
        {
            IConfigurationProvider config = new MapperConfiguration(x => x.AddMaps(AssemblyHelper.GetApplicationLayerAssembly()));
            config.AssertConfigurationIsValid();
        }
    }
}
