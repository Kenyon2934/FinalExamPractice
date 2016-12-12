using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalExamPractice.Startup))]
namespace FinalExamPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
