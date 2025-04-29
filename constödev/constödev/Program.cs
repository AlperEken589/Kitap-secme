using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace constödev
{
    
    //kitap kodları
    class kitap
    {
        public string Ad;
        public string Yazar;
        public int Sayfa;
        public kitap(string Ad , string Yazar , int Sayfa)
        {
            this.Ad = Ad;
            this.Yazar = Yazar;
            this.Sayfa = Sayfa;
        }
        public void Bilgigoster()
        {
            Console.WriteLine($"kitabın adı: {Ad} , kitabın yazarı {Yazar} , sayfa sayısı {Sayfa}");
        }

    }
    internal class Program
    {
        // statik yapma sebebi tüm nesnelerden alabilsin diye
        static List<kitap> kitaplar = new List<kitap>();
        static void Main(string[] args)
        {

            // kitap kodları
            while (true)
            {
                Console.WriteLine("1. Yeni Kitap Ekle");
                Console.WriteLine("2. Kitapları Listele");
                Console.WriteLine("3. Kitap Adına Göre Ara");
                Console.WriteLine("4. Çıkış");
                Console.Write("Seçiminizi yapın: ");
                int secim = int.Parse(Console.ReadLine());

                switch (secim)
                { 
                    case 1:
                        YeniKitapEkle();
                        break;
                    case 2:
                        KitaplariListele();
                        break;
                    case 3:
                        KitapAdinaGoreAra();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçenek, tekrar deneyin.");
                        break;
                }
            }


        }
        static void YeniKitapEkle()
        { 
            Console.Write("Kitap Adı: ");
            string ad = Console.ReadLine();
            Console.Write("Yazar: ");
            string yazar = Console.ReadLine();
            Console.Write("Sayfa Sayısı: ");
            int sayfaSayisi = int.Parse(Console.ReadLine());

            kitap yeniKitap = new kitap(ad, yazar, sayfaSayisi);
            kitaplar.Add(yeniKitap);
            Console.WriteLine("Yeni kitap başarıyla eklendi.");
        }
        static void KitaplariListele()
        {
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Listeye eklenmiş kitap yok.");
            }
            else
            {
                Console.WriteLine("\nKitaplar Listesi:");
                foreach (var kitap in kitaplar)
                {
                    kitap.Bilgigoster();
                }
            }
        }
        static void KitapAdinaGoreAra()
        {
            Console.Write("Aramak istediğiniz kitap adı: ");
            string arananAd = Console.ReadLine().ToLower();

            var bulunanKitaplar = kitaplar.FindAll(k => k.Ad.ToLower().Contains(arananAd));

            if (bulunanKitaplar.Count > 0)
            {
                Console.WriteLine("\nBulunan Kitaplar:");
                foreach (var kitap in bulunanKitaplar)
                {
                    kitap.Bilgigoster();
                }
            }
            else
            {
                Console.WriteLine("Kitap bulunamadı.");
            }
        }
    }
}
