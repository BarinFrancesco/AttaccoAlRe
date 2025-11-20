using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    class GameManager
    {
        event EventHandler<string> ReAttaccato;
        public string _path { get; private set; }
        public List<string> ListaMosse { get; private set; }
        public List<CPersonaggio> ListaPersonaggi { get; private set; }

        public GameManager(string path)
        {
            _path = path;
            ListaMosse = new List<string>();
            ListaPersonaggi = new List<CPersonaggio>();
            Istanzia();
        }

        public void Gioca()
        {

        }

        protected virtual void OnReAttaccato(object sender, string message)
        {
            
        }

        public void Istanzia()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                int linecount = 0;
                while (!sr.EndOfStream)
                {

                    if (linecount == 0)
                    {

                        string valori = sr.ReadLine().Trim();
                        CRe re;
                        ListaPersonaggi.Add(re = new CRe(valori));

                    }
                    else if (linecount == 1)
                    {
                        CreazionePersonaggi(sr.ReadLine(), true);
                    }
                    else if (linecount == 2)
                    {
                        CreazionePersonaggi(sr.ReadLine(), false);
                    }
                    else
                    {
                        ListaMosse.Add(sr.ReadLine());
                    }
                    linecount++;
                }

            }
        }

        public void CreazionePersonaggi(string testo, bool caso)
        {
            string[] valori = testo.Split(' ');

            foreach (string s in valori)
            {
                if (caso)
                {
                    CGuardia guardia;
                    ListaPersonaggi.Add(guardia = new CGuardia(s));
                }
                else
                {
                    CPedone pedone;
                    ListaPersonaggi.Add(pedone = new CPedone(s));
                }
            }
        }
    }
}
