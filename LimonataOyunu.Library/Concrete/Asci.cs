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
using System.Windows.Forms;

namespace LimonataOyunu.Library.Concrete
{
    internal class Asci:Cisim
    {
        //aşçının haraketinin ve konumunun ayarlanması
        public Asci(int panelGenisligi, int panelYuksekligi, Size haraketAlaniBoyutlari):base(haraketAlaniBoyutlari)
        {
            HareketMesafesi = Width/2;
            Left = (panelGenisligi / 2);
            Bottom = (panelYuksekligi - 6) - Top;
        }

       
    }
}
