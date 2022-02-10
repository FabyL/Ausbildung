using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Yuzo
    {
        public string Name = "Yuzo";
        public int HealthPoints;
        public bool HasBasket;
        public bool HasBottle;
        public bool HasStick;
        public Weapon YuzosWeapon;
        public Item YuzosItem;
        public Item[] Inventory;

        public bool Take(Item item)
        {
            bool itemStored = false;
            if(Inventory != null)
            {
                for (int i = 0; i < Inventory.Length; i++)
                {
                    if(Inventory[i] == null)
                    {
                        Inventory[i] = item;
                        itemStored = true;
                    }
                }
            }
            return itemStored;
        }
    }
}