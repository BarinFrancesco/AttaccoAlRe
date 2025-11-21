using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    internal class CPersonaggio
    {
        
        private string _nome;

        public string Nome 
        { 
            get { return _nome; } 
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nome = value.Trim();
                } else
                {
                    throw new Exception("Cokpilare il campo del nome");
                }
                 
            }
        }


        public CPersonaggio(string name) 
        {
            Nome = name;
        }
    }
}
