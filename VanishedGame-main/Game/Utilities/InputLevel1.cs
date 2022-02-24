using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Utilities
{
    class InputLevel1
    {
        public static string Run(string text, List<string> Level1Choices, List<string> MenuChoices, List<string> YesNoChoices, Yuzo yuzo, Cave cave)
        {
            Console.WriteLine(text);
            var userInput = Console.ReadLine().ToLower();

                if (Level1Choices.Contains(userInput))
                {
                AdventureFunctions.Run(userInput, yuzo, cave);
                return null;
                }
                if (MenuChoices.Contains(userInput))
                {
                Menu.Run(userInput, yuzo, cave);
                return null;
                }
                if (YesNoChoices.Contains(userInput))
                {
                return userInput;
                }
                return Run("Versuchs erneut", Level1Choices, MenuChoices, YesNoChoices, yuzo, cave);
        }
    }
}