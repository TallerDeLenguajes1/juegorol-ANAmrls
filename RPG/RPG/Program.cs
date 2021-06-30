﻿using System;
using System.Collections.Generic;
using UsoDeAPI;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "A Star Wars Game";            
            int nroPlayers;
            string valorIngresado, opcionManual;
            Personaje player1, player2;
            List<Personaje> players = new List<Personaje>();            
            
            Vistas.MostrarInicio();

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
                opcionManual = Console.ReadLine();
            } while (opcionManual != "m" && opcionManual != "M"
                     && opcionManual != "a" && opcionManual != "A");
            
            //Crear jugadores y añadirlos a una lista
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
        }
    }
}
