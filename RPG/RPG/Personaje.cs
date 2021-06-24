using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public enum TipoPje
    {
        BountyHunter,
        CloneTrooper,
        Droid,
        Ewok,
        FirstOrder,
        ImperialTrooper,
        Jawa,
        Jedi,
        Mandalorian,
        Rebel,
        Separatist,
        Sith
    }
    public class Personaje
    {
        readonly Random random = new Random();

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
        private float salud;

        public Personaje()
        {

        }

        public Personaje(string nombre, string apodo, DateTime fechaNac, TipoPje tipo)
        {
            Nombre = nombre;
            Apodo = apodo;
            FechaNac = fechaNac;
            Tipo = tipo;
        }

        public void MostrarPje()
        {
            Console.WriteLine("\nDatos:");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Apodo: {Apodo}");
            Console.WriteLine($"Fecha de nacimiento: {FechaNac}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine("\nCaracteristicas:");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Velocidad: {Velocidad}");
            Console.WriteLine($"Destreza: {Destreza}");
            Console.WriteLine($"Fuerza: {Fuerza}");
            Console.WriteLine($"Armadura: {Armadura}");
        }

        public void Atacar(Personaje defensor)
        {
            //Valores de Ataque
            float poderDeDisparo = Destreza * Fuerza * Nivel;
            float efectividadDisparo = (float)random.Next(1, 101);
            float valorDeAtaque = poderDeDisparo * efectividadDisparo;
            float critChance = random.Next(1, 4);

            //Valores de Defensa
            float poderDeDefensa = (float)(defensor.Armadura * defensor.Velocidad);
            float maxDamage = 50000;

            //Enfrentamiento
            float damage = (((valorDeAtaque * efectividadDisparo) - poderDeDefensa) / maxDamage) * critChance * 10;

            defensor.Salud -= damage;
        }

        public void SubirDeNivel()
        {
            int aumentarStat = random.Next(1, 5);

            Nivel++;
            Salud = 100;

            switch (aumentarStat)
            {
                case 1:
                    Velocidad += random.Next(1, 4);
                    break;
                case 2:
                    Fuerza += random.Next(1, 4);
                    break;
                case 3:
                    Armadura += random.Next(1, 4);
                    break;
                case 4:
                    Destreza += 1;
                    break;
                default:
                    break;
            }
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
        public float Salud 
        {
            get => salud;

            set
            {
                salud = value;
                
                if (salud < 0)
                {
                    Salud = 0;
                }
                
            } 
        }
    }
}
