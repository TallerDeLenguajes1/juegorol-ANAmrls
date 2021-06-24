using System;
using System.Collections.Generic;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Personaje> personajes = new List<Personaje>();
            CreadorDePje creadorDePje = new CreadorDePje();
            Personaje player1 = creadorDePje.CrearPjeAleatorio();
            Personaje player2 = creadorDePje.CrearPjeAleatorio();
            Personaje player3 = creadorDePje.CrearPjeAleatorio();
            Personaje player4 = creadorDePje.CrearPjeAleatorio();
            personajes.Add(player1);
            personajes.Add(player2);
            personajes.Add(player3);
            personajes.Add(player4);
            foreach (Personaje personaje in personajes)
            {
                personaje.MostrarPje();
            }

            Gameplay nuevoJuego = new Gameplay();
            nuevoJuego.Combate(personajes, 0, 1);
            //foreach (Personaje personaje in personajes)
            //{
            //    personaje.MostrarPje();
            //}


        }
    }
}
