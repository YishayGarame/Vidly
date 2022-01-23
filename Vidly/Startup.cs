using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly.Startup))]
namespace Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //MapperConfiguration mappingConfigs = new MapperConfiguration(mappingConfig =>
        //{
        //    mappingConfig.AddProfile(new MappingProfile());
        //});
    }
}
