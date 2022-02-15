using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameText
    {
        public static void Introduction(Yuzo yuzo)
        {
            Console.WriteLine("Du befindest dich in einer Höhle und dein schädel brummt.");
            Console.WriteLine("Du kannst dich an nichts mehr erinnern und siehst dich um.");
            Console.WriteLine("Du siehst: Ein improvisiertes Bett, einen gefüllten Tragekorb und eine Kürbisflasche.");
            Console.WriteLine("Wenn du das Spiel beenden möchtest, schreibe: Quit");
        }
        public static void InvalidChoice()
        {
            Console.WriteLine("Bitte gebe nur die bereits genannten Commands ein.");
        }
        public static void InvalidInput()
        {
            Console.WriteLine("Bitte versuche es erneut.");
        }
    }
}
