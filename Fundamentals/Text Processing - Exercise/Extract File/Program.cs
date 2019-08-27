using System;

namespace Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] path = Console.ReadLine().ToCharArray();
            ExtraxtingExtensionAndName(path);

        }

        private static void ExtraxtingExtensionAndName(char[] path)
        {
            Array.Reverse(path);

            string strPath = string.Join("", path);
            int index = strPath.IndexOf('.');
            string extension = strPath.Substring(0, index);
            strPath = strPath.Remove(0, index + 1);

            int secondIndex = strPath.IndexOf('\\');
            string name = strPath.Substring(0, secondIndex);

            Printing(extension, name);
        }

        private static void Printing(string extension, string name)
        {
            char[] nameChar = name.ToCharArray();
            Array.Reverse(nameChar);
            Console.WriteLine($"File name: {string.Join("",nameChar)}");

            char[] extentionChar = extension.ToCharArray();
            Array.Reverse(extentionChar);
            Console.WriteLine($"File extension: {string.Join("", extentionChar)}");
        }
    }
}
