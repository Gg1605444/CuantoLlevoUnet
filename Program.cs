using System.IO;
using System.Collections;
using System.Globalization;

namespace CuantoLlevoUnet
{
    class cuantoLlevoUnet
    {
        static decimal calc(List<int> notas, List<int> uc)
        {
            decimal numerador = 0;
            decimal denominador = uc.Sum();
            decimal indice = 0;
            for (int i = 0; i < notas.Count; i++)
            {
                numerador = numerador + (notas[i] * uc[i]);
            }
            indice = numerador / denominador;
            return indice;
        }

        static void leer_notas()
        {
            decimal indice_acomulado = 0;
            List<int> notas = new List<int>();
            List<int> unidades_credito = new List<int>();
            try
            {
                using (StreamReader sr = new StreamReader("notas.txt"))
                {
                    string? line;
                    string[] line_split;
                    while ((line = sr.ReadLine()) != null)
                    { 
                        if (!line.Contains("#") && string.IsNullOrWhiteSpace(line) == false)
                        {
                            line_split = line.Split("-"); 
                            unidades_credito.Add(Convert.ToInt32(line_split[0]));
                            notas.Add(Convert.ToInt32(line_split[1]));
                        }
                    } 
                    indice_acomulado = calc(notas, unidades_credito);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\tNo se encontro el archivo");
                Console.WriteLine("\t" + e.Message + "\n");
            }
            finally
            {
                Console.WriteLine("Su indice acomulado es de: " + indice_acomulado.ToString("f2") + "\n");
                Console.WriteLine("Presione cualquier tecla para finalizar.");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            leer_notas();
        }
    }
}