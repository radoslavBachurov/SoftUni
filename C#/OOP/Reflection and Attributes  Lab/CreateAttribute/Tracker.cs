using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);

        var methods = type.GetMethods(BindingFlags.Instance | 
            BindingFlags.Public);

        foreach (var method in methods)
        {
            if (method.CustomAttributes
                .Any(x => x.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes();

                foreach (AuthorAttribute attr in attributes.Where(x => x.GetType() == typeof(AuthorAttribute)))
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
