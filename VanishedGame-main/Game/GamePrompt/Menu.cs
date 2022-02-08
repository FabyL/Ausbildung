﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Menu
    {
        public static void QuitGame(Yuzo yuzo)
        {
            Console.WriteLine("Möchtest du das Spiel beenden? (Ja/Nein)");
            var Choice = Console.ReadLine();

            switch (Choice)
            {
                case "Ja":
                    Console.WriteLine("Drücke eine beliebige Taste um das Spiel zu beenden.");
                    break;
                case "Nein":
                    Adventure.Play(yuzo);
                    break;
                default:
                    Console.WriteLine("Bitte wähle eine Möglichkeit aus.");
                    QuitGame(yuzo);
                    break;
            }
        }
        public static void OpenInventory(Yuzo yuzo)
        {
            if (yuzo.YuzosItem != null)
            {
                Console.WriteLine($"Name: {yuzo.YuzosItem.Name}, Effekt: {yuzo.YuzosItem.Effect}");
            }
            else
            {
                Console.WriteLine("Dein Inventar ist leer.");
            }
            Adventure.Play(yuzo);
        }
        public static void InspectWeapon(Yuzo yuzo)
        {
            if (yuzo.YuzosWeapon != null)
            {
                Console.WriteLine($"Name: {yuzo.YuzosWeapon.Name}, Schaden: {yuzo.YuzosWeapon.Damage}, Haltbarkeit: {yuzo.YuzosWeapon.Durability}");
            }
            else
            {
                Console.WriteLine("Du hast keine Waffe.");
            }
            Adventure.Play(yuzo);
        }
    }
}