using Autofac;
using Autofac.Features.ResolveAnything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;

namespace WebApplicationDemo.Utils.AutofacExtension
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t =>
             t.IsAssignableTo<IServiceA>()));
        }
    }
}
