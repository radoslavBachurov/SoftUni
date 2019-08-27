using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Reverse of Text To Morse Code (https://code.sololearn.com/cOC4O4iatFcH/#cs)
//Morse code from http://morsecode.scphillips.com/morse2.html
//Supported characters: abcdefghijklmnopqrstuvwxyz 0123456789 .,:?! '-/"@=
//Created by Jafca

namespace SoloLearn
{
    class Program
    {
        static Dictionary<char, string> morseToChar = new Dictionary<char, string>()
        {
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."},
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            
            {'0', "-----"},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            
            {' ', "|"},
            {'.', ".-.-.-"},
            {',', "--..--"},
            {':', "---..."},
            {'?', "..--.."},
            {'!', "..--."},
            {'\'', ".----."},
            {'-', "-....-"},
            {'/', "-..-."},
            {'"', ".-..-."},
            {'@', ".--.-."},
            {'=', "-...-"}
        };
        
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Trim().Split(' ');
            StringBuilder output = new StringBuilder();
            foreach(string s in input)
                if(morseToChar.ContainsValue(s))
                    output.Append(morseToChar.FirstOrDefault(x => x.Value == s).Key);
            Console.WriteLine($"{output}");
            
        }
    }
}
