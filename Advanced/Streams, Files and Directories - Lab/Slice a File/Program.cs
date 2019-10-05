using System;
using System.IO;

namespace Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine("Resources", "sliceMe.txt");

            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                long partSize = (long)Math.Ceiling(reader.Length / 4m);
                byte[] buffer = new byte[4];

                for (int i = 1; i <= 4; i++)
                {
                    using (var outputFile = new FileStream($"Part-{i}.txt", FileMode.Create))
                    {
                        int byteCount = 0;
                        int readedBytes = 1;
                        while (byteCount < partSize && readedBytes != 0)
                        {
                            readedBytes = reader.Read(buffer, 0, buffer.Length);
                            outputFile.Write(buffer, 0, readedBytes);
                            byteCount += readedBytes;
                        }
                    }
                }
            }
        }
    }
}
