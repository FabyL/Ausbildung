using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class InputLevel2
    {
        public static string Run(string text, List<string> Level2Choices, List<string> MenuChoices, List<string> YesNoChoices, Yuzo yuzo, Cave cave)
        {
            Console.WriteLine(text);
            var userInput = Console.ReadLine().ToLower();

            if (Level2Choices.Contains(userInput))
            {
                Level2Functions.Run(userInput, yuzo, cave);
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
            return Run("Versuchs erneut", Level2Choices, MenuChoices, YesNoChoices, yuzo, cave);
        }
    }
}