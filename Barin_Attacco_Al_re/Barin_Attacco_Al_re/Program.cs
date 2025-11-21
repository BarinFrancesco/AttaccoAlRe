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
                    selectedElement=i;
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
                selectedElement++;
            }
        }

        public static void OnReAttaccato(object sender, string s)
        {
            Console.WriteLine(selectedElement);
            if(Gioco.ListaPersonaggi[selectedElement] is CRe re)
            {
                Console.WriteLine(re.ReAttaccato());
                OutputFinale += "\nIl re è stato attaccato";
            }
            if (Gioco.ListaPersonaggi[selectedElement] is CGuardia guardia)
            {
                Console.WriteLine(guardia.ReAttaccato());
            } else if(Gioco.ListaPersonaggi[selectedElement] is CPedone pedone)
            {
                Console.WriteLine(pedone.ReAttaccato());
            }
                
        }
        

    }
}

/*
        public static void OnRe_ReAttaccato(object sender, string s)
        {
            Console.WriteLine("Il re è stato attaccato");
            OutputFinale += "\nIl re è stato attaccato";
        }
        public static void OnGuardia_ReAttaccato(object sender, string s)
        {
            if(Gioco.ListaPersonaggi[selectedElement] is CGuardia guardia)
            Console.WriteLine(guardia.ReAttaccato());
        }
        public static void OnPedone_ReAttaccato(object sender, string s)
        {
            if (Gioco.ListaPersonaggi[selectedElement] is CPedone pedone)
                Console.WriteLine(pedone.ReAttaccato());
        }*/

/*
(s, e) =>
{
    Console.WriteLine(Re.ReAttaccato());
};*/