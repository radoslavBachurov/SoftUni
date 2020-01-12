using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string name, params string[] fieldsNames)
    {
        var classToHack = Type.GetType($"{typeof(StartUp).Namespace}.{name}");
        FieldInfo[] fields = classToHack.GetFields(BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        Object classinstance = Activator.CreateInstance(classToHack, new object[] { });

        StringBuilder newSb = new StringBuilder();
        newSb.AppendLine($"Class under investigation: {name}");

        foreach (var field in fields.Where(x => fieldsNames.Contains(x.Name)))
        {
            newSb.AppendLine($"{field.Name} = {field.GetValue(classinstance)}");
        }

        return newSb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string input)
    {
        var classToHack = Type.GetType($"{typeof(StartUp).Namespace}.{input}");
        FieldInfo[] fields = classToHack.GetFields(BindingFlags.Public | BindingFlags.Instance);

        StringBuilder newSb = new StringBuilder();

        foreach (var field in fields)
        {
            newSb.AppendLine($"{field.Name} must be private!");
        }

        var privateGetters = classToHack.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        var publicSetters = classToHack.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (var item in privateGetters.Where(x => x.Name.StartsWith("get")))
        {
            newSb.AppendLine($"{item.Name} have to be public!");
        }

        foreach (var item in publicSetters.Where(x => x.Name.StartsWith("set")))
        {
            newSb.AppendLine($"{item.Name} have to be private!");
        }

        return newSb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var classToHack = Type.GetType($"{typeof(StartUp).Namespace}.{className}");
        var baseClass = classToHack.BaseType.Name;

        StringBuilder newSB = new StringBuilder();

        newSB.AppendLine($"All Private Methods of Class: {className}");
        newSB.AppendLine($"Base Class: {classToHack.BaseType.Name}");

        var privateMethods = classToHack.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var method in privateMethods)
        {
            newSB.AppendLine(method.Name);
        }

        return newSB.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        var classToHack = Type.GetType($"{typeof(StartUp).Namespace}.{className}");
        var methods = classToHack.GetMethods(BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        StringBuilder newSB = new StringBuilder();

        foreach (var method in methods.Where(x => x.Name.StartsWith("get")))
        {
            newSB.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
        {
            newSB.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return newSB.ToString().Trim();
    }
}

