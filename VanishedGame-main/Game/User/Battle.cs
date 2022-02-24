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
            Random rnd = new Random();
            var yuzoAttack = drunkStranger.HealthPoints - rnd.Next(0, yuzo.YuzosWeapon.Damage);
            drunkStranger.HealthPoints = yuzoAttack;
            Console.WriteLine($"{yuzo.Name} benutzt {yuzo.YuzosWeapon.Name} und {yuzo.YuzosWeapon.Attack}");
            Console.WriteLine($"Der Fremde hat noch: {drunkStranger.HealthPoints}HP");

            if (!drunkStranger.Dead)
            {
                var drunkStrangerAttack = yuzo.HealthPoints - rnd.Next(0, drunkStranger.DrunkStrangersWeapon.Damage);
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
                Adventure.StartGame();
            }
            else if (drunkStranger.Dead)
            {
                Console.WriteLine("Du hast den Fremden besiegt und erhälst 22 XP.");
                int xpGain = 22;
                var addXP = yuzo.ExperiencePoints + xpGain;
                yuzo.ExperiencePoints = addXP;
                yuzo.LevelUp1Yuzo(yuzo);
                Console.WriteLine("Du bist jetzt Level 2. Gebe XP ein um deine Erfahrungspunkte und dein Level zu sehen.");
            }
        }
    }
}