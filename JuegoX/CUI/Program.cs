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
        static void Main(string[] args)
        {
            ConsoleKeyInfo dirc;
            ModeloJuego.Anadir(2);
            ModeloJuego.Mostrar();
            bool partida = true;
            while (partida)
            {
                dirc = Console.ReadKey();
                Console.Clear();
                ModeloJuego.Direccion(dirc);
                ModeloJuego.Anadir(1);
                //Console.WriteLine(dirc.Key.ToString());
                bool resultado=ModeloJuego.Mostrar();
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
            
            Console.ReadKey();
        }
    }
}
