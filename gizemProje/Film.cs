using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gizemProje
{
    public class Film : IFilm
    {
        private string adi;
        private int yil;
        private double puan;
        private string yönetmen;
        private string degerlendirme;
        private string ıncelemeler;
        private string filmTürü;

        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }

        public int Yil
        {
            get { return yil; }
            set
            {
                if (value <= 2023)
                {
                    yil = value;
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir yıl giriniz.");
                    yil = 2023;
                }
            }
        }

        public double Puan
        {
            get { return puan; }
            set
            {
                if (value <= 10)
                {
                    puan = value;
                }
                else
                {
                    Console.WriteLine("Puan 0 ile 10 arasında olmalı");
                }
            }
        }

        public string Yönetmen
        {
            get { return yönetmen; }
            set { yönetmen = value; }
        }

        public string Degerlendirme
        {
            get { return degerlendirme; }
            set { degerlendirme = value; }
        }

        public string Incelemeler
        {
            get { return ıncelemeler; }
            set { ıncelemeler = value; }
        }

        public string FilmTürü
        {
            get { return filmTürü; }
            set { filmTürü = value; }
        }

        public void FilmBilgileriniGoster(string filmTuru)
        {
            Console.Clear();
            Console.WriteLine(Adi + "(" + Yil + ") - Puanı: " + Puan);
            Console.WriteLine("Kategorisi: " + filmTuru);
            Console.WriteLine("Yönetmeni:" + Yönetmen);
            Console.WriteLine("Değerlendirme:" + Degerlendirme);
        }
    }
}
