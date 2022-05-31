//AD:ZEYNEP
//SOYAD:BAŞARAN
//NO:B211200378
//DERS:NESNEYE DAYALI PROGRAMLAMA
//ÖDEV:PROJE/1

using LimonataOyunu.Library.Enum;
using LimonataOyunu.Library.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using LimonataOyunu.Library.Abstract;
using System.IO;

namespace LimonataOyunu.Library.Concrete
{
    public class Oyun : IOyun
    {
        
        //Timerların çalışma süresinin ayarlanması:
        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _limonOlusturmaTimer = new Timer { Interval = 4500 };
        private readonly Timer _suOlusturmaTimer = new Timer { Interval = 2800};
        private readonly Timer _sekerOlusturmaTimer = new Timer { Interval = 6300 };
        private readonly Timer _bombaOlusturmaTimer = new Timer { Interval = 6900 };
        private readonly Timer _biberOlusturmaTimer = new Timer { Interval = 5400 };
        private readonly Timer _kutuOlusturmaTimer = new Timer { Interval = 10000 };






        private TimeSpan _gecenSure;
        private readonly Panel _oyunalanipanel;

        private  Asci _asci;
        private readonly List<Limon> _limonlar = new List<Limon>();
        private readonly List<Su> _sular = new List<Su>();
        private readonly List<Seker> _sekerler = new List<Seker>();
        private readonly List<Bomba> _bombalar = new List<Bomba>();
        private readonly List<Biber> _biberler = new List<Biber>();
        private readonly List<Kutu> _kutular = new List<Kutu>();

        //malzeme toplamak için gerekli değişkenler
        public int  LimonSayisi=0;
        public int SuSayisi = 0;
        public int SekerSayisi = 0;
        public int skor = 0;
        public int kalan = 0;
        

        

        public event EventHandler GecenSureDegisti;


        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;

                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

       

        public Oyun(Panel oyunalaniPanel)
        {
            //timerların tick olayıyla ilişkilendirilmesi
            _oyunalanipanel = oyunalaniPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;
            _limonOlusturmaTimer.Tick += LimonOlusturmaTimer_Tick;
            _suOlusturmaTimer.Tick += SuOlusturmaTimer_Tick;
            _sekerOlusturmaTimer.Tick += SekerOlusturmaTimer_Tick;
            _bombaOlusturmaTimer.Tick += BombaOlusturmaTimer_Tick;
            _biberOlusturmaTimer.Tick +=BiberOlusturmaTimer_Tick;
            _kutuOlusturmaTimer.Tick += KutuOlusturmaTimer_Tick;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
            if ((_gecenSure.TotalSeconds)%20==0)
            {
                _hareketTimer.Interval -= 30;
                _bombaOlusturmaTimer.Interval -= 1500;
                _limonOlusturmaTimer.Interval -= 1200;
                _sekerOlusturmaTimer.Interval -= 1500;
                _suOlusturmaTimer.Interval -= 500;
                _biberOlusturmaTimer.Interval -= 1500;
            }
           
        }

        //haraket edecek nesnelerin haraketinin başlaması
        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            
            SekerleriHaraketEttir();
            KutulariHaraketEttir();
            LimonlariHareketEttir();
            SulariHareketEttir();
            BombalariHaraketEttir();
            BiberleriHaraketEttir();
            YakalananLimonlariCikar();
            YakalananSekerleriCikar();
            YakalananSulariCikar();
            YakalananBombalariCikar();
            YakalananBiberleriCikar();
            YakalananKutulariCikar();




        }
        //Yakalanan malzemelerin çıkartılması
        private void YakalananLimonlariCikar()
        {
            for (var i = _limonlar.Count - 1; i >= 0; i--)
            {
                var limon = _limonlar[i];

                var vuranAsci = limon.YakalandiMi(_asci);
                
                if (!vuranAsci)
                {
                    if (_limonlar[i].Bottom == _oyunalanipanel.Bottom)
                    {
                        _limonlar.Remove(limon);

                        _oyunalanipanel.Controls.Remove(limon);
                    }
                    else continue;

                }
                if (vuranAsci)
                {
                    LimonSayisi++;
                    skor += 10;
                }
                

                _limonlar.Remove(limon);
                _oyunalanipanel.Controls.Remove(limon);
                
                    

                    



                }
            }
        private void YakalananKutulariCikar()
        {
            for (var i = _kutular.Count - 1; i >= 0; i--)
            {
                var kutu = _kutular[i];

                var vuranAsci = kutu.YakalandiMi(_asci);

                if (!vuranAsci)
                {
                    if (_kutular[i].Bottom == _oyunalanipanel.Bottom)
                    {
                        _kutular.Remove(kutu);

                        _oyunalanipanel.Controls.Remove(kutu);
                    }
                    else continue;

                }
                if (vuranAsci)
                {
                    Random rastgele = new Random();
                    int sayi = rastgele.Next(-10,50);
                    skor += sayi;
                }


                _kutular.Remove(kutu);
                _oyunalanipanel.Controls.Remove(kutu);
                






            }
        }
        private void YakalananBiberleriCikar()
        {
            for (var i = _biberler.Count - 1; i >= 0; i--)
            {
                var biber = _biberler[i];

                var vuranAsci = biber.YakalandiMi(_asci);
                if (!vuranAsci)
                {
                    if (_biberler[i].Bottom == _oyunalanipanel.Bottom)
                    {
                        _biberler.Remove(biber);

                        _oyunalanipanel.Controls.Remove(biber);
                    }
                    else continue;
                }
                if (vuranAsci)
                {
                    skor -= 10;
                }

                _biberler.Remove(biber);
                
                _oyunalanipanel.Controls.Remove(biber);
                
                

            }
        }
        private void YakalananSekerleriCikar()
        {
            for (var i = _sekerler.Count - 1; i >= 0; i--)
            {
                var seker = _sekerler[i];

                var vuranAsci = seker.YakalandiMi(_asci);
                if (!vuranAsci)
                {
                    if (_sekerler[i].Bottom == _oyunalanipanel.Bottom)
                    {
                        _sekerler.Remove(seker);

                        _oyunalanipanel.Controls.Remove(seker);
                    }
                    else continue;
                }
                if (vuranAsci)
                {
                    skor += 10;
                    SekerSayisi++;
                }

                _sekerler.Remove(seker);
                   _oyunalanipanel.Controls.Remove(seker);
                
               
                


                }
            }
        

        private void YakalananSulariCikar()
        {
            for (var i = _sular.Count - 1; i >= 0; i--)
            {
                var su = _sular[i];

                var vuranAsci = su.YakalandiMi(_asci);
                if (!vuranAsci)
                {
                    if (_sular[i].Bottom == _oyunalanipanel.Bottom)
                    {
                        _sular.Remove(su);

                        _oyunalanipanel.Controls.Remove(su);
                    }
                    else continue;
                }
                if (vuranAsci)
                {
                    skor += 10;
                    SuSayisi++;
                }


                _sular.Remove(su);

                    _oyunalanipanel.Controls.Remove(su);
                
                
                


                }
            }
        

            private void YakalananBombalariCikar()
            {
                for (var i = _bombalar.Count - 1; i >= 0; i--)
                {
                    var bomba = _bombalar[i];

                    var vuranAsci = bomba.YakalandiMi(_asci);
                    if (!vuranAsci) {
                        if (_bombalar[i].Bottom == _oyunalanipanel.Bottom)
                        {
                            _bombalar.Remove(bomba);

                            _oyunalanipanel.Controls.Remove(bomba);
                        }
                        else continue;
                    }
                if (vuranAsci)
                {
                    skor -= 10;
                }



                _bombalar.Remove(bomba);
                
                _oyunalanipanel.Controls.Remove(bomba);
                
                }
            }

     
        //malzemelerin haraket ettirilmesi
        private void LimonlariHareketEttir()
        {
            foreach (var limon in _limonlar)
            {
                var carptiMi = limon.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;

                
            }
        }
        private void BombalariHaraketEttir()
        {
            foreach (var bomba in _bombalar)
            {
                var carptiMi = bomba.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;
                
            }
        }
        private void KutulariHaraketEttir()
        {
            foreach (var kutu in _kutular)
            {
                var carptiMi = kutu.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;

            }
        }
        private void BiberleriHaraketEttir()
        {
            foreach (var biber in _biberler)
            {
                var carptiMi = biber.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;

                
            }
        }
        private void SekerleriHaraketEttir()
        {
            foreach (var seker in _sekerler)
            {
                var carptiMi = seker.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;

                
            }
        }
        private void SulariHareketEttir()
        {
            foreach (var su in _sular)
            {
                var carptiMi =su.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;

                
            }
        }
        public void AsciHaraketEttir(Yon yon)
        {
            if (!DevamEdiyorMu) return;

            _asci.HareketEttir(yon);
        }
        //sürekli malzeme akışının sağlanması için timerlara malzeme oluşturulması
        private void LimonOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            LimonOlustur();
        }
        private void BiberOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            BiberOlustur();
        }
        private void BombaOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            BombaOlustur();
        }
        private void SekerOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            SekerOlustur();
        }
        private void SuOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            SuOlustur();
        }
        private void KutuOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            KutuOlustur();
        }




        //başlatma
        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;          
            ZamanlayicilariBaslat();
            AsciOlustur();
            LimonOlustur();
            SuOlustur();
            SekerOlustur();
            BombaOlustur();
            BiberOlustur();
            KutuOlustur();
        }
        //skorların skorlar text dosyasına yazdırılması
        public void skorYaz()
        {
            if (!DevamEdiyorMu)
            {
                FileStream fs = new FileStream(@"C:\Users\zeyne\source\repos\LimonataOyunu.desktop\LimonataOyunu.Library\Skorlar.txt",FileMode.Append,FileAccess.Write,FileShare.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(skor);
                
                sw.Close();
            }
        }
        //Nesne oluşturulması
        private void LimonOlustur()
        {
            var limon = new Limon(_oyunalanipanel.Size);
            _limonlar.Add(limon);
            _oyunalanipanel.Controls.Add(limon);
        }
        private void BombaOlustur()
        {
            var bomba = new Bomba(_oyunalanipanel.Size);
            _bombalar.Add(bomba);
            _oyunalanipanel.Controls.Add(bomba);
        }
        private void KutuOlustur()
        {
            var kutu = new Kutu(_oyunalanipanel.Size);
            _kutular.Add(kutu);
            _oyunalanipanel.Controls.Add(kutu);
        }
        private void BiberOlustur()
        {
            var biber = new Biber(_oyunalanipanel.Size);
            _biberler.Add(biber);
            _oyunalanipanel.Controls.Add(biber);
        }
        private void SekerOlustur()
        {
            var seker = new Seker(_oyunalanipanel.Size);
            _sekerler.Add(seker);
            _oyunalanipanel.Controls.Add(seker);
        }
        private void SuOlustur()
        {
            var su = new Su(_oyunalanipanel.Size);
            _sular.Add(su);
            _oyunalanipanel.Controls.Add(su);
        }
        private void AsciOlustur()
        {
            _asci = new Asci(_oyunalanipanel.Width, _oyunalanipanel.Height, _oyunalanipanel.Size);
            _oyunalanipanel.Controls.Add(_asci);
        }

        //zamanlayıcıların başlatılması
        public void ZamanlayicilariBaslat()
        {
            _gecenSureTimer.Start();
            _hareketTimer.Start();
            _limonOlusturmaTimer.Start();
            _suOlusturmaTimer.Start();
            _sekerOlusturmaTimer.Start();
            _biberOlusturmaTimer.Start();
            _bombaOlusturmaTimer.Start();
            _kutuOlusturmaTimer.Start();
        }
        //bitirme
        public void Bitir()
        {
            
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            skorYaz();
            ZamanlayicilariDurdur();
            

        }
        //tüm zamanlayıcıların durdurulması
        public void ZamanlayicilariDurdur()
        {
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _limonOlusturmaTimer.Stop();
            _suOlusturmaTimer.Stop();
            _sekerOlusturmaTimer.Stop();
            _bombaOlusturmaTimer.Stop();
            _biberOlusturmaTimer.Stop();
            _kutuOlusturmaTimer.Stop();
        }



        
        

       
    }
    }
