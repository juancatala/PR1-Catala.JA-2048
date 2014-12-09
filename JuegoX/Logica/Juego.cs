using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanC.Programacion.Eval1.Juego.Logica
{
    public class ModeloJuego
    {
        
        static int[,] matriu = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        static int[,] matriu2 = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        static Random alea = new Random();
        public static void Anadir(int cont) 
        {
             
            
            
            while (cont > 0)
            {
                int val = 0;
                int cont2 = 0;
                int cont3 = 0;
                for (cont2 = 0; cont2 < 10; cont2++)
                {
                    int pos1 = alea.Next(0, 3);
                    int pos2 = alea.Next(0, 3);
                    if (matriu[pos1, pos2] == 0)
                    {
                        
                        if (cont == 2) { val = alea.Next(0, 3);}
                        if (cont != 2) { val = 2; }
                        if (val == 3)
                        {
                            matriu[pos1, pos2] = 4;
                            cont--;
                            break;
                        }
                        else
                        {
                            matriu[pos1, pos2] = 2;
                            cont--;
                            break;
                        }
                    }
                }
                if (cont2 == 10)
                {
                    int i = 0;
                    int j = 0;
                    for (i = 0; i <= 3; i++)
                    {
                        for (j = 0; j <= 3; j++)
                        {
                            if (matriu[i, j] == 0) break;
                            else cont3++;
                        }
                        if (j == 4) j = 3;
                        if (matriu[i, j] == 0) break;
                    }
                    if (i == 4) i = 3;
                    if (matriu[i, j] == 0)
                    {
                        matriu[i, j] = 2;
                        cont--;
                    }
                    else if (cont3 == 16) break;
                }
            }
        }
        public static bool Mostrar()
        {
            bool resultado = false;
            int puntuacion = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i=0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    
                    switch (matriu[i, j])
                    {
                        case 0: Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("   {0}", matriu[i, j]);
                            break;
                        case 2: Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write("   {0}", matriu[i, j]);
                            break;
                        case 4: Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write("   {0}", matriu[i, j]);
                            break;
                        case 8: Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("   {0}", matriu[i, j]);
                            break;
                        case 16: Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("  {0}", matriu[i, j]);
                            break;
                        case 32: Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("  {0}", matriu[i, j]);
                            break;
                        case 64: Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("  {0}", matriu[i, j]);
                            break;
                        case 128: Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0}", matriu[i, j]);
                            break;
                        case 256: Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(" {0}", matriu[i, j]);
                            break;
                        case 512: Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(" {0}", matriu[i, j]);
                            break;
                        case 1024: Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("{0}", matriu[i, j]);
                            break;
                        case 2048: Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("{0}", matriu[i, j]);
                            resultado = true;
                            break;
                        default: Console.Write("{0}", matriu[i, j]);
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    puntuacion += matriu[i, j];
                 
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("Puntuacion: {0}",puntuacion);
            return resultado;
        }
        public static void Direccion(ConsoleKeyInfo dirc)
        {
            switch (dirc.Key)
	        {
                case ConsoleKey.W: Arriba();
                    break;
                case ConsoleKey.S: Abajo();
                    break;
                case ConsoleKey.A: Izquierda();
                    break;
                case ConsoleKey.D: Derecha();
                    break;
                default: Console.WriteLine("No es una direccion adecuada.");
                    break;
            }
            
        }
        public static bool BuscarSumas()
        {
            bool perder = false;
               int arriba = ArribaBuscar();
               int abajo = AbajoBuscar();
               int izquierda = IzquierdaBuscar();
               int derecha = DerechaBuscar();
               int busqueda = arriba + abajo + izquierda + derecha;
               if (busqueda == 48)
               {
                   perder = true;
               }
               return perder;
        }
        public static void Arriba()
        {
            for (int j = 0; j < 4; j++)
            {

                OrganizarArriba(j);
                for (int i = 3; i >= 0; i--)
                {
                    if (matriu[i, j] != 0)
                    {
                        if (i-1 >= 0)
                        {
                            if (matriu[i, j] == matriu[i - 1, j])
                            {
                                matriu[i - 1, j] = matriu[i, j] + matriu[i - 1, j];
                                matriu[i, j] = 0;
                                i--;
                            }
                        }
                    }
                }
                OrganizarArriba(j);     
            }
        }
        public static void OrganizarArriba(int j)
        {
                for (int x = 1; x < 4; x++)
                {
                    for (int cont = x; cont > 0; cont--)
                    {
                        if (matriu[cont - 1, j] == 0)
                        {
                            matriu[cont - 1, j] = matriu[cont, j];
                            matriu[cont, j] = 0;
                        }
                    }
                }
            
        }
        public static void Abajo()
        {
            for (int j = 0; j < 4; j++)
            {

                OrganizarAbajo(j);
                for (int i = 0; i < 4; i++)
                {
                    if (matriu[i, j] != 0)
                    {
                        if (i + 1 <= 3)
                        {
                            if (matriu[i, j] == matriu[i + 1, j])
                            {
                                matriu[i + 1, j] = matriu[i, j] + matriu[i + 1, j];
                                matriu[i, j] = 0;
                                i++;
                            }
                        }
                    }
                }
                OrganizarAbajo(j);
            }
        }

        public static void OrganizarAbajo(int j)
        {
            for (int x = 2; x >= 0; x--)
            {
                for (int cont = x; cont < 3; cont++)
                {
                    if (matriu[cont + 1, j] == 0)
                    {
                        matriu[cont + 1, j] = matriu[cont, j];
                        matriu[cont, j] = 0;
                    }
                }
            }

        }
        public static void Izquierda()
        {
            for (int i = 0; i < 4; i++)
            {

                OrganizarIzquierda(i);
                for (int j = 3; j >= 0; j--)
                {
                    if (matriu[i, j] != 0)
                    {
                        if (j - 1 >= 0)
                        {
                            if (matriu[i, j] == matriu[i, j - 1])
                            {
                                matriu[i, j - 1] = matriu[i, j] + matriu[i, j - 1];
                                matriu[i, j] = 0;
                                j--;
                            }
                        }
                    }
                }
                OrganizarIzquierda(i);
            }
        }
        public static void OrganizarIzquierda(int i)
        {
            for (int x = 1; x < 4; x++)
            {
                for (int cont = x; cont > 0; cont--)
                {
                    if (matriu[i, cont - 1] == 0)
                    {
                        matriu[i, cont - 1] = matriu[i, cont];
                        matriu[i, cont] = 0;
                    }
                }
            }

        }
        public static void Derecha()
        {
            for (int i = 0; i < 4; i++)
            {

                OrganizarDerecha(i);
                for (int j = 0; j < 4; j++)
                {
                    if (matriu[i, j] != 0)
                    {
                        if (j + 1 <= 3)
                        {
                            if (matriu[i, j] == matriu[i, j + 1])
                            {
                                matriu[i, j + 1] = matriu[i, j] + matriu[i, j + 1];
                                matriu[i, j] = 0;
                                j++;
                            }
                        }
                    }
                }
                OrganizarDerecha(i);
            }
        }
        public static void OrganizarDerecha(int i)
        {
            for (int x = 2; x >= 0; x--)
            {
                for (int cont = x; cont < 3; cont++)
                {
                    if (matriu[i, cont + 1] == 0)
                    {
                        matriu[i, cont + 1] = matriu[i, cont];
                        matriu[i, cont] = 0;
                    }
                }
            }

        }
        public static int ArribaBuscar()
        {
            int cont=0;
            for (int a = 0; a <= 3; a++)
            {
                for (int b = 0; b <= 3; b++)
                {
                    matriu2[a, b]=matriu[a, b];
                }
            }
            for (int j = 0; j < 4; j++)
            {

                OrganizarArribaBuscar(j);
                for (int i = 3; i >= 0; i--)
                {
                    if (matriu2[i, j] != 0)
                    {
                        if (i - 1 >= 0)
                        {
                            if (matriu2[i, j] != matriu2[i - 1, j])
                            {
                                cont++;
                            }
                            else i--;
                        }
                    }
                }
                OrganizarArribaBuscar(j);
            }
            return cont;
        }
        public static void OrganizarArribaBuscar(int j)
        {
            for (int x = 1; x < 4; x++)
            {
                for (int cont = x; cont > 0; cont--)
                {
                    if (matriu2[cont - 1, j] == 0)
                    {
                        matriu2[cont - 1, j] = matriu2[cont, j];
                        matriu2[cont, j] = 0;
                    }
                }
            }

        }
        public static int AbajoBuscar()
        {
            int cont = 0;
            for (int a = 0; a <= 3; a++)
            {
                for (int b = 0; b <= 3; b++)
                {
                    matriu2[a, b] = matriu[a, b];
                }
            }
            for (int j = 0; j < 4; j++)
            {

                OrganizarAbajoBuscar(j);
                for (int i = 0; i < 4; i++)
                {
                    if (matriu2[i, j] != 0)
                    {
                        if (i + 1 <= 3)
                        {
                            if (matriu2[i, j] != matriu2[i + 1, j])
                            {
                                cont++;
                            }
                            else    i++;
                           
                        }
                    }
                }
                OrganizarAbajoBuscar(j);
            }
            return cont;
        }

        public static void OrganizarAbajoBuscar(int j)
        {
            for (int x = 2; x >= 0; x--)
            {
                for (int cont = x; cont < 3; cont++)
                {
                    if (matriu2[cont + 1, j] == 0)
                    {
                        matriu2[cont + 1, j] = matriu2[cont, j];
                        matriu2[cont, j] = 0;
                    }
                }
            }

        }
        public static int IzquierdaBuscar()
        {
            int cont = 0;
            for (int a = 0; a <= 3; a++)
            {
                for (int b = 0; b <= 3; b++)
                {
                    matriu2[a, b] = matriu[a, b];
                }
            }
            for (int i = 0; i < 4; i++)
            {

                OrganizarIzquierdaBuscar(i);
                for (int j = 3; j >= 0; j--)
                {
                    if (matriu2[i, j] != 0)
                    {
                        if (j - 1 >= 0)
                        {
                            if (matriu2[i, j] != matriu2[i, j - 1])
                            {
                                cont++;
                            }
                            else j--;
                            
                        }
                    }
                }
                OrganizarIzquierdaBuscar(i);
            }
            return cont;
        }
        public static void OrganizarIzquierdaBuscar(int i)
        {
            for (int x = 1; x < 4; x++)
            {
                for (int cont = x; cont > 0; cont--)
                {
                    if (matriu2[i, cont - 1] == 0)
                    {
                        matriu2[i, cont - 1] = matriu2[i, cont];
                        matriu2[i, cont] = 0;
                    }
                }
            }

        }
        public static int DerechaBuscar()
        {
            int cont = 0;
            for (int a = 0; a <= 3; a++)
            {
                for (int b = 0; b <= 3; b++)
                {
                    matriu2[a, b] = matriu[a, b];
                }
            }
            for (int i = 0; i < 4; i++)
            {

                OrganizarDerechaBuscar(i);
                for (int j = 0; j < 4; j++)
                {
                    if (matriu2[i, j] != 0)
                    {
                        if (j + 1 <= 3)
                        {
                            if (matriu2[i, j] != matriu2[i, j + 1])
                            {
                                cont++;
                            }
                            else    j++;
                            
                        }
                    }
                }
                OrganizarDerechaBuscar(i);
            }
            return cont;
        }
        public static void OrganizarDerechaBuscar(int i)
        {
            for (int x = 2; x >= 0; x--)
            {
                for (int cont = x; cont < 3; cont++)
                {
                    if (matriu2[i, cont + 1] == 0)
                    {
                        matriu2[i, cont + 1] = matriu2[i, cont];
                        matriu2[i, cont] = 0;
                    }
                }
            }

        }
    }
}
