using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace VerificadorDeArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Se debe ingresar un archivo a procesar");
                Console.ReadLine();
                return;
            }
            string ruta = args[0];
            int cantLineas = 0;
            string linea = "";
            char delimitador = ';';
            bool existe = false;
            string[] arrayLinea = null;

            var startTime = DateTime.Now;
            Console.WriteLine(startTime.ToString());
            using (var sr = new StreamReader(ruta))
            using (var sw = new StreamWriter(Path.GetDirectoryName(ruta) + "Out.csv", true))
            {
                while ((linea = sr.ReadLine()) != null)
                {
                    try
                    {
                        //if (cantLineas == 5)
                        //{
                        //    Thread.Sleep(1000);
                        //    cantLineas = 0;
                        //}

                        if (!string.IsNullOrEmpty(linea))
                        {
                            arrayLinea = linea.Split(delimitador);

                            if (File.Exists(arrayLinea[0]) && !File.Exists(arrayLinea[1]))
                            {
                                existe = true;

                                if (!Directory.Exists(Path.GetDirectoryName(arrayLinea[1])))
                                    Directory.CreateDirectory(Path.GetDirectoryName(arrayLinea[1]));

                                File.Copy(arrayLinea[0], arrayLinea[1]);
                            }
                            else
                            {
                                existe = false;
                            }
                        }

                        // sw.WriteLine(arrayLinea[0] + ";" + arrayLinea[1] + ";" + (existe ? "Se realizo la copia con exito!" : "El archivo Origen no existe!"));

                        cantLineas++;
                    }
                    catch (Exception ex)
                    {
                        sw.WriteLine(arrayLinea[0] + ";" + arrayLinea[1] + ";" + ex.Message);
                    }
                }
                sw.Flush();
                sw.Close();
            }
            var endTime = DateTime.Now;
            Console.WriteLine(endTime.ToString());
            Console.WriteLine((endTime - startTime).Seconds + " segundos");
            Console.WriteLine(cantLineas + " lineas");
            Console.WriteLine("Finalizó...");

            Console.ReadKey();


        }
    }
}
