using System;
using System.Text;

namespace _4devStudio.FiveOfGold
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Ejecutar();
        }

        private static void Ejecutar()
        {
            Console.Title = "Five of Gold :: Generator";
            int vJugadas = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("###############################################");
            Console.WriteLine("#######     Five of Gold :: Generator   #######");
            Console.WriteLine("###############################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese por favor la cantidad de Jugadas a Simular: ");
            string vCantidadJugadasEvaluar = Console.ReadLine();
            if (int.TryParse(vCantidadJugadasEvaluar, out vJugadas))
            {
                Console.Title = "Calculating...";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Iniciando " + vJugadas + " jugadas...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("# " + DateTime.Now.ToShortDateString() + " : " + DateTime.Now.ToLongTimeString());
                Jugada vJugada = Logica.Jugar(vJugadas);
                StringBuilder vResultado = new StringBuilder();
                Console.ForegroundColor = ConsoleColor.Green;
                vResultado.Append("La mejor jugada resultó: ");
                int vContador = 0;
                foreach (int j in vJugada.Numeros)
                {
                    if(vContador < 4)
                    {
                        vResultado.Append(j.ToString() + " - ");
                    }
                    else
                    {
                        vResultado.Append(j.ToString());
                    }
                    vContador++;
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(vResultado.ToString());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("# " + DateTime.Now.ToShortDateString() + " : " + DateTime.Now.ToLongTimeString());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Title = "DONE :: Five of Gold :: Generator";
                string vOpcion = string.Empty;
                do
                {
                    Console.Write("Que desea hacer: [C] para Continuar, [S] para salir: ");
                    vOpcion = Console.ReadLine();
                } while (vOpcion.ToUpper() != "C" && vOpcion.ToUpper() != "S");
                if(vOpcion.ToUpper() == "C")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("***************" + DateTime.Now.ToShortDateString() + " : " + DateTime.Now.ToLongTimeString() + "***************");
                    Console.WriteLine("");
                    Program.Ejecutar();
                }
                else
                {
                    Program.Salir();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No es divertido poner cualquier valor... PONÉ UN NUMERO, a JUGAR A LA PLAY... de caliente, te cierro el programa.");
                Program.Salir();
            }
        }

        private static void Salir()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Saliendo del sistema...");
            System.Threading.Thread.Sleep(4000);
            Environment.Exit(0);
        }
    }
}
