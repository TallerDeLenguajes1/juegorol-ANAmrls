using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            CreadorDePje creadorDePje = new CreadorDePje();
            Personaje player1 = creadorDePje.CrearPjeAleatorio();
            Console.WriteLine("Hello World!");
        }
    }
}
