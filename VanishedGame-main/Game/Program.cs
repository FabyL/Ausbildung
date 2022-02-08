using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            var yuzo = new Yuzo();
            //   Introduction(yuzo);

            Introduction.Show(yuzo);
            Play(yuzo);
        }

        public static void Play(Yuzo yuzo)
        {
            Console.WriteLine("Was willst du tun?: (Gebe Inventar, Bett, Korb, Flasche oder Waffe ein, um dahin zu gehen.)");

            var Auswahl = Console.ReadLine();

            switch(Auswahl)
            {
                case "Quit":
                    SpielBeenden(yuzo);
                    break;
                case "Inventar":
                    OpenInventory(yuzo);
                    break;
                case "Bett":
                    GeheZumStartBett(yuzo);
                    break;
                case "Korb":
                    GeheZumStartKorb(yuzo);
                    break;
                case "Flasche":
                    GeheZurStartFlasche(yuzo);
                    break;
                case "Waffe":
                    InspiziereWaffe(yuzo);
                    Play(yuzo);
                    break;
                default:
                    Console.WriteLine("Bitte gebe nur die bereits genannten Commands ein.");
                    Play(yuzo);
                    break;
            }
        }      
      
        public static void SpielBeenden(Yuzo yuzo)
        {
            Console.WriteLine("Möchtest du das Spiel beenden? (Ja/Nein)");
            var Auswahl = Console.ReadLine();
            
            switch(Auswahl)
            {
                case "Ja":
                    Console.WriteLine("Drücke eine beliebige Taste um das Spiel zu beenden.");
                 //   return;
                    break;
                case "Nein":
                    Play(yuzo);
                    break;
                default:
                    Console.WriteLine("Bitte wähle eine Möglichkeit aus.");
                    SpielBeenden(yuzo);
                    break;
            }
        }
        public static void GeheZumStartBett(Yuzo yuzo)
        {
            Console.WriteLine("Du stehst vor dem Bett. Möchtest du ein schläfchen machen? (Schreib: Ja/Nein)");
            var Auswahl = Console.ReadLine();

            if (yuzo.hatAst == false)
            {
                switch (Auswahl)
                {
                    case "Ja":
                        if (yuzo.YuzosWaffe == null)
                            FindeStartAst(yuzo);
                        break;
                    case "Nein":
                        Console.WriteLine("Du gehst wieder vom Bett weg.");
                        Play(yuzo);
                        break;
                    default:
                        Console.WriteLine("Bitte versuche es erneut.");
                        GeheZumStartBett(yuzo);
                        break;
                }
            }
            else
            {
                switch (Auswahl)
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
                        Console.WriteLine("Bitte versuche es erneut.");
                        GeheZumStartBett(yuzo);
                        break;
                }
            }
        }
        public static void FindeStartAst(Yuzo yuzo)
        {
            

            if (yuzo.YuzosWaffe == null)
            {
                Console.WriteLine("Zwischen den Laken findest du ein Ast.");
                Console.WriteLine("Möchtest du den Ast mitnehmen? (Schreib: Ja/Nein)");
                var Auswahl = Console.ReadLine();

                switch (Auswahl)
                {
                    case "Ja":
                        yuzo.hatAst = true;
                        yuzo.YuzosWaffe = new Weapon { Name = "Ast", Haltbarkeit = 20, Schaden = 1 };
                        Console.WriteLine("Du hast den Ast mitgenommen.");
                        Console.WriteLine("Gebe Waffe ein, um deine Waffe anzuschauen.");
                        Play(yuzo);
                        break;
                    case "Nein":
                        Console.WriteLine("Du lässt den Ast liegen.");
                        Play(yuzo);
                        break;
                    default:
                        Console.WriteLine("Bitte versuche es erneut.");
                        FindeStartAst(yuzo);
                        break;
                }
            }
            Play(yuzo);
        }
        public static void GeheZumStartKorb(Yuzo yuzo)
        {
            if (yuzo.hatKorb)
            {
                Console.WriteLine("Du hast den Korb schon mitgenommen.");
            }
            else
            {
                Console.WriteLine("Der Korb ist gefüllt mit Nahrung. Möchtest du den Korb mitnehmen? (Schreib: Ja/Nein)");
                var Auswahl = Console.ReadLine();
                switch (Auswahl)
                {
                    case "Ja":
                        Item Korb = new Item();
                        yuzo.hatKorb = true;
                        yuzo.YuzosItem = new Item { Name = "Korb", Effekt = "Kann Sachen mitnehmen" };
                        Console.WriteLine("Du nimmst den Korb mit.");
                        break;
                    case "Nein":
                        Console.WriteLine("Du lässt den Korb stehen.");
                        break;
                    default:
                        Console.WriteLine("Bitte versuche es erneut.");
                        GeheZumStartKorb(yuzo);
                        break;
                }
            }
            Play(yuzo);
        }
        public static void GeheZurStartFlasche(Yuzo yuzo)
        {
            if (yuzo.hatFlasche)
            {
                Console.WriteLine("Du hast die Flasche schon mitgenommen.");
            }
            else
            { 
            Console.WriteLine("Die Flasche ist mit Wasser gefüllt. Möchtest du die Flasche mitnehmen? (Schreib: Ja/Nein)");
            var Auswahl = Console.ReadLine();

            if(yuzo.hatKorb)
                {
                    switch (Auswahl)
                    {
                        case "Ja":
                            Item Flasche = new Item();
                            
                            yuzo.hatFlasche = true;
                            yuzo.YuzosItem = new Item { Name = "Flasche", Effekt = "Füllt einen kleinen HP Anteil." };
                            Console.WriteLine("Du verstaust die Flasche in den Korb.");
                            break;
                        case "Nein":
                            Console.WriteLine("Du lässt die Flasche stehen");
                            Play(yuzo);
                            break;
                        default:
                            Console.WriteLine("Bitte versuche es erneut.");
                            GeheZumStartKorb(yuzo);
                            break;
                    }
                }
                else
                {
                    switch(Auswahl)
                    {
                        case "Ja":
                            Console.WriteLine("Vielleicht kannst du die Flasche mitnehmen, wenn du sie verstauen kannst.");
                            break;
                        case "Nein":
                            Console.WriteLine("Du lässt die Flasche liegen.");
                            break;
                        default:
                            Console.WriteLine("Bitte versuche es erneut.");
                            GeheZurStartFlasche(yuzo);
                            break;
                    }
                }              
            }
            Play(yuzo);
        }
        public static void OpenInventory(Yuzo yuzo)
        {
            if (yuzo.YuzosItem != null)
            {
                Console.WriteLine($"Name: {yuzo.YuzosItem.Name}, Effekt: {yuzo.YuzosItem.Effekt}");
            }
            else
            {
                Console.WriteLine("Dein Inventar ist leer.");
            }
            Play(yuzo);
        }
        public static void InspiziereWaffe(Yuzo yuzo)
        {
            if (yuzo.YuzosWaffe != null)
            {
                Console.WriteLine($"Name: {yuzo.YuzosWaffe.Name}, Schaden: {yuzo.YuzosWaffe.Schaden}, Haltbarkeit: {yuzo.YuzosWaffe.Haltbarkeit}");
            }
            else
            {
                Console.WriteLine("Du hast keine Waffe.");
            }
            Play(yuzo);
        }
        public static void AddItem(Yuzo yuzo)
        {

        }
    }
}