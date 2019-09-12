using System;
using System.Linq;

namespace _Demo__String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            string finalText = string.Empty;
            while ((text = Console.ReadLine()) != "End")
            {
                string[] textArr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (textArr[0] == "Add")
                {
                    finalText += textArr[1];
                }
                else if (textArr[0] == "Upgrade")
                {
                    char charToFind = char.Parse(textArr[1]);
                    finalText = finalText.Replace(charToFind, (char)(charToFind + 1));
                }
                else if (textArr[0] == "Print")
                {
                    Console.WriteLine(finalText);
                }
                else if (textArr[0] == "Index")
                {
                    FindIndex(finalText, textArr);
                    Console.WriteLine();
                }
                else if (textArr[0] == "Remove")
                {
                    string wordToRemove = textArr[1];
                    while (true)
                    {
                        int startIndex = finalText.IndexOf(wordToRemove);
                        if (startIndex < 0)
                        {
                            break;
                        }
                        finalText = finalText.Remove(startIndex, wordToRemove.Length);
                    }
                }
            }

        }

        private static void FindIndex(string finalText, string[] textArr)
        {
            char charToFind = char.Parse(textArr[1]);
            int index = -1;
            bool none = true;
            while (true)
            {
                index = finalText.IndexOf(charToFind, index + 1);
                if (index < 0)
                {
                    if (none)
                    {
                        Console.WriteLine("None");
                    }
                    break;
                }
                Console.Write(index + " ");
                none = false;
            }
        }
    }
}
