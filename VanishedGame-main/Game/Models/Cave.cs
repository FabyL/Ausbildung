using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Cave
    {
        public Item[] Basket { get; set; }
        public Item Bottle { get; set; }
        public Weapon Stick { get; set; }
        public bool basketStanding
        {
            get
            {
                return Basket != null;
            }
        }
        public bool bottleStanding
        {
            get
            {
                return Bottle != null;
            }
        }
        public Cave()
        {
            
        }
    }
}