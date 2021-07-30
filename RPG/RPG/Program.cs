using System;
using System.Collections.Generic;
using System.IO;
using UsoDeAPI;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "A Star Wars Game";            
            int nroPlayers, menuInicial;
            string valorIngresado, modoCreacionJugador, jugarOtraVez, opcionMenuInicial;
            Personaje player1, player2;
            List<Personaje> players = new List<Personaje>();            
            
            do
            {
                //Menú inicial
                do
                {
                    do
                    {
                        Vistas.MostrarTitulo();

                        Console.WriteLine("\nSeleccione una opcion: \n"
                            + "1 - Ver ranking de victorias\n"
                            + "2 - Iniciar Nueva Partida");
                        opcionMenuInicial = Console.ReadLine();
                    } while (!int.TryParse(opcionMenuInicial, out menuInicial) || menuInicial < 1 || menuInicial > 2);

                    if (menuInicial == 1)
                    {
                        Vistas.MostrarRanking();
                    }

                } while (menuInicial != 2);

                Vistas.MostrarTitulo();

                //Selección de la cantidad de jugadores
                do
                {
                    Console.WriteLine("\nIngrese el numero de jugadores: ");
                    valorIngresado = Console.ReadLine();
                } while (!int.TryParse(valorIngresado, out nroPlayers) || nroPlayers < 2);

                //Selección del modo de crear los jugadores
                do
                {
                    Console.WriteLine("\n- Para crear personajes de modo manual presione 'm'\n"
                                + "- Para crear personajes de modo aleatorio presione 'a'");
                    modoCreacionJugador = Console.ReadLine();
                } while (modoCreacionJugador != "m" && modoCreacionJugador != "M"
                         && modoCreacionJugador != "a" && modoCreacionJugador != "A");
            
                //Crear jugadores y añadirlos a una lista
                if (modoCreacionJugador == "a" || modoCreacionJugador == "A")
                {
                    Console.WriteLine("\nCargando personajes...");

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

                //Desarrollo del juego
            
                do
                {
                    player1 = Gameplay.SeleccionarPlayer(players);
                    do
                    {
                        player2 = Gameplay.SeleccionarPlayer(players);
                    } while (player1 == player2);

                    Gameplay.Combate(players, player1, player2);
                } while (players.Count > 1);

                Vistas.MostrarGanadorJuego(players[0]);
                Gameplay.GuardarGanadorCSV(players[0], @"..\..\..\..\Ganador del Juego.csv");
                Gameplay.GuardarGanadorJson(players[0], @"..\..\..\..\Ganador del Juego.Json");
                players.Clear();
                Vistas.MostrarFinDeJuego();

                jugarOtraVez = Console.ReadLine();

            } while (jugarOtraVez == "s" || jugarOtraVez == "S");
        }
    }
}
