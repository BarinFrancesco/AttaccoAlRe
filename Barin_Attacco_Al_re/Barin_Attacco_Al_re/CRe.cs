using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    internal class CRe : CPersonaggio
    {
        public event EventHandler<string> Attaccato;
        public CRe(string name) : base(name) { }


        public void ReAttaccato()
        {
            string message = $"Il re {Nome} è sotto attacco";
            OnAttaccato(this, message);
        }

        public virtual void OnAttaccato(object sender, string message)
        {
            Attaccato?.Invoke(sender, message);
        }

    }
}
