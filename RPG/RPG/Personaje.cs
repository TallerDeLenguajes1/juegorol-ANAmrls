using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public enum TipoPje
    {
        Humano,
        Orco,
        Hobbit,
        Elfo,
        Mago
    }
    public class Personaje
    {
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private TipoPje tipo;
        private string nombre;
        private string apodo;
        private DateTime fechaNac;
        private int edad;
        private int salud;
                
        public Personaje(string nombre, string apodo, DateTime fechaNac, TipoPje tipo)
        {
            Nombre = nombre;
            Apodo = apodo;
            FechaNac = fechaNac;
            Tipo = tipo;
        }

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public TipoPje Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }
    }
}
