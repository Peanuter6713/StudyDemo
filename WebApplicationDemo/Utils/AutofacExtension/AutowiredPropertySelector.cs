using Autofac.Core;
using System.Linq;
using System.Reflection;

namespace WebApplicationDemo.Utils.AutofacExtension
{
    public class AutowiredPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            // 需要一个判断的维度
            return propertyInfo.CustomAttributes.Any(it => it.AttributeType == typeof(CustomPropertyAttribute));
        }
    }
}
