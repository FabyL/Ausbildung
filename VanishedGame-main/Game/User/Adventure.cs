using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Adventure
    {
        private static void StartGame()
        {
            var yuzo = new Yuzo();

            GameText.Introduction(yuzo);
            Play(yuzo);
        }
        public static void Play(Yuzo yuzo)
        {
            Console.WriteLine("Was willst du tun?: (Gebe Inventar, Bett, Korb, Flasche oder Waffe ein, um dahin zu gehen.)");

            var Choice = Console.ReadLine();

            switch (Choice)
            {
                case "Quit":
                    Menu.QuitGame(yuzo);
                    break;
                case "Inventar":
                    Menu.OpenInventory(yuzo);
                    break;
                case "Bett":
                    GoToStartBed(yuzo);
                    break;
                case "Korb":
                    GoToStartBasket(yuzo);
                    break;
                case "Flasche":
                    GoToStartBottle(yuzo);
                    break;
                case "Waffe":
                    Menu.InspectWeapon(yuzo);
                    Play(yuzo);
                    break;
                default:
                    GameText.InvalidChoice(yuzo);
                    Play(yuzo);
                    break;
            }
        }
        public static void GoToStartBed(Yuzo yuzo)
        {
            Console.WriteLine("Du stehst vor dem Bett. Möchtest du ein schläfchen machen? (Schreib: Ja/Nein)");
            var Choice = Console.ReadLine();

            if (yuzo.HasStick == false)
            {
                switch (Choice)
                {
                    case "Ja":
                        if (yuzo.YuzosWeapon == null)
                            FindeStartAst(yuzo);
                        break;
                    case "Nein":
                        Console.WriteLine("Du gehst wieder vom Bett weg.");
                        Play(yuzo);
                        break;
                    default:
                        GameText.InvalidInput(yuzo);
                        GoToStartBed(yuzo);
                        break;
                }
            }
            else
            {
                switch (Choice)
                {
                    case "Ja":
                        Console.WriteLine("Du fühlst dich nach dem Schlaf erholt.");
                        Play(yuzo);
                        break;
                    case "Nein":
                        Console.WriteLine("Du gehst wieder vom Bett weg.");
                        Play(yuzo);
                        break;
                    default:
                        GameText.InvalidInput(yuzo);
                        GoToStartBed(yuzo);
                        break;
                }
            }
        }
        public static void FindeStartAst(Yuzo yuzo)
        {
            if (yuzo.YuzosWeapon == null)
            {
                Console.WriteLine("Zwischen den Laken findest du ein Ast.");
                Console.WriteLine("Möchtest du den Ast mitnehmen? (Schreib: Ja/Nein)");
                var Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "Ja":
                        yuzo.HasStick = true;
                        yuzo.YuzosWeapon = new Weapon { Name = "Ast", Durability = 20, Damage = 1 };
                        Console.WriteLine("Du hast den Ast mitgenommen.");
                        Console.WriteLine("Gebe Waffe ein, um deine Waffe anzuschauen.");
                        Play(yuzo);
                        break;
                    case "Nein":
                        Console.WriteLine("Du lässt den Ast liegen.");
                        Play(yuzo);
                        break;
                    default:
                        GameText.InvalidInput(yuzo);
                        FindeStartAst(yuzo);
                        break;
                }
            }
            Play(yuzo);
        }
        public static void GoToStartBasket(Yuzo yuzo)
        {
            if (yuzo.HasBasket)
            {
                Console.WriteLine("Du hast den Korb schon mitgenommen.");
            }
            else
            {
                Console.WriteLine("Der Korb ist leer. Möchtest du den Korb mitnehmen? (Schreib: Ja/Nein)");
                var Choice = Console.ReadLine();
                switch (Choice)
                {
                    case "Ja":
                        yuzo.Inventory = new Item[5];
                        yuzo.HasBasket = true;
                        Console.WriteLine("Du nimmst den Korb mit.");
                        break;
                    case "Nein":
                        Console.WriteLine("Du lässt den Korb stehen.");
                        break;
                    default:
                        GameText.InvalidInput(yuzo);
                        GoToStartBasket(yuzo);
                        break;
                }
            }
            Play(yuzo);
        }
        public static void GoToStartBottle(Yuzo yuzo)
        {
            if (yuzo.HasBottle)
            {
                Console.WriteLine("Du hast die Flasche schon mitgenommen.");
            }
            else
            {
                Console.WriteLine("Die Flasche ist mit Wasser gefüllt. Möchtest du die Flasche mitnehmen? (Schreib: Ja/Nein)");
                var Choice = Console.ReadLine();

                if (yuzo.HasBasket)
                {
                    switch (Choice)
                    {
                        case "Ja":
                            Item Flasche = new Item();
                            yuzo.HasBottle = true;
                            yuzo.Take(new Item { Name = "Flasche", Effect = "Füllt einen kleinen HP Anteil." });
                            Console.WriteLine("Du verstaust die Flasche in den Korb.");
                            break;
                        case "Nein":
                            Console.WriteLine("Du lässt die Flasche stehen");
                            Play(yuzo);
                            break;
                        default:
                            GameText.InvalidInput(yuzo);
                            GoToStartBasket(yuzo);
                            break;
                    }
                }
                else
                {
                    switch (Choice)
                    {
                        case "Ja":
                            Console.WriteLine("Vielleicht kannst du die Flasche mitnehmen, wenn du sie verstauen kannst.");
                            break;
                        case "Nein":
                            Console.WriteLine("Du lässt die Flasche liegen.");
                            break;
                        default:
                            GameText.InvalidInput(yuzo);
                            GoToStartBottle(yuzo);
                            break;
                    }
                }
            }
            Play(yuzo);
        }
    }
}
