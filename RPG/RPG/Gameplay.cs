using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Gameplay
    {
        readonly Random random = new Random();

        public void Combate(List<Personaje> personajes, Personaje player1, Personaje player2)
        {
            int nroDeAtaques = 0;

            Console.WriteLine("\n////////////////////////////////////////////////////");
            Console.WriteLine($"\n{player1.Nombre} vs {player2.Nombre}");
            Console.WriteLine("\nReady... GO!\n");

            while (nroDeAtaques < 3 && player1.Salud > 0 && player2.Salud > 0)
            {
                player1.Atacar(player2);

                Console.WriteLine($"\nSalud {player2.Nombre}: {player2.Salud}");

                if (player2.Salud > 0)
                {
                    player2.Atacar(player1);
                    Console.WriteLine($"\nSalud {player1.Nombre}: {player1.Salud}");
                }

                nroDeAtaques++;
            }

            if(player1.Salud > player2.Salud)
            {
                player1.SubirDeNivel();
                Console.WriteLine("\nGanador: ");
                player1.MostrarPje();
                personajes.Remove(player2);                
            }
            else if (player2.Salud > player1.Salud)
            {
                player2.SubirDeNivel();
                Console.WriteLine("\nGanador: ");
                player2.MostrarPje();
                personajes.Remove(player1);                
            }
            else
            {
                Console.WriteLine("\nEmpate");
                player1.Salud = 100;
                player2.Salud = 100;
            }
        }

        public Personaje SeleccionarPlayer(List<Personaje> players)
        {
            return players[random.Next(0, players.Count)];
        }
    }
}
