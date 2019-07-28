using Autofac;
using ConfigTemplate.BindingModels;
using FluentValidation;

namespace ConfigTemplate.Validators
{
    public class ValidatorIoCModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleValidator>().As<IValidator<Sample>>().InstancePerDependency();
        }
    }
}