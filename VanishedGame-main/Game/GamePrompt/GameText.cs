﻿using System;
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
            Console.WriteLine("Du befindest dich in einer Höhle und dein schädel brummt.\nDu kannst dich an nichts mehr erinnern und siehst dich um.\nDu siehst: Ein improvisiertes Bett, einen gefüllten Tragekorb und eine Kürbisflasche.\nWenn du bereit bist kannst du die Höhle verlassen. (Gebe dafür verlassen ein)\nWenn du das Spiel beenden möchtest, schreibe: Quit");
            //Console.WriteLine("Du kannst dich an nichts mehr erinnern und siehst dich um.");
            //Console.WriteLine("Du siehst: Ein improvisiertes Bett, einen gefüllten Tragekorb und eine Kürbisflasche.");
            //Console.WriteLine("Wenn du bereit bist kannst du die Höhle verlassen. (Gebe dafür verlassen ein)");
            //Console.WriteLine("Wenn du das Spiel beenden möchtest, schreibe: Quit");
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
