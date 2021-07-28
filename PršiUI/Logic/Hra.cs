using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Prší
{
    public class Hra
    {
        public List<Karta> balicek;
        public List<Hráč> hraci;
        public Karta aktualniKarta;
        private int pocetHracu;
        private int aktualniHracIndex;
        private string barvaPoSvrsku;
        public List<Karta> lizaciBalicek;
        public List<Karta> pouzityBalicek;
        public Random random;
        private int pocitadloSedmicek;
        public bool hracStal;
        public bool byloZahranoEsoAPredchoziHracStal;
        // Karta arrayList = new ArrayList {};



        public Hra(int pocetHracu)
        {
            this.balicek = Karta.GeneraceKaret();
            this.pocetHracu = pocetHracu;
            this.hraci = new List<Hráč>();
            this.lizaciBalicek = new List<Karta>();
            this.pouzityBalicek = new List<Karta>();
            this.random = new Random();
            this.aktualniHracIndex = 0;
            this.pocitadloSedmicek = 0;
            this.hracStal = false;
            this.barvaPoSvrsku = "";
            this.byloZahranoEsoAPredchoziHracStal = false;
        }

        public void inicializujHru()
        {
            zamichejKarty();
            inicializujHrace();
            rozdejKarty();

        }

        /// <summary>
        /// Metoda pro kontrolu specialnich pripadu a vraceni prislusneho stringu do konzole
        /// </summary>
        /// <param name="aktualniHrac"></param>
        /// <param name="nastalPripad">vracici parametr pro to, jestli nastal specialni pripad</param>
        /// <param name="byloZahranoEso">vracici parametr pro to, jestli bylo zahrano eso</param>
        /// <returns>string pro konzoli</returns>
        public string Kontrola(Hráč aktualniHrac, out bool nastalPripad, out bool byloZahranoEso)
        {
            string vysledek = "";
            nastalPripad = false;
            byloZahranoEso = false;

            if (aktualniKarta.cislo == Karta.ESO && !hracStal)
            {
                vysledek = aktualniHrac.hracovyKarty.Count + " - Stojím, hraje další hráč\n";
                nastalPripad = true;
                byloZahranoEso = true;
                return vysledek;
            }

            if (aktualniKarta.cislo == Karta.SEDMICKA && !hracStal )
            {
                vysledek = aktualniHrac.hracovyKarty.Count + " - Lížu si dvě karty, hraje další hráč\n";
                nastalPripad = true;
                return vysledek;
            }

            vysledek += aktualniHrac.hracovyKarty.Count + " - " + "Líznout si\n";
            return vysledek;
        }

        /// <summary>
        /// Hlavni cyklus hry
        /// </summary>
        public void zacniHrat()
        {


            while (hraci.Count > 1)
            {
                Hráč hracNaTahu = hraci[aktualniHracIndex];
                bool nastalSpecialniPripad, byloZahranoEso;
                // Console.Clear();
                Console.WriteLine("------------Aktualni karta na stole-------");
                Console.WriteLine(aktualniKarta);
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Index aktualniho hrace: " + aktualniHracIndex);
                Console.WriteLine(hracNaTahu);
                Console.WriteLine(Kontrola(hracNaTahu, out nastalSpecialniPripad, out byloZahranoEso));
                int indexMoznosti = 0;
                try 
                {
                    indexMoznosti = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Spatne zadane cislo");
                    continue;
                }
   

                // osetreni STANI A SEDMICKY
                if (nastalSpecialniPripad && indexMoznosti == hracNaTahu.hracovyKarty.Count)
                {
                    if (byloZahranoEso && !hracStal)
                    {
                        aktualniHracIndex++;
                        aktualniHracIndex = aktualniHracIndex % (hraci.Count); // 5 hracu 0,1,2,3,4,   5 6 7 8 9 10
                        hracStal = true;
                        byloZahranoEsoAPredchoziHracStal = true;
                        continue;
                    }
                    else
                    {
                        hracStal = false;
                        // pro sedmicku 
                        hracNaTahu.pridejKartu(LiznutiKarty());
                        hracNaTahu.pridejKartu(LiznutiKarty());
                        aktualniHracIndex++;
                        aktualniHracIndex = aktualniHracIndex % (hraci.Count); // 5 hracu 0,1,2,3,4,   5 6 7 8 9 10
                        continue;
                    }
                }

                // kontrola, jestli hrac vybral, ze si lize - KLASICKY
                if (indexMoznosti == hracNaTahu.hracovyKarty.Count)
                {
                    hracNaTahu.pridejKartu(LiznutiKarty());
                    aktualniHracIndex++;
                    aktualniHracIndex = aktualniHracIndex % hraci.Count;
                    continue;
                }

                // navrati se karta, kterou chtel zahrat hrac - indexMoznosti
                Karta docasnaKarta = hracNaTahu.HracZahrajeSvujTah(indexMoznosti);

                
                if (barvaPoSvrsku.Length > 0)
                {
                    if (docasnaKarta.druh == barvaPoSvrsku)
                    {

                    }
                }

                if (aktualniKarta.cislo == Karta.ESO && !this.byloZahranoEsoAPredchoziHracStal)
                {
                    if (docasnaKarta.cislo == Karta.ESO)
                    {
                        pouzityBalicek.Add(aktualniKarta);
                        aktualniKarta = docasnaKarta;
                        hracNaTahu.HracZahrajeSvujTah(indexMoznosti);
                    }
                    else //if (docasnaKarta.cislo != Karta.ESO || docasnaKarta.cislo == 0)
                    {
                        Console.WriteLine("Stojíte!");
                        continue;
                        //Hráčův tah se neuskuteční
                    }
                }

                if (aktualniKarta.cislo == Karta.SEDMICKA)
                {
                    if (docasnaKarta.cislo == Karta.SEDMICKA)
                    {
                        pouzityBalicek.Add(aktualniKarta);
                        aktualniKarta = docasnaKarta;
                        hracNaTahu.HracZahrajeSvujTah(indexMoznosti);
                    }
                    else //if (docasnaKarta.cislo != Karta.SEDMICKA || docasnaKarta.cislo == 0)
                    {

                        Console.WriteLine("Stojíte!");
                        
                        //Hráčův tah se neuskuteční
                    }
                }

                if (docasnaKarta.cislo == Karta.SVRSEK)
                {
                    this.barvaPoSvrsku = BylZahranSvrsek();

                    hracNaTahu.HracSpravneOdehralTah(indexMoznosti);
                    aktualniHracIndex++;
                    aktualniHracIndex = aktualniHracIndex % (hraci.Count);
                    pouzityBalicek.Add(aktualniKarta);
                    aktualniKarta = docasnaKarta;

                }


                if (docasnaKarta.druh == aktualniKarta.druh || docasnaKarta.cislo == aktualniKarta.cislo)
                {
                    hracNaTahu.HracSpravneOdehralTah(indexMoznosti);
                    aktualniHracIndex++;
                    aktualniHracIndex = aktualniHracIndex % (hraci.Count);
                    pouzityBalicek.Add(aktualniKarta);
                    aktualniKarta = docasnaKarta;
                    byloZahranoEsoAPredchoziHracStal = false;
                }


            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void zamichejKarty()
        {
            for (int i = 0; i < 1000; i++)
            {
                int cisloKartyBalicku = random.Next(0, balicek.Count);
                int cisloKartyBalicku2 = random.Next(0, balicek.Count);

                if (cisloKartyBalicku != 0)
                {
                    Karta tempKarta = balicek[cisloKartyBalicku2];
                    balicek[cisloKartyBalicku2] = balicek[cisloKartyBalicku];
                    balicek[cisloKartyBalicku] = tempKarta;
                }
                else
                {
                    continue;
                }
            }
        }

        public override string ToString()
        {
            string s = "Počet hracu: " + this.hraci.Count + "\n";
            int i = 0;
            foreach (Hráč hrac in this.hraci)
            {
                s += i + " - " + hrac.ToString() + "\n";
                i++;
            }

            s += "*************";
            return s;
        }

        private void inicializujHrace()
        {
            for (int i = 0; i < this.pocetHracu; i++)
            {
                hraci.Add(new Hráč());
            }
        }


        private void rozdejKarty()
        {
            int indexKarty = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < this.pocetHracu; j++)
                {
                    hraci[j].pridejKartu(balicek[indexKarty]);


                    indexKarty++;
                }
            }
            aktualniKarta = balicek[indexKarty];
            pouzityBalicek.Add(aktualniKarta);

            for (int i = balicek.Count - 1; i > indexKarty; i--)
            {
                lizaciBalicek.Add(balicek[i]);
            }
            // hracovyKarty = balicek[0]
        }

        /// <summary>
        /// Lizani karty vcetne otoceni balicku po pouziti vsech karet
        /// </summary>
        /// <returns></returns>
        public Karta LiznutiKarty()
        {
            Karta liznutaKarta = null;
            if (lizaciBalicek.Count > 0)
            {
                liznutaKarta = lizaciBalicek[0];
                lizaciBalicek.Remove(liznutaKarta);
            }
            else
            {
                ResetBalicku();
                if (lizaciBalicek.Count > 0)
                {
                    liznutaKarta = lizaciBalicek[0];
                    lizaciBalicek.Remove(liznutaKarta);
                } else
                {
                    Console.WriteLine("Zadna dalsi karta nemuze byt liznuta, hra ukoncena.");
                    Console.WriteLine("**************************************************");
                    Console.WriteLine("                    Konec hry                     ");
                    Console.WriteLine("**************************************************");
                    Console.ReadLine();
                    Environment.Exit(0);
                }                
            }

            return liznutaKarta;
        }


        /// <summary>
        /// kdyz dojdou karty tak otocim balicek s kartama
        /// <see cref="Hra.lizaciBalicek"/>
        /// </summary>
        public void ResetBalicku()
        {
            foreach(Karta karta in pouzityBalicek)
            {
                lizaciBalicek.Add(karta);
            }

            this.pouzityBalicek.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public string BylZahranSvrsek()
        {
            Console.WriteLine("Zahrali jste svrska!!!");
            Console.WriteLine("**********************");
            int indexBarvy = 0;
            foreach (string barva in Karta.BARVY)
            {
                Console.WriteLine(indexBarvy + " - " + barva);
                indexBarvy++;
            }

            int vyberBarvy = -1;

            do
            {
                Console.WriteLine("Jakou barvu chcete zvolit?");
                try
                {
                    vyberBarvy = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Spatne zadane cislo");
                    Console.WriteLine("Jakou barvu chcete zvolit?");
                    vyberBarvy = -1;
                }

                if (vyberBarvy < 0 || vyberBarvy > Karta.BARVY.Length - 1)
                {
                    Console.WriteLine("Spatne zadane cislo");
                }
            } while (vyberBarvy < 0 || vyberBarvy > Karta.BARVY.Length - 1);

            // Console.WriteLine(Karta.BARVY[vyberBarvy]);

            return Karta.BARVY[vyberBarvy];
        }
    }
}
