using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    internal class CGuardia : CPersonaggio, IAttaccabile
    {
        public CGuardia(string name) : base(name) { }

        public string ReAttaccato()
        {
            return $"La guardia {Nome} sta difendendo";
        }
    }
}
