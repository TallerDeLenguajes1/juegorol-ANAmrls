using System;
using System.Collections.Generic;
using System.Text;

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

    public class CreadorDePje
    {
        public List<Personaje> personajes = new List<Personaje>();

        readonly Random random = new Random();

        public Personaje CrearPjeAleatorio()
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
                Armadura = GenerarStatAleatorio(1, 10)
            };
            nuevoPje.Apodo = GenerarApodoDePje(nuevoPje.Nombre);
            nuevoPje.Edad = CalcularEdad(nuevoPje.FechaNac);

            return nuevoPje;
        }

        //void ArmarListaDePjes(Personaje personajeX)
        //{
        //    personajes.Add(personajeX);
        //}

        //Generadores de datos y características aleatorios
        string GenerarNombreDePje()
        {
            Array valuesNombrePje = Enum.GetValues(typeof(NombrePje));
            return ((NombrePje)valuesNombrePje.GetValue(random.Next(valuesNombrePje.Length))).ToString();
        }

        string GenerarApodoDePje(string nombre)
        {
            int index = nombre.IndexOf("_") + 1;
            return nombre[index..];
        }

        DateTime GenerarFechaNac()
        {
            TimeSpan years = new TimeSpan(random.Next(0, 301) * 365, 0, 0, 0);
            return DateTime.Now - years;
        }

        int CalcularEdad(DateTime fechaNac)
        {
            DateTime hoy = DateTime.Now;
            int edad = hoy.Year - fechaNac.Year;

            if (hoy.Month < fechaNac.Month || (hoy.Month == fechaNac.Month && hoy.Day < fechaNac.Day))
            {
                edad--;
            }

            return edad;
        }

        TipoPje GenerarTipoDePje()
        {
            Array valuesTipoPje = Enum.GetValues(typeof(TipoPje));
            return (TipoPje)valuesTipoPje.GetValue(random.Next(valuesTipoPje.Length));
        }

        int GenerarStatAleatorio(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
