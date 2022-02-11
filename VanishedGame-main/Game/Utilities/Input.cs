using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Utilities
{
    class Input
    {
        public static string Run(string text, List<string> choices)
        {
            Console.WriteLine(text);
            var userInput = Console.ReadLine().ToLower();
             

            if(choices.Contains(userInput))
            {
                return userInput;
            }

            if(Menu.MenuChoices.Contains(userInput))
            {
                Menu.Run(userInput);
                return null;
            }

           





            return userInput;
        }
    }
}
