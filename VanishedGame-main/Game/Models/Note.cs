using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Note : Item
    {
        private string _EffectDescription;

        public override string EffectDescription
        {
            get { return this._EffectDescription + $" "; }
            set { _EffectDescription = value; }
        }
        public Note()
        {
            Name = "Zettel";
        }
    }
}
