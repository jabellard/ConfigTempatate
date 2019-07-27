using Autofac;
using ConfigTemplate.ContentRoot.Settings;

namespace ConfigTemplate
{
    public class ApiIoCModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(s => new StaticSettings()).As<ISettings>().SingleInstance();
        }
    }
}