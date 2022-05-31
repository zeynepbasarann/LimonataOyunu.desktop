//AD:ZEYNEP
//SOYAD:BAŞARAN
//NO:B211200378
//DERS:NESNEYE DAYALI PROGRAMLAMA
//ÖDEV:PROJE/1

using LimonataOyunu.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;



namespace LimonataOyunu.Library.Concrete
{
    internal class Limon : Cisim
    {
        private readonly Random Random2 = new Random();
        //konumunun ve haraket mesafesinin ayarlanması
        public Limon(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            
            HareketMesafesi = (int)(Height * .1);
            Left = Random2.Next(hareketAlaniBoyutlari.Width - Width + 1);
        }

        

        public bool YakalandiMi(Asci asci)
        {
           
                var yakalandiMi = asci.Top < Bottom && asci.Right > Left && asci.Left < Right;
                if (yakalandiMi) return true;
            

            return false;
        }
    }
}