using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Emoji_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int[] emojiCode = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<string> emojisToPrint = new List<string>();
            string emojiName = DecodingEmojiCode(emojiCode);
            bool toDouble = false;

            string validEmojis = ValidatingEmojis(text, emojisToPrint);

            int emojiPower = CalculatingEmojiPower(validEmojis, toDouble, emojiName,emojisToPrint);

            Printing(emojisToPrint, emojiPower);

        }

        private static void Printing(List<string> emojisToPrint, int emojiPower)
        {
            if (emojisToPrint.Count > 0)
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", emojisToPrint)}");
            }

            Console.WriteLine($"Total Emoji Power: {emojiPower}");
        }
        private static string ValidatingEmojis(string text, List<string> emojisToPrint)
        {
            Regex emojiValidator = new Regex(@"(?<=[\t\s]):[a-z]{4,}:[\t\s\.!,?]");
            var matches = emojiValidator.Matches(text);

            string validEmojis = string.Empty;
            foreach (Match emoji in matches)
            {
                validEmojis += emoji.ToString();
            }

            return validEmojis;
        }
        private static int CalculatingEmojiPower(string validEmojis, bool toDouble, string emojiName,List<string> emojisToPrint)
        {
            Regex emojiOnlyLetters = new Regex(@"[a-z]{4,}");
            var OnlyLettersMatch = emojiOnlyLetters.Matches(validEmojis);
            int emojiPower = 0;

            foreach (Match item in OnlyLettersMatch)
            {
                string itemStr = item.ToString();

                string forPrinting = ":" + itemStr + ":";
                emojisToPrint.Add(forPrinting);

                if (itemStr == emojiName)
                {
                    toDouble = true;
                }
                for (int i = 0; i < itemStr.Length; i++)
                {
                    emojiPower += itemStr[i];
                }
            }

            if (toDouble)
            {
                emojiPower *= 2;
            }

            return emojiPower;
        }
        private static string DecodingEmojiCode(int[] emojiCode)
        {
            string emojiName = string.Empty;
            for (int i = 0; i < emojiCode.Length; i++)
            {
                emojiName += (char)emojiCode[i];
            }

            return emojiName;
        }
    }
}
