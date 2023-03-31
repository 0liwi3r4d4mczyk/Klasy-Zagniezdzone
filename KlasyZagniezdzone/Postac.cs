using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KlasyZagniezdzone
{
    public class Postac
    {
        public string nazwa;
        public Plec plec;
        public int poziom;
        public Ekwipunek ekwipunek;
        Random rand = new();
        public Postac(string nazwa, Plec plec)
        {
            this.nazwa = nazwa;
            this.plec = plec;
            if (plec == Plec.kobieta)
                poziom = rand.Next(100, 150);
            else
                poziom = rand.Next(120, 170);
            ekwipunek = new();
        }

        public void ZmienPoziom(int poziom)
        {
            this.poziom += poziom;
            ekwipunek.UlepszEkwipunek(poziom);
        }

        public static Plec WylosujPlec()
        {
            Random rand = new();
            int value = rand.Next(0, 2);

            if (value == 1)
                return Plec.kobieta;
            else
                return Plec.mezczyzna;
        }
        public enum Plec
        {
            kobieta = 1,
            mezczyzna = 2
        }

        public override string ToString()
        {
            return
                "\nNazwa: " + nazwa +
                "\nPlec: " + plec +
                "\nPoziom: " + poziom +
                "\nEkwipunek: " + ekwipunek.ToString();
        }


        public class Ekwipunek
        {

            public RodzajWyposazenia miecz = 0;
            public RodzajWyposazenia zbroja = 0;
            Array rodzajeWyposazenia = Enum.GetValues(typeof(RodzajWyposazenia));

            public void UlepszEkwipunek(int poziom)
            {
                if (poziom < 130)
                {
                    if(miecz < RodzajWyposazenia.drewno)
                        miecz = RodzajWyposazenia.drewno;

                    if(zbroja < RodzajWyposazenia.drewno)
                        zbroja = RodzajWyposazenia.drewno;
                }
                else if (poziom >= 130 && poziom < 150)
                {
                    if (miecz < RodzajWyposazenia.zloto)
                        miecz = RodzajWyposazenia.zloto;

                    if (zbroja < RodzajWyposazenia.zloto)
                        zbroja = RodzajWyposazenia.zloto;
                }
                else if (poziom >= 150 && poziom < 170)
                {
                    if (miecz < RodzajWyposazenia.stal)
                        miecz = RodzajWyposazenia.stal;

                    if (zbroja < RodzajWyposazenia.stal)
                        zbroja = RodzajWyposazenia.stal;
                }
                else if (poziom >= 170 && poziom < 190)
                {
                    if (miecz < RodzajWyposazenia.platyna)
                        miecz = RodzajWyposazenia.platyna;

                    if (zbroja < RodzajWyposazenia.platyna)
                        zbroja = RodzajWyposazenia.platyna;
                }
                else if (poziom >= 190 && poziom < 220)
                {
                    if (miecz < RodzajWyposazenia.tytan)
                        miecz = RodzajWyposazenia.tytan;

                    if (zbroja < RodzajWyposazenia.tytan)
                        zbroja = RodzajWyposazenia.tytan;
                }
            }

            public void WylosujEkwipunek()
            {
                Random rand = new();
                int value = rand.Next(0, 2);
                if (value == 0)
                    miecz = (RodzajWyposazenia)
                        rodzajeWyposazenia.GetValue(
                            rand.Next(1, 
                            Enum.GetNames(typeof(RodzajWyposazenia)).Length));
                else
                    zbroja = (RodzajWyposazenia)
                        rodzajeWyposazenia.GetValue(
                            rand.Next(1, 
                            Enum.GetNames(typeof(RodzajWyposazenia)).Length));

            }

            public override string ToString()
            {
                return
                    "\nMiecz: " + miecz +
                    "\nZbroja: " + zbroja;
            }
            public enum RodzajWyposazenia
            {
                brak = 0,
                drewno = 1,
                zloto = 2,
                stal = 3,
                platyna = 4,
                tytan = 5,
            }
        }
    }
}
