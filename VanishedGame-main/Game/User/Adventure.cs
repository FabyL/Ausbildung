using Game.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Adventure
    {
        public static List<string> MenuChoices = new List<string> { "reset", "quit", "waffe", "inventar", "hp", "xp" };
        public static List<string> YesNoChoices = new List<string> { "ja", "nein" };
        public static List<string> Level1Choices = new List<string> { "bett", "korb", "flasche", "trinken", "verlassen" };

        public static void StartGame()
        {
            LevelGeneration.GenerateLevel1();
        }
        public static void PlayLevel1(Yuzo yuzo, Cave cave)
        {
           var Choice = InputLevel1.Run("\nWas willst du tun ?: (Gebe Inventar, Bett, Korb, Flasche, Waffe oder HP ein, um damit zu interagieren.)", Level1Choices, MenuChoices, YesNoChoices, yuzo, cave);

            if(Choice != null)
            {
                switch (Choice)
                {
                    case "bett":
                        GoToBedLevel1(yuzo, cave);
                        break;
                    case "korb":
                        GoToBasketLevel1(yuzo, cave);
                        break;
                    case "flasche":
                        GoToBottleLevel1(yuzo, cave);
                        break;
                    case "trinken":
                        yuzo.UseBottle();
                        PlayLevel1(yuzo, cave);
                        break;
                    case "verlassen":
                        LeaveCave(yuzo, cave);
                        break;
                    default:
                        GameText.InvalidChoice();
                        PlayLevel1(yuzo, cave);
                        break;
                }
            }
        }
        public static void GoToBedLevel1(Yuzo yuzo, Cave cave)
        {
            var Choice = InputLevel1.Run("\nDu stehst vor dem Bett. Möchtest du ein schläfchen machen? (Schreib: Ja/Nein)", Level1Choices, MenuChoices, YesNoChoices, yuzo, cave);

            if (yuzo.YuzosWeapon == null)
            {
                switch (Choice)
                {
                    case "ja":
                        FindStickLevel1(yuzo, cave);
                        break;
                    case "nein":
                        Console.WriteLine("Du gehst wieder vom Bett weg.");
                        PlayLevel1(yuzo, cave);
                        break;
                    default:
                        GameText.InvalidInput();
                        GoToBedLevel1(yuzo, cave);
                        break;
                }
            }
            else
            {
                switch (Choice)
                {
                    case "ja":
                        Console.WriteLine("Du fühlst dich nach dem Schlaf erholt.");
                        PlayLevel1(yuzo, cave);
                        break;
                    case "nein":
                        Console.WriteLine("Du gehst wieder vom Bett weg.");
                        PlayLevel1(yuzo, cave);
                        break;
                    default:
                        GameText.InvalidInput();
                        GoToBedLevel1(yuzo, cave);
                        break;
                }
            }
        }
        public static void FindStickLevel1(Yuzo yuzo, Cave cave)
        {
            if (yuzo.YuzosWeapon == null)
            {
                Console.WriteLine("Zwischen den Laken findest du ein Ast.");
                var Choice = InputLevel1.Run("\nMöchtest du den Ast mitnehmen? (Schreib: Ja/Nein)", Level1Choices, MenuChoices, YesNoChoices, yuzo, cave);

                switch (Choice)
                {
                    case "ja":
                        yuzo.YuzosWeapon = cave.Stick;
                        cave.Stick = null;
                        Console.WriteLine("Du hast den Ast mitgenommen.");
                        Console.WriteLine("Gebe Waffe ein, um deine Waffe anzuschauen.");
                        PlayLevel1(yuzo, cave);
                        break;
                    case "nein":
                        Console.WriteLine("Du lässt den Ast liegen.");
                        PlayLevel1(yuzo, cave);
                        break;
                    default:
                        GameText.InvalidInput();
                        FindStickLevel1(yuzo, cave);
                        break;
                }
            }
            PlayLevel1(yuzo, cave);
        }
        public static void GoToBasketLevel1(Yuzo yuzo, Cave cave)
        {
            if (!cave.basketStanding)
            {
                Console.WriteLine("\nDu hast den Korb schon mitgenommen.");
            }
            else
            {
                var Choice = InputLevel1.Run("\nDer Korb ist leer. Möchtest du den Korb mitnehmen? (Schreib: Ja/Nein)", Level1Choices, MenuChoices, YesNoChoices, yuzo, cave);
                switch (Choice)
                {
                    case "ja":
                        cave.Basket = null;
                        yuzo.Inventory = new Item[5];
                        Console.WriteLine("Du nimmst den Korb mit.");
                        break;
                    case "nein":
                        Console.WriteLine("Du lässt den Korb stehen.");
                        break;
                    default:
                        GameText.InvalidInput();
                        GoToBasketLevel1(yuzo, cave);
                        break;
                }
            }
            PlayLevel1(yuzo, cave);
        }
        public static void GoToBottleLevel1(Yuzo yuzo, Cave cave)
        {
            if (!cave.bottleStanding)
            {
                Console.WriteLine("\nDu hast die Flasche schon mitgenommen.");
            }
            else
            {
                var Choice = InputLevel1.Run("\nDie Flasche ist mit Wasser gefüllt. Möchtest du die Flasche mitnehmen? (Schreib: Ja/Nein)", Level1Choices, MenuChoices, YesNoChoices, yuzo, cave);

                if (cave.bottleStanding && yuzo.Inventory != null)
                {
                    switch (Choice)
                    {
                        case "ja":
                            cave.Bottle = null;
                            yuzo.Take(new PumpkinBottle());
                            Console.WriteLine("Du verstaust die Flasche in den Korb. \n(Gebe Inventar ein um dir die Flasche anzusehen)");
                            break;
                        case "nein":
                            Console.WriteLine("Du lässt die Flasche stehen");
                            PlayLevel1(yuzo, cave);
                            break;
                        default:
                            GameText.InvalidInput();
                            GoToBasketLevel1(yuzo, cave);
                            break;
                    }
                }
                else
                {
                    switch (Choice)
                    {
                        case "ja":
                            Console.WriteLine("\nVielleicht kannst du die Flasche mitnehmen, wenn du sie verstauen kannst.");
                            break;
                        case "nein":
                            Console.WriteLine("Du lässt die Flasche liegen.");
                            break;
                        default:
                            GameText.InvalidInput();
                            GoToBottleLevel1(yuzo, cave);
                            break;
                    }
                }
            }
            PlayLevel1(yuzo, cave);
        }
        public static void LeaveCave(Yuzo yuzo, Cave cave)
        {
            if (yuzo.Inventory != null && yuzo.Inventory.Contains(cave.Bottle) && yuzo.YuzosWeapon != null)
            {
                Level2.IntroLevel2(yuzo);
            }
            else
            {
                Console.WriteLine("\nDu solltest dich noch umgucken, vielleicht hast du was vergessen was nützlich sein könnte.");
                PlayLevel1(yuzo, cave);
            }
        }
    }
}