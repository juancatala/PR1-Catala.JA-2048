using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuanC.Programacion.Eval1.Juego.Logica;

namespace JuanC.Programacion.Eval1.Juego.CUI
{
    class Program
    {
        //El metodo Main es el que contiene la interacción con el usuario
        static void Main(string[] args)
        {
            bool reinicio = true;
            //El bucle de reinicio es para saber si el jugador desea jugar otra partida
            while (reinicio)
            {
                Console.Clear();
                ConsoleKeyInfo dirc;
                ModeloJuego.Anadir(2);
                ModeloJuego.Mostrar();
                bool partida = true;
                //El bucle partida es para mantener el juego hasta que el jugador gana o pierde
                while (partida)
                {
                    dirc = Console.ReadKey();
                    Console.Clear();
                    ModeloJuego.Direccion(dirc);
                    ModeloJuego.Anadir(1);
                    //Console.WriteLine(dirc.Key.ToString());
                    bool resultado = ModeloJuego.Mostrar();
                    bool perder = ModeloJuego.BuscarSumas();
                    if (perder)
                    {
                        Console.WriteLine("No hay mas movimientos posibles, has perdido.");
                        break;
                    }
                    if (resultado)
                    {
                        Console.WriteLine("Has conseguido 2048 puntos en una sola casilla, felicidades!");
                        break;
                    }
                }
                reinicio = ModeloJuego.Reiniciar();
            }

        }
    }
}
