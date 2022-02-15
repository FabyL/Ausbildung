using Game.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Adventure
    {
        public static List<string> MenuChoices = new List<string> { "reset", "quit", "waffe" };
        public static List<string> YesNoChoices = new List<string> { "ja", "nein" };
        public static List<string> Level1Choices = new List<string> { "bett", "korb", "flasche" };
        public static void StartGame()
        {
            var yuzo = new Yuzo();

            GameText.Introduction(yuzo);
            Play(yuzo);

        }
        public static void Play(Yuzo yuzo)
        {             
           var Choice = Input.Run("Was willst du tun ?: (Gebe Inventar, Bett, Korb, Flasche oder Waffe ein, um dahin zu gehen.)", Level1Choices, MenuChoices, YesNoChoices, yuzo);

            if(Choice != null)
            {
                switch (Choice)
                {
                    case "bett":
                        GoToStartBed(yuzo);
                        break;
                    case "korb":
                        GoToStartBasket(yuzo);
                        break;
                    case "flasche":
                        GoToStartBottle(yuzo);
                        break;
                        //    case "Quit":
                        //    Menu.QuitGame(yuzo);
                        //    break;
                        //    case "Inventar":
                        //    Menu.OpenInventory(yuzo);
                        //    break;
                        //case "waffe":
                        //    Menu.InspectWeapon(yuzo);
                        //    Play(yuzo);
                        //    break;
                }
                //default:
                //    GameText.InvalidChoice(yuzo);
                //    Play(yuzo);
                //    break;
            }
        }
        public static void GoToStartBed(Yuzo yuzo)
        {
            var Choice = Input.Run("Du stehst vor dem Bett. Möchtest du ein schläfchen machen? (Schreib: Ja/Nein)", Level1Choices, MenuChoices, YesNoChoices, yuzo);

            if (yuzo.HasStick == false)
            {
                switch (Choice)
                {
                    case "ja":
                        if (yuzo.YuzosWeapon == null)
                            FindeStartAst(yuzo);
                        break;
                    case "nein":
                        Console.WriteLine("Du gehst wieder vom Bett weg.");
                        Play(yuzo);
                        break;
                    default:
                        GameText.InvalidInput();
                        GoToStartBed(yuzo);
                        break;
                }
            }
            else
            {
                switch (Choice)
                {
                    case "ja":
                        Console.WriteLine("Du fühlst dich nach dem Schlaf erholt.");
                        Play(yuzo);
                        break;
                    case "nein":
                        Console.WriteLine("Du gehst wieder vom Bett weg.");
                        Play(yuzo);
                        break;
                    default:
                        GameText.InvalidInput();
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
                var Choice = Input.Run("Möchtest du den Ast mitnehmen? (Schreib: Ja/Nein)", Level1Choices, MenuChoices, YesNoChoices, yuzo);

                switch (Choice)
                {
                    case "ja":
                        yuzo.HasStick = true;
                        yuzo.YuzosWeapon = new Weapon { Name = "Ast", Durability = 20, Damage = 1 };
                        Console.WriteLine("Du hast den Ast mitgenommen.");
                        Console.WriteLine("Gebe Waffe ein, um deine Waffe anzuschauen.");
                        Play(yuzo);
                        break;
                    case "nein":
                        Console.WriteLine("Du lässt den Ast liegen.");
                        Play(yuzo);
                        break;
                    default:
                        GameText.InvalidInput();
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
                var Choice = Input.Run("Der Korb ist leer. Möchtest du den Korb mitnehmen? (Schreib: Ja/Nein)", Level1Choices, MenuChoices, YesNoChoices, yuzo);
                switch (Choice)
                {
                    case "ja":
                        yuzo.Inventory = new Item[5];
                        yuzo.HasBasket = true;
                        Console.WriteLine("Du nimmst den Korb mit.");
                        break;
                    case "nein":
                        Console.WriteLine("Du lässt den Korb stehen.");
                        break;
                    default:
                        GameText.InvalidInput();
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
                var Choice = Input.Run("Die Flasche ist mit Wasser gefüllt. Möchtest du die Flasche mitnehmen? (Schreib: Ja/Nein)", Level1Choices, MenuChoices, YesNoChoices, yuzo);

                if (yuzo.HasBasket)
                {
                    switch (Choice)
                    {
                        case "ja":
                            Item Flasche = new Item();
                            yuzo.HasBottle = true;
                            yuzo.Take(new Item { Name = "Flasche", Effect = "Füllt einen kleinen HP Anteil." });
                            Console.WriteLine("Du verstaust die Flasche in den Korb.");
                            break;
                        case "nein":
                            Console.WriteLine("Du lässt die Flasche stehen");
                            Play(yuzo);
                            break;
                        default:
                            GameText.InvalidInput();
                            GoToStartBasket(yuzo);
                            break;
                    }
                }
                else
                {
                    switch (Choice)
                    {
                        case "ja":
                            Console.WriteLine("Vielleicht kannst du die Flasche mitnehmen, wenn du sie verstauen kannst.");
                            break;
                        case "nein":
                            Console.WriteLine("Du lässt die Flasche liegen.");
                            break;
                        default:
                            GameText.InvalidInput();
                            GoToStartBottle(yuzo);
                            break;
                    }
                }
            }
            Play(yuzo);
        }
    }
}
