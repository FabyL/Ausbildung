using Game.Models;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Utilities
{
    class Input
    {
        public static string Run(string text, List<string> choices, List<string> MenuChoices, List<string> YesNoChoices, Yuzo yuzo)
        {
            Console.WriteLine(text);
            var userInput = Console.ReadLine().ToLower();

                if (choices.Contains(userInput))
                {
                AdventureFunctions.Run(userInput, yuzo);
                return null;
                }

                if (MenuChoices.Contains(userInput))
                {
                Menu.Run(userInput, yuzo);
                return null;
                }

                if (YesNoChoices.Contains(userInput))
                {
                return userInput;
                }
                return Run("Versuchs erneut", choices, MenuChoices, YesNoChoices, yuzo);
        }
    //    public static List<string> choices { get; } = new List<string> { "bett", "korb", "flasche" };
    //    public static List<string> MenuChoices { get; } = new List<string> { "reset", "quit", "waffe" };
    //    public static List<string> YesNoChoices { get; } = new List<string> { "ja", "nein" };
    }
}