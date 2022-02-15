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
        public static void Run(string userInput, Yuzo yuzo)
        {
            switch (userInput)
            {
                case "bett":
                    Adventure.GoToBedLevel1(yuzo);
                    break;
                case "korb":
                    Adventure.GoToBasketLevel1(yuzo);
                    break;
                case "flasche":
                    Adventure.GoToBottleLevel1(yuzo);
                    break;
                case "verlassen":
                    Adventure.LeaveCave(yuzo);
                    break;
            }
        }
    }
}
