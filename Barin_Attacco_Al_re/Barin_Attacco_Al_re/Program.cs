using System.Security.Cryptography.X509Certificates;

namespace Barin_Attacco_Al_re
{
    internal class Program
    {
        static GameManager Gioco;
        static string OutputFinale;
        public static Dictionary<CPersonaggio, EventHandler<string>> ListaEventi = new Dictionary<CPersonaggio, EventHandler<string>>();


        static void Main(string[] args)
        {

            string path = "Game.txt";
            Gioco = new GameManager(path);
            Iscrivi(Gioco);

            Gioco.Esegui();

            using (StreamWriter sw = new StreamWriter("output.txt", append: true))
            {
                sw.WriteLine(OutputFinale);
            }

        }


        public static void Iscrivi( GameManager Gioco)
        {
            foreach (var p in Gioco.ListaPersonaggi)
            {
                EventHandler<string> handler = (sender, s) =>
                {
                    OnReAttaccato(sender, s, p);
                };

                Gioco.ReAttaccato += handler;
                ListaEventi[p] = handler;
            }
        }

        public static void OnReAttaccato(object sender, string s, CPersonaggio personaggio)
        {
            if (personaggio is CRe re)
            {
                Console.WriteLine(re.ReAttaccato());
                OutputFinale += $"\n{re.ReAttaccato()}";
            }
            else if (personaggio is CGuardia guardia)
            {
                Console.WriteLine(guardia.ReAttaccato());
            }
            else if (personaggio is CPedone pedone)
            {
                Console.WriteLine(pedone.ReAttaccato());
            }
        }
        

    }
}