//AD:ZEYNEP
//SOYAD:BAŞARAN
//NO:B211200378
//DERS:NESNEYE DAYALI PROGRAMLAMA
//ÖDEV:PROJE/1

using LimonataOyunu.Library.Concrete;
using LimonataOyunu.Library.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimonataOyunu.desktop
{
    public partial class AnaForm : Form
    {
        private Oyun _oyun;
        public AnaForm()
        {
            InitializeComponent();
            _oyun = new Oyun(OyunAlaniPanel);
        }

        public Panel OyunAlaniPanel { get; }

        private void Baslamabutton_Click(object sender, EventArgs e)
        {
            //oyun alanının olduğu formun açılması
            OyunAlani oyunAlani = new OyunAlani();
            oyunAlani.oyuncuAd = AdtextBox.Text;
            oyunAlani.kalanLabel =AdettextBox.Text;
            oyunAlani.suretextBox = SuretextBox.Text;
            oyunAlani.Show();            
            this.Hide();
            


        }

        //oyun bilgisinin gösterilmesi
        private void BilgiButton_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Başlamak için boşlukları doldurunuz ve butona tıklayınız.OyunAlanı açıldığında Enter tuşuna basınız. Sağ sol tuşlarını kullanarak aşçıyı haraket ettirebilir ve yukarıdan yağan malzemeleri toplayabilirsiniz.Bir adet limonata için 3 limon,3 su ve 2 şeker toplamalısınız.Bomba veya biber toplarsanız veya girdiğiniz sürede bitiremezseniz oyunu kaybedersiniz.Oyundaki sürpriz kutuyu toplarsanız kutunun -10 ile 50 arasındaki herhangi bir değerini skorunuza eklersiniz.");
            
        }
        //skorların gösterilmesi
        private void ScorButton_Click(object sender, EventArgs e)
        {
            TextReader tReader1 = new StreamReader(@"C:\Users\zeyne\source\repos\LimonataOyunu.desktop\LimonataOyunu.Library\Skorlar.txt");
            string okunan1 = tReader1.ReadToEnd();
            TextReader tReader2 = new StreamReader(@"C:\Users\zeyne\source\repos\LimonataOyunu.desktop\LimonataOyunu.Library\Adlar.txt");
            string okunan2 = tReader2.ReadToEnd();
            string[] skorlar = okunan1.Split('\n');
            string[] Adlar = okunan2.Split('\n');


           MessageBox.Show("Ad:" +Adlar[0] + "Skor:" + skorlar[0] + "\n" + "Ad:" + Adlar[1] + "Skor:" + skorlar[1] + "\n" + "Ad:" + Adlar[2] + "Skor:" + skorlar[2] + "\n" + "Ad:" + Adlar[3] + "Skor:" + skorlar[3] + "\n" + "Ad:" + Adlar[4] + "Skor:" + skorlar[4] + "\n" );
            
           
            

        }

        private void AnaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
