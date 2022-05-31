//AD:ZEYNEP
//SOYAD:BAŞARAN
//NO:B211200378
//DERS:NESNEYE DAYALI PROGRAMLAMA
//ÖDEV:PROJE/1

using LimonataOyunu.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimonataOyunu.Library.Interface
{
    internal interface IOyun
    {
        bool DevamEdiyorMu { get; }
        TimeSpan GecenSure { get; }
        event EventHandler GecenSureDegisti;
        void Baslat();
        void AsciHaraketEttir(Yon yon);
        

    }
}
