using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    internal class CGuardia : CPersonaggio, IAttaccabile
    {
        public event EventHandler<string> Attaccato;
        public CGuardia(string name) : base(name) { }

        public void ReAttaccato()
        {
            string message = $"La guardai {Nome} sta difendendo";
            OnAttaccato(this, message);
        }

        public virtual void OnAttaccato(object sender, string message)
        {
            Attaccato?.Invoke(sender, message);
        }
    }
}
