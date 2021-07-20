using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp6.App_LocalResources;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            // BuildAndRegisterHobbitCulture();

            const string goodDay = "lblMensaje";

            var asd = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

            SetCulture("es");
            // Default.
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            // Custom - Hobbit.
            SetCulture("en-Hobbit");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("es-Paisa");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("en-Avengers");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            // German.
            SetCulture("de-DE");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            // German.
            SetCulture("es-ZZZZZ");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("es-XXXXX");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("en-DCCom");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("es-Propa");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("es-IngClas");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("es-Pedido");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("en-Siembra");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));

            SetCulture("es-Compras");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name,
                GlobalRes.ResourceManager.GetString(goodDay));


            Console.ReadLine();

        }

        private static void SetCulture(string culture)
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private static void BuildAndRegisterHobbitCulture()
        {
            if (CultureInfo.GetCultures(CultureTypes.AllCultures).Any(ci => ci.Name == "es-Compras"))
                return;

            var cultureAndRegionInfoBuilder = new CultureAndRegionInfoBuilder("es-Compras", CultureAndRegionModifiers.None);
            cultureAndRegionInfoBuilder.LoadDataFromCultureInfo(CultureInfo.CreateSpecificCulture("es-ES"));
            cultureAndRegionInfoBuilder.LoadDataFromRegionInfo(new RegionInfo("es-ES"));
            cultureAndRegionInfoBuilder.Register();
        }
    }
}
