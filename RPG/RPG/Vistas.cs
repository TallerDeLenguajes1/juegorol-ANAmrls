using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public static class Vistas
    {
        public static void MostrarCombatientes(Personaje player1, Personaje player2)
        {
            const int der = 30, izq = -30, medio = -10, linea = 74;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n==========================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"",linea}");
            Console.WriteLine($" {player1.Nombre,izq} {"vs",medio} {player2.Nombre,der} ");
            Console.WriteLine($"{"",linea}");
            Console.ResetColor();
            Console.WriteLine($"\n {player1.Apodo,izq} {"APODO",medio} {player2.Apodo,der}");
            Console.WriteLine($"\n {player1.PlanetaDeOrigen,izq} {"ORIGEN",medio} {player2.PlanetaDeOrigen,der}");
            Console.WriteLine($"\n {player1.Edad,izq} {"EDAD",medio} {player2.Edad,der}");
            Console.WriteLine($"\n {player1.Tipo,izq} {"TIPO",medio} {player2.Tipo,der}");
            Console.WriteLine($"\n {player1.Nivel,izq} {"NIVEL",medio} {player2.Nivel,der}");
            Console.WriteLine($"\n {player1.Velocidad,izq} {"VELOCIDAD",medio} {player2.Velocidad,der}");
            Console.WriteLine($"\n {player1.Destreza,izq} {"DESTREZA",medio} {player2.Destreza,der}");
            Console.WriteLine($"\n {player1.Fuerza,izq} {"FUERZA",medio} {player2.Fuerza,der}");
            Console.WriteLine($"\n {player1.Armadura,izq} {"ARMADURA",medio} {player2.Armadura,der}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n==========================================================================");
            Console.ResetColor();
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
        }

        public static void MostrarSaludCombatientes(Personaje player1, Personaje player2)
        {
            const int der = 30, izq = -30, medio = -10, linea = 74;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n==========================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"",linea}");
            Console.WriteLine($" {player1.Nombre,izq} {"vs",medio} {player2.Nombre,der} ");
            Console.WriteLine($"{"",linea}");
            Console.ResetColor();
            Console.WriteLine($"\n {player1.Salud,izq:F2} {"SALUD",medio} {player2.Salud,der:F2}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n==========================================================================");
            Console.ResetColor();
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
        }

        public static void MostrarMjePreCombate()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string readyGo = @"
    .______       _______     ___       _______  ____    ____       
    |   _  \     |   ____|   /   \     |       \ \   \  /   /       
    |  |_)  |    |  |__     /  ^  \    |  .--.  | \   \/   /        
    |      /     |   __|   /  /_\  \   |  |  |  |  \_    _/         
    |  |\  \----.|  |____ /  _____  \  |  '--'  |    |  |  __ __ __ 
    | _| `._____||_______/__/     \__\ |_______/     |__| (__|__|__)
                                                                
                         _______   ______    __  
                        /  _____| /  __  \  |  | 
                       |  |  __  |  |  |  | |  | 
                       |  | |_ | |  |  |  | |  | 
                       |  |__| | |  `--'  | |__| 
                        \______|  \______/  (__) ";
            Console.WriteLine(readyGo);
            Console.ResetColor();
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
        }

        public static void MostrarGanadorCombate(Personaje ganador)
        {
            const int izq = -27, linea = 36;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n======================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"",linea}");
            Console.WriteLine($"        {"Ganador:",izq} ");
            Console.WriteLine($"        {ganador.Nombre,izq} ");
            Console.WriteLine($"        {"Sube de Nivel!",izq} ");
            Console.WriteLine($"{"",linea}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======================================");
            Console.ResetColor();
            ganador.MostrarPje();
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
        }

        public static void MostrarEmpate()
        {
            const int izq = -27, linea = 36;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n======================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"",linea}");
            Console.WriteLine($"       {"Es un empate",izq} ");            
            Console.WriteLine($"       {"Ambos recuperan la Salud!",izq} ");
            Console.WriteLine($"{"",linea}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======================================");
            Console.ResetColor();
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
        }

        public static void MostrarTitulo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string titulo = @"        ___              _______.___________.    ___      .______      
       /   \            /       |           |   /   \     |   _  \     
      /  ^  \          |   (----`---|  |----`  /  ^  \    |  |_)  |    
     /  /_\  \          \   \       |  |      /  /_\  \   |      /     
    /  _____  \     .----)   |      |  |     /  _____  \  |  |\  \----.
   /__/     \__\    |_______/       |__|    /__/     \__\ | _| `._____|
                                                                       
          ____    __    ____  ___      .______          _______.
          \   \  /  \  /   / /   \     |   _  \        /       |
           \   \/    \/   / /  ^  \    |  |_)  |      |   (----`
            \            / /  /_\  \   |      /        \   \    
             \    /\    / /  _____  \  |  |\  \----.----)   |   
              \__/  \__/ /__/     \__\ | _| `._____|_______/    
                                                                
                 _______      ___      .___  ___.  _______ 
                /  _____|    /   \     |   \/   | |   ____|
               |  |  __     /  ^  \    |  \  /  | |  |__   
               |  | |_ |   /  /_\  \   |  |\/|  | |   __|  
               |  |__| |  /  _____  \  |  |  |  | |  |____ 
                \______| /__/     \__\ |__|  |__| |_______|
";
            Console.WriteLine(titulo);
            Console.ResetColor();            
        }

        public static void MostrarGanadorJuego(Personaje ganador)
        {
            const int izq = -27, linea = 36;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=====================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"",linea}");
            Console.WriteLine($"        {"El Ganador es:",izq} ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine($"        {ganador.Nombre,izq} ");          
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine($"{"",linea}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====================================");
            Console.ResetColor();
            ganador.MostrarPje();
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
        }

        public static void MostrarFinDeJuego()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string gameOver = @"
   _______      ___      .___  ___.  _______ 
  /  _____|    /   \     |   \/   | |   ____|
 |  |  __     /  ^  \    |  \  /  | |  |__   
 |  | |_ |   /  /_\  \   |  |\/|  | |   __|  
 |  |__| |  /  _____  \  |  |  |  | |  |____ 
  \______| /__/     \__\ |__|  |__| |_______|
                                             
   ______   ____    ____  _______ .______      
  /  __  \  \   \  /   / |   ____||   _  \     
 |  |  |  |  \   \/   /  |  |__   |  |_)  |    
 |  |  |  |   \      /   |   __|  |      /     
 |  `--'  |    \    /    |  |____ |  |\  \----.
  \______/      \__/     |_______|| _| `._____|
                                              
";
            Console.WriteLine(gameOver);
            Console.ResetColor();
            Console.WriteLine("\nPresione una tecla para volver al menú");
            Console.ReadKey();
        }

        public static void MostrarRanking()
        {
            List<Personaje> ranking = Gameplay.LeerJson(@"..\..\..\..\Ganador del Juego.Json");
            const int der = 25, izq = -25, medio = -20, linea = -74;
            int i = 1;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n==========================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"",linea}");
            Console.WriteLine($"{"                          Ranking de Ganadores",linea}");
            Console.WriteLine($"{"",linea}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==========================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"",linea}");
            Console.WriteLine($" {"Puesto",izq} {"Nombre",medio} {"Nro de Victorias",der} ");
            Console.WriteLine($"{"",linea}");
            Console.ResetColor();

            foreach (Personaje jugador in ranking)
            {
                Console.WriteLine($"\n {i++,izq} {jugador.Nombre,medio} {jugador.Nivel - 1,der}");
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n==========================================================================");
            Console.ResetColor();
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
        }
    }
}
