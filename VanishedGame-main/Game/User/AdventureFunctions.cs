using Game.Utilities;
using System;
using System.Collections.Generic;
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
                    Adventure.GoToStartBed(yuzo);
                    break;
                case "korb":
                    Adventure.GoToStartBasket(yuzo);
                    break;
                case "flasche":
                    Adventure.GoToStartBottle(yuzo);
                    break;
            }
        }
    }
}
