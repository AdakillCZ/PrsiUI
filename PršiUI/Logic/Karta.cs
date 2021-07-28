using System;
using System.Collections.Generic;
using System.Text;

namespace Prší
{
    public class Karta
    {
        public const string ZELENA = "zelená";
        public const string ZALUDOVA = "žaludová";
        public const string CERVENA = "červená";
        public const string KULOVA = "kulová";

        public const int ESO = 14;
        public const int SEDMICKA = 7;
        public const int SVRSEK = 12;

        public static readonly string[] BARVY = {ZELENA, ZALUDOVA, CERVENA, KULOVA};

        public int cislo;
        public string druh;
        
        // public List<Karta> Karty = new List<Karta>();
        public List<Karta> Inventar1 = new List<Karta>();
        public List<Karta> Inventar2 = new List<Karta>();

        public Karta(int cislo, string druh)
        {
            this.cislo = cislo;
            this.druh = druh;
        }
        public Karta()
        {

        }

        public static List<Karta> GeneraceKaret()
        {

            List<Karta> inicializovanyBalicek = new List<Karta>();
          

            inicializovanyBalicek.Add(new Karta(7,ZALUDOVA));
            inicializovanyBalicek.Add(new Karta(8, ZALUDOVA));
            inicializovanyBalicek.Add(new Karta(9, ZALUDOVA));
            inicializovanyBalicek.Add(new Karta(10, ZALUDOVA));
            inicializovanyBalicek.Add(new Karta(11, ZALUDOVA));
            inicializovanyBalicek.Add(new Karta(12, ZALUDOVA));
            inicializovanyBalicek.Add(new Karta(13, ZALUDOVA));
            inicializovanyBalicek.Add(new Karta(14, ZALUDOVA));

            inicializovanyBalicek.Add(new Karta(7, CERVENA));
            inicializovanyBalicek.Add(new Karta(8, CERVENA));
            inicializovanyBalicek.Add(new Karta(9, CERVENA));
            inicializovanyBalicek.Add(new Karta(10, CERVENA));
            inicializovanyBalicek.Add(new Karta(11, CERVENA));
            inicializovanyBalicek.Add(new Karta(12, CERVENA));
            inicializovanyBalicek.Add(new Karta(13, CERVENA));
            inicializovanyBalicek.Add(new Karta(14, CERVENA));

            inicializovanyBalicek.Add(new Karta(7, ZELENA));
            inicializovanyBalicek.Add(new Karta(8, ZELENA));
            inicializovanyBalicek.Add(new Karta(9, ZELENA));
            inicializovanyBalicek.Add(new Karta(10, ZELENA));
            inicializovanyBalicek.Add(new Karta(11, ZELENA));
            inicializovanyBalicek.Add(new Karta(12, ZELENA));
            inicializovanyBalicek.Add(new Karta(13, ZELENA));
            inicializovanyBalicek.Add(new Karta(14, ZELENA));

            inicializovanyBalicek.Add(new Karta(7, KULOVA));
            inicializovanyBalicek.Add(new Karta(8, KULOVA));
            inicializovanyBalicek.Add(new Karta(9, KULOVA));
            inicializovanyBalicek.Add(new Karta(10, KULOVA));
            inicializovanyBalicek.Add(new Karta(11, KULOVA));
            inicializovanyBalicek.Add(new Karta(12, KULOVA));
            inicializovanyBalicek.Add(new Karta(13, KULOVA));
            inicializovanyBalicek.Add(new Karta(14, KULOVA));

            return inicializovanyBalicek;
        }

        public override string ToString()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(SEDMICKA, "sedmicka");
            dic.Add(SVRSEK, "svrsek");
            dic.Add(11, "spodek");
            dic.Add(ESO, "eso");
            string result;

            if (dic.ContainsKey(cislo))
            {
                result = "Číslo: " + cislo + " " + dic[cislo] + " " + "Druh: " + druh + "\n";
            } else
            {
                result = "Číslo: " + cislo + " " + "Druh: " + druh + "\n";
            }
            return result;
        }
    }
}
