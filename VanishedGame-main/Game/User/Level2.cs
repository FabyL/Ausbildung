using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Level2
    {
        public static List<string> Level2Choices = new List<string> { "fremder", "inschrift", "teich" };
        public static List<string> MenuChoices = new List<string> { "reset", "quit", "waffe", "inventar", "hp", "xp" };
        public static List<string> YesNoChoices = new List<string> { "ja", "nein" };
        public static void IntroLevel2(Yuzo yuzo)
        {
            Console.WriteLine("\nDu wirst geblendet von dem Licht.");
            BattleLevel2(yuzo);
        }
        public static void BattleLevel2(Yuzo yuzo)
        {
            Console.WriteLine("Du wirst von einem betrunkenem Fremden entdeckt der auf dich zuläuft.\nEr versucht dich anzugreifen.");

            DrunkStranger drunkStranger = new DrunkStranger();
            drunkStranger.HealthPoints = 40;
            drunkStranger.DrunkStrangersWeapon = new Weapon { Name = "Fäuste", Damage = 5, Attack = "Schlägt Yuzo mit seinen Fäusten" };

            Battle.BattleStart(yuzo, drunkStranger);
            StartLevel2(yuzo);
        }
        public static void StartLevel2(Yuzo yuzo)
        {
            GameText.IntroductionLevel2(yuzo);
        }
        public static void PlayLevel2(Yuzo yuzo, Cave cave)
        {
            InputLevel2.Run("Was möchtest du tun?", Level2Choices, MenuChoices, YesNoChoices, yuzo, cave);
        }
        public static void GoToStrangerLevel2(Yuzo yuzo)
        {
            Console.WriteLine("Du siehst dir den Fremden an. Er hat irgendwas merkwürdiges an sich, du kannst jedoch nicht sagen warum.\nDu entdeckst einen kleinen Goldsack, eine Tasche und einen kleinen Zettel in seiner Hintertasche.\n(Gebe Goldsack, Tasche oder Zettel an, um damit zu interagieren)");
        }
        public static void GoToInscriptionLevel2(Yuzo yuzo)
        {
            Console.WriteLine("Du schaust auf den Höhlenausgang und siehst etwas dort stehen. GAENINIFHR steht dort.");
        }
        public static void GoToPond(Yuzo yuzo)
        {
            Console.WriteLine("Du bist an einem klaren, warmen Teich und siehst ein paar Koifische drin schwimmen. Du könntest ein Bad nehmen und sogar deine Flasche wieder bei Bedarf auffüllen. (Gebe dafür Baden oder Auffüllen ein)");
        }
    }
}
