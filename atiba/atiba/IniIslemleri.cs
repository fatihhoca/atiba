using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atiba
{
    public static class IniIslemleri
    {
        //Sınıfımızı Extension Method olarak kullanmak istediğimiz için static tanımlıyoruz.

        static string dizinYolu = Application.StartupPath;
        static string dosyaAdi = dizinYolu + "\\ayarlar.ini";


        //Yazma işlemleri için gerekli olan dll'i import edip, ini için WritePrivateProfileString metodunun görüntüsünü aldık
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string kategori, string anahtar, string deger, string dosyaAdi);


        //Yazma işlemleri için gerekli olan dll'i import edip, ini için GetPrivateProfileString metodunun görüntüsünü aldık
        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string kategori, string anahtar, string lpDefault, StringBuilder sb, int sbKapasite, string dosyaAdi);

        public static bool VeriYaz(string kategori, string anahtar, string deger)
        {
            if (!Directory.Exists(dizinYolu)) //Dizin yoksa oluşturalım.
                Directory.CreateDirectory(dizinYolu);

            return WritePrivateProfileString(kategori, anahtar, deger, dosyaAdi);
        }

        public static string VeriOku(string kategori, string anahtar)
        {
            //Okunacak veriyi okumak ve kapasitesini sınırlandırmak ve performans için StringBuilder sınıfını kullanıyoruz.
            StringBuilder sb = new StringBuilder(500);

            GetPrivateProfileString(kategori, anahtar, "", sb, sb.Capacity, dosyaAdi);

            string veri = sb.ToString();
            sb.Clear();
            return veri;
        }
    }

}