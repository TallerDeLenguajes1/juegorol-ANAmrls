using System;
using System.Collections.Generic;
using System.Text;
using UsoDeAPI;

namespace RPG
{
    public enum NombrePje
    {
        Boba_Fett,
        The_Mandalorian,
        CT7567_Rex,
        CT5555_Fives,
        R2_D2,
        General_Grievous,
        Kylo_Ren,
        Captain_Phasma,
        Moff_Gideon,
        Ahsoka_Tano,
        Anakin_Skywalker,
        ObiWan_Kenobi,
        Bastila_Shan,
        Sabine_Wren,
        BoKatan_Kryze,
        Princess_Leia,
        Luke_Skywalker,
        Han_Solo,
        Asajj_Ventress,
        Darth_Vader,
        Emperor_Palpatine,
        Cara_Dune,
        Aurra_Sing,
        Enfys_Nest,
        Hera_Syndulla,
        Shaak_Ti
    }    

    public static class CreadorDePje
    {
        static readonly Random random = new Random();

        public static Personaje CrearPjeAleatorio()
        {
            Personaje nuevoPje = new Personaje
            {
                Salud = 100,
                Nivel = 1,
                Nombre = GenerarNombreDePje(),
                Tipo = GenerarTipoDePje(),
                FechaNac = GenerarFechaNac(),
                Velocidad = GenerarStatAleatorio(1, 10),
                Destreza = GenerarStatAleatorio(1, 5),
                Fuerza = GenerarStatAleatorio(1, 10),
                Armadura = GenerarStatAleatorio(1, 10),
                PlanetaDeOrigen = ObtenerPlanetaAleatorio()
            };
            nuevoPje.Apodo = GenerarApodoDePje(nuevoPje.Nombre);
            nuevoPje.Edad = CalcularEdad(nuevoPje.FechaNac);

            return nuevoPje;
        }

        public static Personaje CrearPjeManualmente()
        {
            string nombre, apodo, planeta;
            DateTime fechaNac;
            int opcionTipo, i = 1;
            Array valuesTipoPje = Enum.GetValues(typeof(TipoPje));
            TipoPje tipo;

            Console.WriteLine("\nIngrese un nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("\nIngrese un apodo: ");
            apodo = Console.ReadLine();
            Console.WriteLine("\nIngrese Planeta de origen: ");
            planeta = Console.ReadLine();

            do
            {
                Console.WriteLine("\nIngrese su fecha de nacimiento (mm/dd/aaaa): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out fechaNac));


            do
            {
                Console.WriteLine("\nSeleccione un tipo de personaje:");
                foreach (string tipoDePje in Enum.GetNames(typeof(TipoPje)))
                {
                    Console.WriteLine($"{i++} - {tipoDePje}");
                }
            } while (!int.TryParse(Console.ReadLine(), out opcionTipo));

            tipo = (TipoPje)valuesTipoPje.GetValue(opcionTipo - 1);


            return new Personaje(nombre, apodo, planeta, fechaNac, tipo);
        }

        //Generadores de datos y características aleatorios
        static string GenerarNombreDePje()
        {
            Array valuesNombrePje = Enum.GetValues(typeof(NombrePje));
            return ((NombrePje)valuesNombrePje.GetValue(random.Next(valuesNombrePje.Length))).ToString();
        }

        static string GenerarApodoDePje(string nombre)
        {
            int index = nombre.IndexOf("_") + 1;
            return nombre[index..];
        }

        static DateTime GenerarFechaNac()
        {
            TimeSpan years = new TimeSpan(random.Next(0, 301) * 365, 0, 0, 0);
            return DateTime.Now - years;
        }

        public static int CalcularEdad(DateTime fechaNac)
        {
            DateTime hoy = DateTime.Now;
            int edad = hoy.Year - fechaNac.Year;

            if (hoy.Month < fechaNac.Month || (hoy.Month == fechaNac.Month && hoy.Day < fechaNac.Day))
            {
                edad--;
            }

            return edad;
        }

        static TipoPje GenerarTipoDePje()
        {
            Array valuesTipoPje = Enum.GetValues(typeof(TipoPje));
            return (TipoPje)valuesTipoPje.GetValue(random.Next(valuesTipoPje.Length));
        }

        public static int GenerarStatAleatorio(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        static string ObtenerPlanetaAleatorio()
        {
            Planetas opcionesDePlanetas = PlanetasAPI.ObtenerPlanetas();
            int aux = opcionesDePlanetas.Results.Count;
            return opcionesDePlanetas.Results[random.Next(0, aux)].Name;
        }
    }
}
