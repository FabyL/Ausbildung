﻿using Game;
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
        public static List<string> MenuChoices { get; } = new List<string> { "reset", "quit", "waffe"};

        public static void Run(string userInput, Yuzo yuzo)
        {
            switch(userInput)
            {
                case "reset":
                    Adventure.StartGame();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                case "waffe":
                    InspectWeapon(yuzo);
                    Adventure.Play(yuzo);
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
            if (yuzo.Inventory != null)
            {
                foreach (var item in yuzo.Inventory)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"Name: {item.Name}, Effekt: {item.Effect}");
                    }                        
                }
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
