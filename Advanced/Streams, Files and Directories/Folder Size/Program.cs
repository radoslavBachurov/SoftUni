using System;
using System.IO;

namespace Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filesInTestFolder = Directory.GetFiles("TestFolder");
            decimal memorySum = 0;
            for (int i = 0; i < filesInTestFolder.Length; i++)
            {
                FileInfo newInfo = new FileInfo(filesInTestFolder[i]);
                memorySum += newInfo.Length;
            }

            memorySum = memorySum / 1024 / 1024;
            File.WriteAllText("output.txt", memorySum.ToString());
        }
    }
}
