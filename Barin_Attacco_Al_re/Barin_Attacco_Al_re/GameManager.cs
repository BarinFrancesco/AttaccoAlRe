using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin_Attacco_Al_re
{
    class GameManager
    {
        public event EventHandler<string> ReAttaccato;
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


        public void Esegui()
        {
            foreach (var item in ListaMosse)
            {
                string[] membri = item.Split(' ');

                if (membri[0].ToLower() == "attacca")
                {
                    ReAttaccato?.Invoke(this, "");
                    
                } else if (membri[0].ToLower() == "cattura")
                {
                    for(int i =0; i< ListaPersonaggi.Count; i++)
                    {
                        if (ListaPersonaggi[i].Nome == membri[1].Trim())
                        {
                            //Vado a selexzionare l'evento del personaggio, poi lo disiscrivo e successivamente elimino il personaggio
                            if (Program.ListaEventi.ContainsKey(ListaPersonaggi[i]))
                            {
                                ReAttaccato -= Program.ListaEventi[ListaPersonaggi[i]];
                                Program.ListaEventi.Remove(ListaPersonaggi[i]);
                            }
                            ListaPersonaggi.RemoveAt(i);
                            i--;
                        }
                    }

                }
            }
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
