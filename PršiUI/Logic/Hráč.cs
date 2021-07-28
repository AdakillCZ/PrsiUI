using System;
using System.Collections.Generic;
using System.Text;

namespace Prší
{
    public class Hráč
    {
        public List<Karta> hracovyKarty;

        public Hráč()
        {
            hracovyKarty = new List<Karta>();        
        }

        public Karta HracZahrajeSvujTah(int indexKartyNaRuce)
        {
            if (this.hracovyKarty != null || this.hracovyKarty.Count > 0 || indexKartyNaRuce < this.hracovyKarty.Count)
            {
                Karta zahranaKarta = this.hracovyKarty[indexKartyNaRuce];
                // this.hracovyKarty.RemoveAt(indexKartyNaRuce);
                
                return zahranaKarta;
            } else
            {
                return null;
            }
             
        }

        public void HracSpravneOdehralTah(int index)
        {
            this.hracovyKarty.RemoveAt(index);
        }


        public void pridejKartu(Karta karta)
        {
            hracovyKarty.Add(karta);
        }

        public override string ToString()
        {
            string s = "Počet karet: " + this.hracovyKarty.Count + "\n";
            int i = 0;
            foreach (Karta karta in this.hracovyKarty)
            {
                s += i + " - " + karta.ToString() + "\n";
                i++;
            }
           
            s += "\n------------------------------------------";
            return s;
        }

        public static Hráč testivaciHrac(List<Karta> kartas)
        {
            Hráč p = new Hráč();

            for(int i = 0; i < 5; i++)
            {
                Random random = new Random();

                int l = random.Next(0, 20);

                p.pridejKartu(kartas[l]);

            }
            

            return p;
        }



    }
}
