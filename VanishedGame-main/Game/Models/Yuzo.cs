using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Yuzo : Character
    {
        public string Name = "Yuzo";
        public int MaxHealthPoints = 70;
        public int HealthPoints;
        public bool HasBasket;
        public bool HasBottle;
        public bool HasStick;
        public Weapon YuzosWeapon;
        public Item YuzosItem;
        public Item[] Inventory;
        public bool Dead
        {
            get
            {
                return HealthPoints <= 0;
            }
        }

        public bool Take(Item item)
        {
            bool itemStored = false;
            if(Inventory != null)
            {
                for (int i = 0; i < Inventory.Length; i++)
                {
                    if(Inventory[i] == null && !itemStored)
                    {
                        Inventory[i] = item;
                        itemStored = true;
                    }
                }
            }
            return itemStored;
        }
        public bool UseBottle()
        {
            bool hasUsedBottle = false;
            var bottle = GetBottleFromInventory();
            if(bottle != null)
            {
                bottle.DrinkWater(this);
                hasUsedBottle = true;
            }
            return hasUsedBottle;
        }

        private PumpkinBottle GetBottleFromInventory()
        {
            PumpkinBottle returnbottle = null;

            if (Inventory != null)
            {             
                foreach (var item in Inventory)
                {
                    if (item is PumpkinBottle)
                    {
                        returnbottle = (PumpkinBottle)item;
                    }
                }
            }         
            return returnbottle;
        }
    }
}