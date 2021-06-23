using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public enum NombrePje
    {
        Aragorn,
        Gimli,
        Legolas,
        Gandalf,
        Saruman,
        Frodo,
        Sam,
        Gollum,
        Smeagol,
        Eowyn,
        Eomer,
        Arwen
    }
    public class CreadorDePje
    {
        public Personaje CrearPjeAleatorio()
        {
            Random random = new Random();

            int edad = random.Next(0, 301);
            TimeSpan years = new TimeSpan(edad * 365, 0, 0, 0);

            Array valuesNombrePje = Enum.GetValues(typeof(NombrePje));
            string nombre = ((NombrePje)valuesNombrePje.GetValue(random.Next(valuesNombrePje.Length))).ToString();
            Array valuesTipo = Enum.GetValues(typeof(TipoPje));
            
            Personaje nuevoPje = new Personaje(nombre, nombre, DateTime.Now,
                                               (TipoPje)valuesTipo.GetValue(random.Next(valuesTipo.Length)));

            nuevoPje.Velocidad = random.Next(1, 11);
            nuevoPje.Destreza = random.Next(1, 6);
            nuevoPje.Fuerza = random.Next(1, 11);
            nuevoPje.Armadura = random.Next(1, 11);
            nuevoPje.Edad = edad;
            nuevoPje.FechaNac -= years;
            nuevoPje.Nivel = 1;
            nuevoPje.Salud = 100;

            return nuevoPje;
        }
    }
}
