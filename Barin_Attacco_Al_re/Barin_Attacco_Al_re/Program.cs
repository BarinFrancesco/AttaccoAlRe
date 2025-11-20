namespace Barin_Attacco_Al_re
{
    internal class Program
    {
        string path = @"\..\..\..\files\Game.txt";
        List<string> ListaMosse = new List<string>();
        List<CPersonaggio> ListaPersonaggi = new List<CPersonaggio>();

        public void Istanzia()
        {
            using(StreamReader sr = new StreamReader(path)) 
            {
                int linecount = 0;
                while (!sr.EndOfStream)
                {
                    
                    if(linecount == 0)
                    {

                        string valori = sr.ReadLine().Trim();
                        CRe re;
                        ListaPersonaggi.Add(re = new CRe(valori));

                    } else if (linecount == 1) 
                    {
                        CreazionePersonaggi(sr.ReadLine(), true);
                    } else if(linecount == 2)
                    {
                        CreazionePersonaggi(sr.ReadLine(), true);
                    } else
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

            foreach(string s in valori) 
            {
                if(caso)
                {
                    CGuardia guardia;
                    ListaPersonaggi.Add(guardia = new CGuardia(s));
                } else
                {
                    CPedone pedone;
                    ListaPersonaggi.Add(pedone = new CPedone(s));
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}