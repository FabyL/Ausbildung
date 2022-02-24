using Game.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AdventureFunctions
    {
        public static void Run(string userInput, Yuzo yuzo, Cave cave)
        {
            switch (userInput)
            {
                case "bett":
                    Adventure.GoToBedLevel1(yuzo, cave);
                    break;
                case "korb":
                    Adventure.GoToBasketLevel1(yuzo, cave);
                    break;
                case "flasche":
                    Adventure.GoToBottleLevel1(yuzo, cave);
                    break;
                case "trinken":
                    yuzo.UseBottle();
                    Adventure.PlayLevel1(yuzo, cave);
                    break;
                case "verlassen":
                    Adventure.LeaveCave(yuzo, cave);
                    break;
                default:
                    Run(userInput, yuzo, cave);
                    break;
            }
        }
    }
}
