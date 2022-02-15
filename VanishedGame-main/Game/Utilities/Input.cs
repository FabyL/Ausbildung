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
        public static string Run(string text, List<string> Level1Choices, List<string> MenuChoices, List<string> YesNoChoices, Yuzo yuzo)
        {
            Console.WriteLine(text);
            var userInput = Console.ReadLine().ToLower();

                if (Level1Choices.Contains(userInput))
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
                return Run("Versuchs erneut", Level1Choices, MenuChoices, YesNoChoices, yuzo);
        }
        //public static string RunChoice(List<string> Level1Choices, List<string> MenuChoices, List<string> YesNoChoices, Yuzo yuzo)
        //{
        //    var userInput = Console.ReadLine().ToLower();

        //    if (Level1Choices.Contains(userInput))
        //    {
        //        AdventureFunctions.Run(userInput, yuzo);
        //        return null;
        //    }

        //    if (MenuChoices.Contains(userInput))
        //    {
        //        Menu.Run(userInput, yuzo);
        //        return null;
        //    }

        //    if (YesNoChoices.Contains(userInput))
        //    {
        //        return userInput;
        //    }
        //    return Run("Versuchs erneut", Level1Choices, MenuChoices, YesNoChoices, yuzo);
        //}
    //    public static List<string> choices { get; } = new List<string> { "bett", "korb", "flasche" };
    //    public static List<string> MenuChoices { get; } = new List<string> { "reset", "quit", "waffe" };
    //    public static List<string> YesNoChoices { get; } = new List<string> { "ja", "nein" };
    }
}