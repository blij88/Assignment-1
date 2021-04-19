using System;
using System.Text.RegularExpressions;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a string");
            string SampleString = Console.ReadLine();
            
            Console.WriteLine("type \"y\" to choose amount of spaces");
            short amountOfSpaces = 3;
            if (Console.ReadLine() == "y")
            {
            Console.WriteLine("how many spaces would you like?");
            Int16.TryParse(Console.ReadLine(), out amountOfSpaces);
            }

            Console.WriteLine("press \"y\" to pick character type");
            string characterType = " ";
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Please pick one of the following characters:\n\" \"\n+\n*\n-\n#");
                characterType = Console.ReadLine();
            }
            
            string[] outcomes = InsertCharactersInString(SampleString,amountOfSpaces, characterType);
            Console.WriteLine($"I use ToCharArray and .Join: \n{outcomes[0]}");
            Console.WriteLine($"I use a regular expression: \n{outcomes[1]}");


            Console.ReadLine();
        }

            // opdracht 1a maak een string met spaces tussen alle characters
        private static string[] InsertCharactersInString(string SampleString, short amount, string characterType)
        {
            string fillerString = DefinedSpaces(amount,ChooseCorrectCharacter(characterType));
            
            string[] spacedStrings = new string[3];
            
            char[] charString = SampleString.ToCharArray();
            string JoinString = string.Join(fillerString, charString);
            spacedStrings[0] = JoinString;


            string RegularExpressionString = Regex.Replace(SampleString, ".{1}(?=.)", $"$0{fillerString}");
            spacedStrings[1] = RegularExpressionString;

            return spacedStrings;
        }
        // opdracht 1b geef een hoeveelheid spaties op
        private static string DefinedSpaces(short amount, char charactertype)
        { 
        string characterString = new string(charactertype,amount);

        return characterString;
        }
        //opdracht 1c kies een symbool en vervang de spaties daarmee(gebruik spaties als standaard)
        private static char ChooseCorrectCharacter(string characterType)
        {
            switch (characterType)
            {
                case "+":
                    return '+';
                case "*":
                    return '*';
                case "-":
                    return '-';
                case "#":
                    return '#';
                default:
                    return ' ';
            }
        }
    }
}
