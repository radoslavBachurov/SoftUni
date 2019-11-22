using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string name, params string[] fieldsNames)
        {
            var classToHack = Type.GetType($"{typeof(StartUp).Namespace}.{name}");
            FieldInfo[] fields = classToHack.GetFields(BindingFlags.NonPublic |
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            Object classinstance = Activator.CreateInstance(classToHack, new object[] { });

            StringBuilder newSb = new StringBuilder();
            newSb.AppendLine($"Class under investigation: {classToHack.Name}");

            foreach (var field in fields.Where(x => fieldsNames.Contains(x.Name)))
            {
                newSb.AppendLine($"{field.Name} = {field.GetValue(classinstance)}");
            }

            return newSb.ToString().Trim();
        }
    }
}
