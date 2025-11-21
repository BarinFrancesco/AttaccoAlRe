using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    internal class CRe : CPersonaggio
    {
        public CRe(string name) : base(name) { }


        public string ReAttaccato()
        {
            return  $"Il re {Nome} è sotto attacco";
        }

    }
}
