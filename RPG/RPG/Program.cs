using System;
using System.Collections.Generic;
using UsoDeAPI;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int nroPlayers;
            string valorIngresado, opcionManual;
            Personaje player1, player2;
            List<Personaje> players = new List<Personaje>();            
            Gameplay nuevoJuego = new Gameplay();

            do
            {
                Console.WriteLine("\nIngrese el numero de jugadores: ");
                valorIngresado = Console.ReadLine();
            } while (!int.TryParse(valorIngresado, out nroPlayers) || nroPlayers < 2);

            do
            {
                Console.WriteLine("\n - Para crear personajes de modo manual presione 'm'\n"
                              + " - Para crear personajes de modo aleatorio presione 'r'");
                opcionManual = Console.ReadLine();
            } while (opcionManual != "m" && opcionManual != "M" && opcionManual != "r" && opcionManual != "R");
                        
            if (opcionManual == "r" || opcionManual == "R")
            {
                for (int i = 0; i < nroPlayers; i++)
                {
                    players.Add(CreadorDePje.CrearPjeAleatorio());
                }
            }
            else
            {
                for (int i = 0; i < nroPlayers; i++)
                {
                    players.Add(CreadorDePje.CrearPjeManualmente());
                }
            }
            
            foreach (Personaje personaje in players)
            {
                personaje.MostrarPje();
            }

            do
            {
                player1 = nuevoJuego.SeleccionarPlayer(players);
                do
                {
                    player2 = nuevoJuego.SeleccionarPlayer(players);
                } while (player1 == player2);

                nuevoJuego.Combate(players, player1, player2);
            } while (players.Count > 1);

        }
    }
}
