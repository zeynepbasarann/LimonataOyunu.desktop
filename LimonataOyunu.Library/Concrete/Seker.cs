//AD:ZEYNEP
//SOYAD:BAŞARAN
//NO:B211200378
//DERS:NESNEYE DAYALI PROGRAMLAMA
//ÖDEV:PROJE/1

using LimonataOyunu.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimonataOyunu.Library.Concrete
{
   internal class Seker:Cisim
    {
        private readonly Random Random1 = new Random();

        public Seker(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            HareketMesafesi = (int)(Height * .1);
            Left = Random1.Next(hareketAlaniBoyutlari.Width - Width + 1);
        }
        public bool YakalandiMi(Asci asci)
        {

            var yakalandiMi = asci.Top < Bottom && asci.Right > Left && asci.Left < Right;
            if (yakalandiMi) return true;


            return false;
        }
    }
}
