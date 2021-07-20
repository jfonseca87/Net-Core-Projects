using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string asd = getCodigo("http://www.elempleo.com/co/ofertas-empleo/?trabajo=.net");

            Console.WriteLine(asd);
            Console.ReadKey();
        }

        public static String getCodigo(String url)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            // Realizamos la petición
            HttpWebResponse miPeticionWeb = (HttpWebResponse)myHttpWebRequest.GetResponse();
            // Obtenemos el flujo de la respuesta
            Stream datosRecibidos = miPeticionWeb.GetResponseStream();
            // Leemos el flujo de la respuesta obtenida, seleccionando el tipo de codificación que deseamos
            Encoding codificacion = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(datosRecibidos, codificacion);
            // Realizamos la conversión a String y devolvemos el valor
            return (readStream.ReadToEnd());
        }
    }
}
