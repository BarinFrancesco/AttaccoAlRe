using System.Security.Cryptography.X509Certificates;

namespace Barin_Attacco_Al_re
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string path = "Game.txt";

            GameManager Gioco = new GameManager(path);
            Iscrivi(Gioco);
            
        }


        public static void Iscrivi( GameManager Gioco)
        {

            foreach(var persona in Gioco.ListaPersonaggi)
            {


                if(persona is CRe Re) 
                {
                    Gioco.ReAttaccato += (s, e) =>
                    {
                        Console.WriteLine(Re.ReAttaccato());
                    };
                } else if(persona is CGuardia Guardia) 
                {
                    Gioco.ReAttaccato += (s, e) =>
                    {
                        Console.WriteLine(Guardia.ReAttaccato());
                    };
                } else if( persona is CPedone Pedone)
                {
                    Gioco.ReAttaccato += (s, e) =>
                    {
                        Console.WriteLine(Pedone.ReAttaccato());
                    };
                }


            }
        }


    }
}

/*
 * foreach(string elemento in gioco.ListaMosse)
            {
                Console.WriteLine(elemento);
            }

            foreach(var persona in gioco.ListaPersonaggi)
            {
                if(persona is CRe re)
                {
                    Console.WriteLine($"Il re {re.Nome}");
                } else if (persona is CGuardia guardia)
                {
                    Console.WriteLine($"La guardia {guardia.Nome}");
                } else if (persona is CPedone pedone)
                {
                    Console.WriteLine($"Il pedone {pedone.Nome}");
                }
            }
*/