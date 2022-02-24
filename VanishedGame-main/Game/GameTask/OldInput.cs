using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class OldInput
    {
        static public string Ask(string question)
        {
            System.Console.WriteLine(question);
            return System.Console.ReadLine().ToLower();
        }
        static public void MenuOption(Yuzo yuzo)
        {
            Menu.QuitGame(yuzo);
        }
        //static public string YesNo(Yuzo yuzo)
        //{

        //}
        public static void GeneralChoice(Yuzo yuzo)
        {
            var Choice = OldInput.Ask("Was willst du tun?: (Gebe Inventar, Bett, Korb, Flasche oder Waffe ein, um dahin zu gehen.)");

            switch (Choice)
            {
                case "quit":
                    Menu.QuitGame(yuzo);
                    break;
                case "inventar":
                    Menu.OpenInventory(yuzo);
                    break;
                case "bett":
                    Adventure.GoToStartBed(yuzo);
                    break;
                case "korb":
                    Adventure.GoToStartBasket(yuzo);
                    break;
                case "flasche":
                    Adventure.GoToStartBottle(yuzo);
                    break;
                case "waffe":
                    Menu.InspectWeapon(yuzo);
                    Adventure.Play(yuzo);
                    break;
                default:
                    GameText.InvalidChoice(yuzo);
                    Adventure.Play(yuzo);
                    break;
            }
        }
        public static void YesNoChoice(Yuzo yuzo)
        {
            var YesNoChoice = OldInput.Ask("");
        }
    }
}
