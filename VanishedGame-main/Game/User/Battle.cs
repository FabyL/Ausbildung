using Game.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Battle
    {
        public static void BattleStart(Yuzo yuzo, DrunkStranger drunkStranger)
        {
            Console.WriteLine("Kampf beginnt");
            
            while (!yuzo.Dead && !drunkStranger.Dead)
            {
                BattleRound(yuzo, drunkStranger);
            }
            BattleEnd(yuzo, drunkStranger);
        }
        public static void BattleRound(Yuzo yuzo, DrunkStranger drunkStranger)
        {
            var yuzoAttack = drunkStranger.HealthPoints - yuzo.YuzosWeapon.Damage;
            drunkStranger.HealthPoints = yuzoAttack;
            Console.WriteLine($"{yuzo.Name} benutzt {yuzo.YuzosWeapon.Name} und {yuzo.YuzosWeapon.Attack}");
            Console.WriteLine($"Der Fremde hat noch: {drunkStranger.HealthPoints}HP");

            if (!drunkStranger.Dead)
            {
                var drunkStrangerAttack = yuzo.HealthPoints - drunkStranger.DrunkStrangersWeapon.Damage;
                yuzo.HealthPoints = drunkStrangerAttack;
                Console.WriteLine($"Der Fremde benutzt {drunkStranger.DrunkStrangersWeapon.Name} und {drunkStranger.DrunkStrangersWeapon.Attack}");
                Console.WriteLine($"{yuzo.Name} hat noch : {yuzo.HealthPoints}HP");
            }
        }
        public static void BattleEnd(Yuzo yuzo, DrunkStranger drunkStranger)
        {
            if (yuzo.Dead)
            {
                Console.WriteLine("Du wurdest von dem Fremden besiegt.");
            }
            else if (drunkStranger.Dead)
            {
                Console.WriteLine("Du hast den Fremden besiegt.");
            }
        }
    }
}
