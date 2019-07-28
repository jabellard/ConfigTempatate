using System;
using Autofac;
using ConfigTemplate.BindingModels;
using FluentValidation;

namespace ConfigTemplate.Validators
{
    public class ValidatorIoCModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .As(t => t.GetInterfaces()[0])
                .InstancePerDependency();
        }
    }
}