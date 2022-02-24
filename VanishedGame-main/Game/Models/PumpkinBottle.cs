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
        public int MaxUses;
        public int Uses;
        private string _EffectDescription;

        public override string EffectDescription
        {
            get { return this._EffectDescription + $" Benutzbar: {Uses}/{MaxUses}"; }
            set { _EffectDescription = value; }
        }
        public PumpkinBottle()
        {
            Name = "Kürbisflasche";
            _EffectDescription = "Füllt einen kleinen HP Anteil. (10 HP)";
            Healing = 10;
            MaxUses = 4;
            Uses = 4;
        }
        public void DrinkWater(Yuzo yuzo)
        {
            if (Uses > 0)
            {
                if (yuzo.HealthPoints < yuzo.MaxHealthPoints)
                {
                    int HealedHP = yuzo.HealthPoints + Healing;
                    yuzo.HealthPoints = HealedHP;
                    Uses--;

                    Console.WriteLine("Du trinkst etwas und heilst dich. Du hast jetzt {0} HP.", HealedHP);
                    Console.WriteLine("Du kannst deine Flasch noch {0} mal benutzen.", Uses);
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
            else
            {
                Console.WriteLine("Die Flasche ist leer.");
            }          
        }
    }
}
