using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Level2Functions
    {
        public static void Run(string userInput, Yuzo yuzo, Cave cave)
        {
            switch (userInput)
            {
                case "fremder":
                    GoToStrangerLevel2(yuzo);
                    break;
            }
        }
        public static void GoToStrangerLevel2(Yuzo yuzo)
        {
            Console.WriteLine("Du siehst dir den Fremden an. Er hat irgendwas merkwürdiges an sich, du kannst jedoch nicht sagen warum.\nDu entdeckst einen kleinen Goldsack, eine Tasche und einen kleinen Zettel in seiner Hintertasche.\n(Gebe Goldsack, Tasche oder Zettel an, um damit zu interagieren)");
            
        }
        public static void GoToInscriptionLevel2(Yuzo yuzo, Note note)
        {
            Console.WriteLine("Du schaust auf den Höhlenausgang und siehst etwas dort stehen. GAENINIFHR steht dort.");
            if (yuzo.Inventory.Contains(note))
            {
                Console.WriteLine("Vielleicht hilft dir etwas den Text du entziffern.");
            }
            else
            {
                Console.WriteLine("Sieht aus wie eine Art von Zauber oder Fluch die den Text unlesbar macht.");
            }
        }
        public static void GoToPond(Yuzo yuzo)
        {
            Console.WriteLine("Du bist an einem klaren, warmen Teich und siehst ein paar Koifische drin schwimmen. Du könntest ein Bad nehmen und sogar deine Flasche wieder bei Bedarf auffüllen. (Gebe dafür Baden oder Auffüllen ein)");
        }
    }
}