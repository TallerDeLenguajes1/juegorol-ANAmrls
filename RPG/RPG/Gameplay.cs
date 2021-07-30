using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

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

        public static void GuardarGanadorCSV(Personaje ganador, string rutaDeArchivo)
        {
            FileStream miArchivo = new FileStream(rutaDeArchivo, FileMode.Create);
            StreamWriter strWriter = new StreamWriter(miArchivo);

            strWriter.WriteLine("{0};{1};{2}", ganador.Nombre, ganador.Apodo, ganador.Nivel);

            strWriter.Close();
        }

        public static void GuardarGanadorJson(Personaje ganador, string rutaDeArchivo)
        {
            List<Personaje> historialGanadores;

            if (File.Exists(rutaDeArchivo))
            {
                historialGanadores = LeerJson(rutaDeArchivo);

                if (historialGanadores.Count == 3)
                {
                    if (historialGanadores[0].Nivel <= ganador.Nivel)
                    {
                        historialGanadores.RemoveAt(0);
                        historialGanadores.Add(ganador);
                    }
                }
                else
                {
                    historialGanadores.Add(ganador);
                }
            }
            else
            {
                historialGanadores = new List<Personaje>
                {
                    ganador
                };
            }

            using (FileStream miArchivo = new FileStream(rutaDeArchivo, FileMode.Create))
            {
                using (StreamWriter strWriter = new StreamWriter(miArchivo))
                {
                    foreach (Personaje jugador in historialGanadores)
                    {
                        string strJason = JsonSerializer.Serialize(jugador);
                        strWriter.WriteLine(strJason);
                    }
                }
            }
        }

        public static List<Personaje> LeerJson(string rutaDeArchivo)
        {
            List<Personaje> historialGanadores = new List<Personaje>();

            if (File.Exists(rutaDeArchivo))
            {
                using (FileStream miArchivo = new FileStream(rutaDeArchivo, FileMode.Open))
                {
                    using (StreamReader strReader = new StreamReader(miArchivo))
                    {
                        while (!strReader.EndOfStream)
                        {
                            string ganadores = strReader.ReadLine();
                            historialGanadores.Add(JsonSerializer.Deserialize<Personaje>(ganadores));
                        }
                    }
                }
            }

            return historialGanadores = historialGanadores.OrderBy(x => x.Nivel).ToList();
        }
    }
}