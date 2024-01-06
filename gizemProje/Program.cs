using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gizemProje
{
    class Program
    {
        static List<Kategori> filmler = new List<Kategori>();

        static void Main()
        {
            
            string kullaniciAdi, sifre,rol;
            Console.Write("Kullanıcı Adınız = ");
            kullaniciAdi = Console.ReadLine();
            Console.Write("Şifreniz = ");
            sifre = sifreliyaz();
            rol = "Admin";
            Console.WriteLine("\n***************************\nKullanıcı Adınız = {0}\nŞifreniz = {1}\nrolünüz={2}\n***************************", kullaniciAdi, sifre,rol);

            while (true)
            {
                try
                {
                    Console.WriteLine("Film Listeleme ve Değerlendirme Programına Hoşgeldiniz!");
                    Console.WriteLine("Aradığınız işlemi seçiniz.");
                    Console.WriteLine("1. Film Ekle");
                    Console.WriteLine("2. Filmleri Listele");
                    Console.WriteLine("3. Değerlendirme Yaz");
                    Console.WriteLine("4. Kategoriye göre ara");
                    Console.WriteLine("5. Çıkış");
                    int secim = Convert.ToInt32(Console.ReadLine());
                    switch (secim)
                    {
                        case 1:
                            Kategori film = new Kategori();
                            Console.Write("Kategori Adı: ");
                            film.FilmTürü = Console.ReadLine();
                            film.FilmTürü.ToUpper();
                            Console.Write("Film Adı: ");
                            film.Adi = Console.ReadLine();
                            film.Adi.ToUpper();
                            Console.Write("Yıl: ");
                            film.Yil = Convert.ToInt32(Console.ReadLine());
                            double val = 0;
                            string sayi = "";
                            Console.Write("Puan: ");
                            ConsoleKeyInfo karakter;
                            do
                            {
                                karakter = Console.ReadKey(true);
                                if (karakter.Key != ConsoleKey.Backspace)
                                {
                                    bool kontrol = double.TryParse(karakter.KeyChar.ToString(), out val);
                                    if (kontrol)
                                    {
                                        sayi += karakter.KeyChar;
                                        Console.WriteLine(karakter.KeyChar);
                                    }
                                }
                                else
                                {
                                    if (karakter.Key == ConsoleKey.Backspace && sayi.Length > 0)
                                    {
                                        sayi = sayi.Substring(0, (sayi.Length - 1));
                                        Console.WriteLine("\b \b");
                                    }
                                }
                            }
                            while (karakter.Key != ConsoleKey.Enter);
                            film.Puan = Convert.ToDouble(sayi);
                            Console.Write("Yönetmen Adı: ");
                            film.Yönetmen = Console.ReadLine();
                            film.Yönetmen.ToUpper();
                            FilmEkle(film);
                            break;
                        case 2:
                            foreach (var item in filmler)
                            {
     
                                item.FilmBilgileriniGoster(item.FilmTürü);
                                Console.WriteLine("////////////////////////////////////////////////");
                            }
                            break;
                        case 3:
                            DeğerlendirmeYaz();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Kategori Giriniz: ");
                            string kategori = Console.ReadLine().ToUpper();
                            FilmAra(kategori);
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("HATA ALINDI: " + ex.Message);
                    Console.WriteLine("**************************");
                }
            }
        }
        private static string sifreliyaz()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.WriteLine("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }
        static void FilmAra(string kategori)
        {
            int index = 0;
            Console.WriteLine("Aradığınız kategorideki filmler listeleniyor...");
            Console.WriteLine("////////////////////////////////////////////////");
            foreach (var item in filmler)
            {
                if (item.FilmTürü.ToUpper() == kategori.ToUpper())
                {
                    index++;
                    Console.WriteLine(item.Adi + " - " + item.Puan);
                    Console.WriteLine("////////////////////////////////////////////////");
                }
            }
            if (index==0)
            {
                Console.WriteLine("Aradığınız kategoride bir film bulunamadı. Girdiğiniz Kategoriyi düzgün yazdığınızdan emin olun.");
            }
        }
        static void FilmEkle(Kategori film)
        {
            filmler.Add(film);
            Console.WriteLine("Film eklendi!");
            Console.WriteLine("////////////////////////////////////////////////");
        }

        static void DeğerlendirmeYaz()
        {
            Console.Write("Hangi film için değerlendirme yazacaksınız? (Film Adı): ");
            string filmAdi = Console.ReadLine(); 
            
            Film film = filmler.Find(f => f.Adi.Equals(filmAdi, StringComparison.OrdinalIgnoreCase));

            if (film != null)
            {
                Console.Write("Değerlendirme: ");
                string değerlendirme = Console.ReadLine();

                film.Degerlendirme = (değerlendirme);
                Console.WriteLine("Değerlendirmeniz için teşekkürler!");
                Console.WriteLine("////////////////////////////////////////////////");
            }
            else
            {
                Console.WriteLine("Film bulunamadı!");
            }
        }
    }
}
