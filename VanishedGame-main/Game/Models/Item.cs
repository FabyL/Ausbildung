using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Item
    {
        public string Name { get; set; }
        public abstract string EffectDescription { get; set; }
    }
}
