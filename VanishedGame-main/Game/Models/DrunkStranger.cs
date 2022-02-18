using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DrunkStranger : Character // Waffen klasse hinzufügen
    {
        public string Name;
        public int MaxHealthPoints;
        public int HealthPoints;
        public Weapon DrunkStrangersWeapon;
        public bool Dead
        {
            get
            {
                return HealthPoints <= 0;
            }
        }
        public DrunkStranger()    
        {
            Name = "Drunk Stranger";
            MaxHealthPoints = 40;
            HealthPoints = 40;
        }
    }
}
