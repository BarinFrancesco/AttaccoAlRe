using System.Security.Cryptography.X509Certificates;

namespace Barin_Attacco_Al_re
{
    internal class Program
    {
        static GameManager Gioco;
        static string OutputFinale;
        static int selectedElement;
        static void Main(string[] args)
        {

            string path = "Game.txt";
            selectedElement = 0;
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
            for(int i =0; i< Gioco.ListaPersonaggi.Count; i++)
            {
                if (Gioco.ListaPersonaggi[i] is CRe Re)
                {
                    Gioco.ReAttaccato += OnReAttaccato;
                }
                else if (Gioco.ListaPersonaggi[i] is CGuardia Guardia)
                {
                    Gioco.ReAttaccato += OnReAttaccato;
                }
                else if (Gioco.ListaPersonaggi[i] is CPedone Pedone)
                {
                    Gioco.ReAttaccato += OnReAttaccato;
                }

            }
        }

        public static void OnReAttaccato(object sender, string s)
        {
            if (Gioco.ListaPersonaggi[selectedElement] is CRe re)
            {
                Console.WriteLine(re.ReAttaccato());
                OutputFinale += $"\n{re.ReAttaccato()}";
            }
            if (Gioco.ListaPersonaggi[selectedElement] is CGuardia guardia)
            {
                Console.WriteLine(guardia.ReAttaccato());
            } else if(Gioco.ListaPersonaggi[selectedElement] is CPedone pedone)
            {
                Console.WriteLine(pedone.ReAttaccato());
            }
            selectedElement = selectedElement < Gioco.ListaPersonaggi.Count - 1 ? selectedElement + 1: 0; 
        }
        

    }
}