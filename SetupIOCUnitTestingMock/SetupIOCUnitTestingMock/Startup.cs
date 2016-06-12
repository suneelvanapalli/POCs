using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SetupIOCUnitTestingMock.Startup))]
namespace SetupIOCUnitTestingMock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
