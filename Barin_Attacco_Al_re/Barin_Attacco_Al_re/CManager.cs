using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    internal class CManager
    {
        event EventHandler<string> Attaccato;

        List<CPersonaggio> persone;
        public CManager(List<CPersonaggio> listpeople) 
        {
        persone = listpeople;
            Abbona();
        }

        private void Abbona()
        {
            foreach (var person in persone)
            {
                if (person is CRe re)
                {
                    Attaccato += re.OnAttaccato;
                }
                else if (person is CPedone pedone)
                    Attaccato += pedone.OnAttaccato;
                else if (person is CGuardia guardia)
                    Attaccato += guardia.OnAttaccato;    
            }
        }
    }
}
