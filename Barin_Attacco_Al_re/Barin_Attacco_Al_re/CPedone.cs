using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    internal class CPedone : CPersonaggio, IAttaccabile
    {
        public CPedone(string nome) : base(nome) { }

        public void ReAttaccato()
        {
            string message = $"Il pedone {Nome} si sta preparando";
            OnAttaccato(this, message);
        }

        public virtual void OnAttaccato(object sender, string message)
        {
            
        }
    }
}
