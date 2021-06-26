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
            string valorIngresado;
            Personaje player1, player2;
            List<Personaje> players = new List<Personaje>();
            CreadorDePje creadorDePje = new CreadorDePje();
            Gameplay nuevoJuego = new Gameplay();

            do
            {
                Console.WriteLine("\nIngrese el numero de jugadores: ");
                valorIngresado = Console.ReadLine();
            } while (!int.TryParse(valorIngresado, out nroPlayers) || nroPlayers < 2);

            for (int i = 0; i < nroPlayers; i++)
            {
                players.Add(creadorDePje.CrearPjeAleatorio());
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

            //Planetas opcionesDePlanetas = PlanetasAPI.ObtenerPlanetas();

            //foreach (Result planeta in opcionesDePlanetas.Results)
            //{
            //    Console.WriteLine($"{planeta.Name}");
            //}
        }
    }
}
