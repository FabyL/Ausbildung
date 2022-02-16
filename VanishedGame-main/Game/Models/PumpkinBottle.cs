using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PumpkinBottle : Item
    {
        public int Healing;
        public PumpkinBottle()
        {
            Name = "Kürbisflasche";
            EffectDescription = "Füllt einen kleinen HP Anteil. (10 HP)";
            Healing = 10;
        }
        public void DrinkWater(Yuzo yuzo)
        {
            if (yuzo.HealthPoints < yuzo.MaxHealthPoints)
            {
                int HealedHP = yuzo.HealthPoints + Healing;
                yuzo.HealthPoints = HealedHP;

                Console.WriteLine("Du trinkst etwas und heilst dich. Du hast jetzt {0} HP.", HealedHP);
            }
            else if (yuzo.HealthPoints == yuzo.MaxHealthPoints)
            {
                Console.WriteLine("Du hast bereits volles Leben.");
            }
            else
            {
                Console.WriteLine("Du hast nichts aus dem du trinken kannst.");
            }
        }
    }
}
