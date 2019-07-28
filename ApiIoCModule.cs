using Autofac;
using ConfigTemplate.ContentRoot.Settings;
using ConfigTemplate.Validators;

namespace ConfigTemplate
{
    public class ApiIoCModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ValidatorIoCModule>();
            builder.Register(s => new StaticSettings()).As<ISettings>().SingleInstance();
        }
    }
}