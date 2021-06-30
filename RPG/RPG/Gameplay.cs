using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public static class Gameplay
    {
        static readonly Random random = new Random();

        public static void Combate(List<Personaje> personajes, Personaje player1, Personaje player2)
        {
            int nroDeAtaques = 0;

            Vistas.MostrarCombatientes(player1, player2);
            Vistas.MostrarMjePreCombate();

            while (nroDeAtaques < 3 && player1.Salud > 0 && player2.Salud > 0)
            {
                player1.Atacar(player2);

                Vistas.MostrarSaludCombatientes(player1, player2);

                if (player2.Salud > 0)
                {
                    player2.Atacar(player1);
                    Vistas.MostrarSaludCombatientes(player1, player2);
                }

                nroDeAtaques++;
            }

            if(player1.Salud > player2.Salud)
            {
                player1.SubirDeNivel();
                Vistas.MostrarGanadorCombate(player1);
                personajes.Remove(player2);                
            }
            else if (player2.Salud > player1.Salud)
            {
                player2.SubirDeNivel();
                Vistas.MostrarGanadorCombate(player2);
                personajes.Remove(player1);                
            }
            else
            {
                Vistas.MostrarEmpate();
                player1.Salud = 100;
                player2.Salud = 100;
            }
        }
        
        public static Personaje SeleccionarPlayer(List<Personaje> players)
        {
            return players[random.Next(0, players.Count)];
        }
    }
}