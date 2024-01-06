using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gizemProje
{
    public interface IFilm
    {
        string Adi { get; set; }
        int Yil { get; set; }
        double Puan { get; set; }
        string Yönetmen { get; set; }
        string Degerlendirme { get; set; }
        string Incelemeler { get; set; }
        string FilmTürü { get; set; }
        void FilmBilgileriniGoster(string filmTuru);
    }
}
