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

            GameText.Introduction(yuzo);
            Adventure.Play(yuzo);
        }
    }
}