using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAnonymousMethods
{
    

    class AnonymousMethod
    {
        //delegaten kan pege på en metode som returnerer en int og som har en int parameter
        delegate int delInt1par(int x);
        delegate bool delBool1par(int x);
        delegate int delGange2par(int x, int y);
        static void Main(string[] args)
        {

            //kalder metoden kvadrat med værdien 2 (OBS: se metoden kvadrat længere nede i koden)
            Console.WriteLine($"Kvadrat : {kvadrat(2)}");

            //delegaten delKvadrat peger på metoden kvadrat 
            delInt1par delKvadrat = kvadrat;

            //kalder metoden kvadrat gennem delegaten delKvadrat
            Console.WriteLine($"delKvadrat : {delKvadrat(2)}"); 

            //anonym metode som gør det samme som kvadrat metoden 
            //og som tildeles delegaten delKvadratAnonym
            delInt1par delKvadratAnonym = delegate(int x)
            {
                return x*x;
            };
            Console.WriteLine("delkvadrat : " + delKvadratAnonym (2));

            //anonym metode skrevet via Lamda syntax og som tildeles delegaten
            //delKvadratLamda
            delInt1par delKvadratLamda = x => x*x;
            Console.WriteLine($"delKvadrat lamda : {delKvadratLamda(2)}" );

            //Istedet for at bruge min egen delegate delInt1par kan jeg bruge
            //en forud defineret delegate Func, så derfor skal jeg bruge den.
            Func<int, int> funcDelegate = x => x * x;
            Console.WriteLine($"funcDelegate: {funcDelegate(2)}");


            //Her skal du selv arbejde med delegates, anonyme metoder og Lamda udtryk

            //Opgave 1: 
            // Test dine kald til metoder og delegates vha. Console.Writeline
            //-kod en delegate som kan pege på metoden "gtrThan100" :   private static bool gtrThan100(int x) 
            //-brug denne delegate og få den til at pege på metoden gtrThan100
            //-brug delegaten til at kode en anonym metode som gør det samme som metoden gtrThan100
            //-brug delegaten til at kode et lambda expression som gør det samme som  gtrThan100
            //-hvilken predefineret delagate kan du bruge istedet for din egen delegate -prøv at bruge den med et Lamda expression
            delBool1par delgT100 = gtrThan100;
            Console.WriteLine($"delgT100 : {delgT100}");

            delBool1par delgTAnonym = delegate(int x)
            {
                return x > 100;
            };
            Console.WriteLine("delgT100 : " + delgTAnonym);

            delBool1par delgTLamda = x => x > 100;
            Console.WriteLine($"delgT100 lamda : {delgTLamda}");

            Func<int, bool> funcDelegate100 = x => x > 100;
            Console.WriteLine($"funcDelegate100: {funcDelegate100}");
            //Opgave2:
            //gør det samme som ovenstående opgave , nu bare med metoden "gange":  private static int gange(int x, int y)
            delGange2par delGange2 = gange;
            Console.WriteLine($"delGange2 : {delGange2(2, 5)}");
            delGange2par delGangeAnonym = delegate(int x, int y)
            {
                return x * y;
            };
            Console.WriteLine("delGange2 : " + delGangeAnonym);

            delGange2par delGangeLamda = (x,y) => x * y;
            Console.WriteLine($"delGange2 lamda : {delGange2(2,5)}");

            Func<int, int, int> funcDelegateGange = (x, y) => x * y;
            Console.WriteLine($"funcDelegateGange: {funcDelegateGange(2,5)}");
        }


        /// <summary>
        /// Giver kvadratet på et tal
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int kvadrat(int x)
        {
            return x * x;
        }

        /// <summary>
        /// tester for om x er større end 100
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static bool gtrThan100(int x)
        {
            return x > 100;
        }

        /// <summary>
        /// ganger x og y sammen
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int gange(int x, int y)
        {
            return x*y;

        }


    }
}
