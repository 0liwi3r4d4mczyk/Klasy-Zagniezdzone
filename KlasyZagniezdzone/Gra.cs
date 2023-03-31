using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyZagniezdzone
{
    internal class Gra
    {
        Postac postac1 = new("Postac1", Postac.WylosujPlec());
        Postac postac2 = new("Postac2", Postac.WylosujPlec());

        public void RozpocznijRozgrywke()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLosowanie Ekwipunkow");
            Console.ForegroundColor = ConsoleColor.White;

            postac1.ekwipunek.WylosujEkwipunek();
            postac2.ekwipunek.WylosujEkwipunek();

            Console.WriteLine(postac1.ToString());
            Console.WriteLine(postac2.ToString());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nWcisij Enter aby przejsc dalej");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();

            Rozgrywka();
        }
        public void Rozgrywka()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSprawdzanie kto ma lepszy ekwipunek");
            Console.ForegroundColor = ConsoleColor.White;

            if (postac1.ekwipunek.miecz != 0 && postac2.ekwipunek.miecz == 0 && postac1.ekwipunek.zbroja != postac2.ekwipunek.miecz)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPostac {postac1.nazwa} zdobywa 10 punktow");
                Console.ForegroundColor = ConsoleColor.White;
                postac1.ZmienPoziom(10);
                postac2.ekwipunek.WylosujEkwipunek();
            }
            else if(postac1.ekwipunek.miecz == 0 && postac2.ekwipunek.miecz != 0 && postac2.ekwipunek.zbroja != postac1.ekwipunek.miecz)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPostac {postac2.nazwa} zdobywa 10 punktow");
                Console.ForegroundColor = ConsoleColor.White;
                postac2.ZmienPoziom(10);
                postac1.ekwipunek.WylosujEkwipunek();
            }
            else
            {
                if (postac1.ekwipunek.miecz > postac2.ekwipunek.miecz && postac1.poziom > postac2.poziom)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nPostac {postac1.nazwa} zdobywa 10 punktow");
                    Console.ForegroundColor = ConsoleColor.White;
                    postac1.ZmienPoziom(10);
                    postac2.ekwipunek.WylosujEkwipunek();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nPostac {postac2.nazwa} zdobywa 10 punktow");
                    Console.ForegroundColor = ConsoleColor.White;
                    postac2.ZmienPoziom(10);
                    postac1.ekwipunek.WylosujEkwipunek();
                }
            }


            Console.WriteLine(postac1.ToString());
            Console.WriteLine(postac2.ToString());



            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nCzy chesz grac dalej? Y/N");
            Console.ForegroundColor = ConsoleColor.White;

            string input = Console.ReadLine();

            if (input == "Y")
                Rozgrywka();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Zakanczanie Rozgrywki");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
