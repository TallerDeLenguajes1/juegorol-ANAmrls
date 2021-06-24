using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Gameplay
    {
        readonly Random random = new Random();

        public void Combate(List<Personaje> personajes, int player1, int player2)
        {
            int nroDeAtaques = 0;

            Console.WriteLine("\n////////////////////////////////////////////////////");
            Console.WriteLine($"\n{personajes[player1].Nombre} vs {personajes[player2].Nombre}");
            Console.WriteLine("\nReady... GO!\n");

            while (nroDeAtaques < 3 && personajes[player1].Salud > 0 && personajes[player2].Salud > 0)
            {
                personajes[player1].Atacar(personajes[player2]);

                Console.WriteLine($"\nSalud {personajes[player2].Nombre}: {personajes[player2].Salud}");

                if (personajes[player2].Salud > 0)
                {
                    personajes[player2].Atacar(personajes[player1]);
                    Console.WriteLine($"\nSalud {personajes[player1].Nombre}: {personajes[player1].Salud}");
                }

                nroDeAtaques++;
            }

            if(personajes[player1].Salud > personajes[player2].Salud)
            {
                personajes[player1].SubirDeNivel();
                Console.WriteLine("\nGanador: ");
                personajes[player1].MostrarPje();
                personajes.RemoveAt(player2);                
            }
            else if (personajes[player2].Salud > personajes[player1].Salud)
            {
                personajes[player2].SubirDeNivel();
                Console.WriteLine("\nGanador: ");
                personajes[player2].MostrarPje();
                personajes.RemoveAt(player1);                
            }
            else
            {
                Console.WriteLine("\nEmpate");
                personajes[player1].Salud = 100;
                personajes[player2].Salud = 100;
            }
        }
    }
}
