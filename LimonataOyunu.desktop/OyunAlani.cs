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
    public partial class OyunAlani : Form
    {
        //Labellardaki yazıları değiştirebilmek için oluşturulan değişkenler:
        private readonly Oyun _oyun ;
        public string oyuncuAd;
        public string kalanLabel;
        public string suretextBox;
        


        public OyunAlani()
        {
            InitializeComponent();
            _oyun = new Oyun(OyunAlaniPanel);
            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
            
        }

        private void OyunAlani_KeyDown(object sender, KeyEventArgs e)
        {
            //Klavyede basılan tuşa göre yapılacak işlemin çağrılması
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _oyun.Baslat();
                    _oyun.ZamanlayicilariBaslat();
                    break;
                case Keys.Right:
                    _oyun.AsciHaraketEttir(Yon.Saga);
                    
                    break;
                case Keys.Left:
                    _oyun.AsciHaraketEttir(Yon.Sola);
                    break;
                case Keys.P:
                    _oyun.ZamanlayicilariDurdur();
                    
                    
                    break;
            }
        }
        private void Oyun_GecenSureDegisti(object sender, EventArgs e)
        {
            int a = 0;
            //Labellardaki yazının oyun oynandıkça değişmesi:
            SureLabel.Text = _oyun.GecenSure.ToString(@"ss");            
            SkorLabel.Text = _oyun.skor.ToString();
            LimonLabel.Text = _oyun.LimonSayisi.ToString();
            SekerLabel.Text = _oyun.SekerSayisi.ToString();
            SuLabel.Text = _oyun.SuSayisi.ToString();
            
            int x = Convert.ToInt32(SureLabel.Text);
            int y = Convert.ToInt32(suretextBox);
            
            //Oyuncunun girmiş olduğu sürenin ve yapılacak limonata sayısının tamamlanıp tamamlanmadığının kontrolü:
            if (x == y)
            {
                
                int z = Convert.ToInt32(KalanLabel.Text);
                if (z == 0)
                {
                    _oyun.Bitir();
                           
                    MessageBox.Show("TEBRİKLER KAZANDINIZ...");
                    
                    Close();
                }
                else
                {
                    _oyun.Bitir();
                    MessageBox.Show("KAYBETTİNİZ...");
                  
                    Close();

                }
            }
            if (_oyun.SekerSayisi >= 1 && _oyun.LimonSayisi >= 3 && _oyun.SuSayisi >= 3)
            {
                _oyun.SekerSayisi -= 1;
                _oyun.LimonSayisi -= 3;
                _oyun.SuSayisi -= 3;

                a = Convert.ToInt32(KalanLabel.Text) - 1;
                if (a == 0)
                {
                    _oyun.Bitir();
                    MessageBox.Show("TEBRİKLER KAZANDINIZ...");
                   
                    Close();
                }

                KalanLabel.Text = a.ToString();




            }


        }
      

        private void OyunAlani_Load(object sender, EventArgs e)
        {
            AdLabel.Text = oyuncuAd;
            //Oynayan kişinin adının yakalanması:
            FileStream fs = new FileStream(@"C:\Users\zeyne\source\repos\LimonataOyunu.desktop\LimonataOyunu.Library\Adlar.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(oyuncuAd);
            sw.Close();
            KalanLabel.Text = kalanLabel;
            
        }
       
    }
}
