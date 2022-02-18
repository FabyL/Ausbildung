using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Level2
    {
        public static void StartLevel2(Yuzo yuzo)
        {
            Console.WriteLine("\nDu wirst geblendet von dem Licht.");
            PlayLevel2(yuzo);
        }
        public static void PlayLevel2(Yuzo yuzo)
        {
            Console.WriteLine("Du wirst von einem betrunkenem Fremden entdeckt der auf dich zuläuft.\nEr versucht dich anzugreifen.");
            
            var drunkStranger = new DrunkStranger();
            drunkStranger.HealthPoints = 40;
            drunkStranger.DrunkStrangersWeapon = new Weapon { Name = "Fäuste", Damage = 5, Attack = "Schlägt Yuzo mit seinen Fäusten" };

            Battle.BattleStart(yuzo, drunkStranger);
        }
    }
}
