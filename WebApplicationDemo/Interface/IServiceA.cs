using Autofac.Extras.DynamicProxy;
using Common.AutofacExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Interface
{
    // AOP 能够在当前接口生效
    //[Intercept(typeof(CustomAutofacAop))]
    public interface IServiceA
    {
        void Show();
    }
}
