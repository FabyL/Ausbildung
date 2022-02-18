using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Menu
    {
        public static void Run(string userInput, Yuzo yuzo)
        {
            switch(userInput)
            {
                case "reset":
                    Console.WriteLine("\n");
                    Adventure.StartGame();
                    break;
                case "quit":
                    QuitGame(yuzo);
                    break;
                case "hp":
                    ShowHP(yuzo);
                    break;
                case "inventar":
                    OpenInventory(yuzo);
                    break;
                case "waffe":
                    InspectWeapon(yuzo);
                    Adventure.PlayLevel1(yuzo);
                    break;
            }
        }
        public static void QuitGame(Yuzo yuzo)
        {
            Console.WriteLine("Möchtest du das Spiel beenden? (ja/nein)");
            var Choice = Console.ReadLine().ToLower();

            switch (Choice)
            {
                case "ja":
                    Console.WriteLine("Drücke eine beliebige Taste um das Spiel zu beenden.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "nein":
                    Adventure.PlayLevel1(yuzo);
                    break;
                default:
                    Console.WriteLine("Bitte wähle eine Möglichkeit aus.");
                    QuitGame(yuzo);
                    break;
            }
        }
        public static void ShowHP(Yuzo yuzo)
        {
            Console.WriteLine("Du hast {0} Leben", yuzo.HealthPoints);
            Adventure.PlayLevel1(yuzo);
        }
        public static void OpenInventory(Yuzo yuzo)
        {
            if (yuzo.Inventory != null)
            {
                foreach (var item in yuzo.Inventory)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"Name: {item.Name}, Effekt: {item.EffectDescription}");
                    }                        
                }
            }
            else
            {
                Console.WriteLine("Dein Inventar ist leer.");
            }
            Adventure.PlayLevel1(yuzo);
        }
        public static void InspectWeapon(Yuzo yuzo)
        {
            if (yuzo.YuzosWeapon != null)
            {
                Console.WriteLine($"Name: {yuzo.YuzosWeapon.Name}, Schaden: {yuzo.YuzosWeapon.Damage}, Angriff: {yuzo.YuzosWeapon.Attack}");
            }
            else
            {
                Console.WriteLine("Du hast keine Waffe.");
            }
            Adventure.PlayLevel1(yuzo);
        }
    }
}
