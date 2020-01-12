using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.ValidatorAttributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                IEnumerable<Attribute> atrributes = property.GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute);

                foreach (var attribute in atrributes.Cast<MyValidationAttribute>())
                {
                    bool result = attribute.IsValid(property.GetValue(obj));

                    if(!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
