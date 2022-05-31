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
    internal class Biber : Cisim
    {
        private readonly Random Random4 = new Random();

        //konumu ve haraket mesafesinin ayarlanması
        public Biber(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {

            HareketMesafesi = (int)(Height * .1);
            Left = Random4.Next(hareketAlaniBoyutlari.Width - Width + 1);
        }
        //yakalanıp yakalanmadığının kontrolü
        public bool YakalandiMi(Asci asci)
        {

            var yakalandiMi = asci.Top < Bottom && asci.Right > Left && asci.Left < Right;
            if (yakalandiMi) return true;


            return false;
        }
      

    }
}
