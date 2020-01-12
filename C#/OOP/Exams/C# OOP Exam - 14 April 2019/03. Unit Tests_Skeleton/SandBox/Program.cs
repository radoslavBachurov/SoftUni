using System;
using Telecom;
namespace SandBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testPhone = new Phone("samsung", "s8");
            testPhone.AddContact("Ivan", "08835");
            testPhone.AddContact("Ivan", "92837432");
        }
    }
}
