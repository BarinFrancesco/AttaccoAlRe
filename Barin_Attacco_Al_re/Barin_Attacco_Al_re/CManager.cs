using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    internal class CManager
    {
        event EventHandler<EventArgs> Attaccato;

        List<CPersonaggio> persone;
        public CManager(List<CPersonaggio> listpeople) 
        {
        persone = listpeople;
        }

        private void Abbona()
        {
            foreach (var person in persone)
            {
                
            }
        }
    }
}
