using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;



namespace atiba
{
    public partial class Form1 : Form
    {
        IWebDriver eokul;

        public Form1()
        {
            InitializeComponent();
            //deneme
        }
        private static int endingRow;

        private static string[] ogr_list_Row = { "ad_soyad", "tcNo", "sinif", "foto", "veli", "uyruk", "cinsiyet", "dogumTarihi", "dogumYeri", "ciltNo", "mahalleKoy", "boy", "kilo", "tasima", "ozurluDev", "ozursuzDev" };
        private static string[] baba_list_Row = { "babaAdSoyad", "babaTcNo", "babaTel", "babaSO", "babaBA", "babaMezuniyet", "babaDT", "babaMslk" };
        private static string[] anne_list_Row = { "anneAdSoyad", "anneTcNo", "anneTel", "anneSO", "anneBA", "anneMezuniyet", "anneDT", "anneMslk" };
        public bool Checked(CheckedListBox myListBox,string[] list,string value )
        {
            int index = Array.IndexOf(list, value);
            

            return myListBox.GetItemChecked(index);

        }


            private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Öğrenci Listesini Aç";
                //Açılan Dialog Penceresine verilen isim.
                ofd.Filter = "All Files (*.*) | *.*";
                //Dosya seçiminde uzantılarda filtre uyguluyoruz.
                ofd.FilterIndex = 1;
                //Varsayılan filitre'yi 1. sırada olan uzantıyı atıyoruz.
                DialogResult dr = ofd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string DosyaYolu = ofd.FileName;
                    // seçilen dosyanın tüm yolunu verir
                    string DosyaAdi = ofd.SafeFileName;
                    // sçeilen dosyanın adını verir.

                    //pictureBox1.ImageLocation = DosyaYolu;


                    dataGridView1.Rows.Clear();


                    string name = "Sheet1";
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DosyaYolu + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    
                    OleDbConnection Con = new OleDbConnection(constr);
                    OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$]", Con);
                    Con.Open();

                    OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    if (data.Columns.IndexOf("Öğrenci No") != -1)
                    {
                        dataGridView1.Columns.Add("ogrNo", "Öğrenci No");

                        foreach (DataRow drx in data.Rows)
                        {
                            if (drx["Öğrenci No"].ToString() != "")
                            dataGridView1.Rows.Add(drx["Öğrenci No"].ToString());
                        }
                        dataGridView1.ReadOnly = false;
                        dataGridView1.Columns[0].Width = 100;
                        dataGridView1.ClearSelection();
                    }
                    else
                        MessageBox.Show("Seçtiğiniz EXCEL içinde Öğrenci No alanı tespit edilemedi\nTablonuzda Öğrenci No adlı bir sütun ve altında öğrenci numaraları olması yeterli","Öğrenci No Sütunu Yok",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    data.Dispose();
                    sda.Dispose();
                    Con.Dispose();
                    Con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tablo yüklenirken hata oluştu.\nTablonuzda Öğrenci No adlı bir sütun ve altında öğrenci numaraları olması yeterli\nAyrıca tablonuzdaki sayfa adı Sheet1 olmalı.\nLütfen kontrol ediniz.", "Hatalı Dosya", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            eokul = new ChromeDriver();
            eokul.Manage().Window.Maximize();
            eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/");
            
        }

        private void AddColumnToDataGridView(string columnName, string columnHeader)
        {
            bool hasColumn = false;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == columnName)
                {
                    hasColumn = true;
                    break;
                }
            }

            if (!hasColumn)
            {
                dataGridView1.Columns.Add(columnName, columnHeader);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {




            if (Checked(ogrenciListBox,ogr_list_Row,"ad_soyad"))
            {
                //dataGridView1.Columns.Add("ad", "Ad");
                AddColumnToDataGridView("ad", "Ad");
                AddColumnToDataGridView("soyad", "Soyad");

            }
            if (Checked(ogrenciListBox,ogr_list_Row, "tcNo"))
                AddColumnToDataGridView("tcNo", "TC");
            if (Checked(ogrenciListBox,ogr_list_Row, "sinif"))
                AddColumnToDataGridView("sinif", "Sınıf");
            if (Checked(ogrenciListBox,ogr_list_Row,"veli"))
                AddColumnToDataGridView("veli", "Veli");
            if (Checked(ogrenciListBox, ogr_list_Row, "uyruk"))
                AddColumnToDataGridView("uyruk", "Uyruğu");
            if (Checked(ogrenciListBox, ogr_list_Row, "cinsiyet"))
                AddColumnToDataGridView("cinsiyet", "Cinsiyeti");
            if (Checked(ogrenciListBox,ogr_list_Row,"dogumTarihi"))
                AddColumnToDataGridView("dogumTarihi", "Doğum Tarihi");
            if (Checked(ogrenciListBox,ogr_list_Row,"dogumYeri"))
                AddColumnToDataGridView("dogumYeri", "Doğum Yeri");
            if (Checked(ogrenciListBox,ogr_list_Row,"ciltNo"))
                AddColumnToDataGridView("ciltNo", "Cilt No");
            if (Checked(ogrenciListBox,ogr_list_Row,"mahalleKoy"))
                AddColumnToDataGridView("mahalleKoy", "Mahalle Köy");
            if (Checked(ogrenciListBox,ogr_list_Row,"boy"))
                AddColumnToDataGridView("boy", "Boy");
            if (Checked(ogrenciListBox,ogr_list_Row,"kilo"))
                AddColumnToDataGridView("kilo", "Kilo");
            if (Checked(ogrenciListBox,ogr_list_Row,"tasima"))
                AddColumnToDataGridView("tasima", "Taşıma");
            if (Checked(ogrenciListBox,ogr_list_Row,"ozurluDev"))
                AddColumnToDataGridView("ozurluDev", "Özürlü Dev.");
            if (Checked(ogrenciListBox,ogr_list_Row,"ozursuzDev"))
                AddColumnToDataGridView("ozursuzDev", "Özürsüz Dev.");

            if (Checked(babaListBox, baba_list_Row, "babaAdSoyad"))
                AddColumnToDataGridView("babaAdSoyad", "Baba");
            if (Checked(babaListBox, baba_list_Row, "babaTcNo"))
                AddColumnToDataGridView("babaTcNo", "Baba TC");
            if (Checked(babaListBox, baba_list_Row, "babaTel"))
                AddColumnToDataGridView("babaTel", "Baba Tel");
            if (Checked(babaListBox, baba_list_Row, "babaSO"))
                AddColumnToDataGridView("babaSO", "Baba Sağ/Ölü");
            if (Checked(babaListBox, baba_list_Row, "babaBA"))
                AddColumnToDataGridView("babaBA", "Baba Birlikte/Ayrı");
            if (Checked(babaListBox, baba_list_Row, "babaMezuniyet"))
                AddColumnToDataGridView("babaMezuniyet", "Baba Mezuniyet");
            if (Checked(babaListBox, baba_list_Row, "babaDT"))
                AddColumnToDataGridView("babaDT", "Baba Doğum Tarihi");
            if (Checked(babaListBox, baba_list_Row, "babaMslk"))
                AddColumnToDataGridView("babaMslk", "Baba Mesleği");

            if (Checked(anneListBox, anne_list_Row, "anneAdSoyad"))
                AddColumnToDataGridView("anneAdSoyad", "Anne");
            if (Checked(anneListBox, anne_list_Row, "anneTcNo"))
                AddColumnToDataGridView("anneTcNo", "Anne TC");
            if (Checked(anneListBox, anne_list_Row, "anneTel"))
                AddColumnToDataGridView("anneTel", "Anne Tel");
            if (Checked(anneListBox, anne_list_Row, "anneSO"))
                AddColumnToDataGridView("anneSO", "Anne Sağ/Ölü");
            if (Checked(anneListBox, anne_list_Row, "anneBA"))
                AddColumnToDataGridView("anneBA", "Anne Birlikte/Ayrı");
            if (Checked(anneListBox, anne_list_Row, "anneMezuniyet"))
                AddColumnToDataGridView("anneMezuniyet", "Anne Mezuniyet");
            if (Checked(anneListBox, anne_list_Row, "anneDT"))
                AddColumnToDataGridView("anneDT", "Anne Doğum Tarihi");
            if (Checked(anneListBox, anne_list_Row, "anneMslk"))
                AddColumnToDataGridView("anneMslk", "Anne Mesleği");

            IWebElement veri;
            Screenshot foto;
            IList<IWebElement> aranan;
            int satir = 0;
            string adSoyad, geciciVeri;
            DateTime start;
            //if (radioButton3.Checked == true) aihlGiris();

            if (satir != endingRow)
            {
                DialogResult result = MessageBox.Show("İşlem Kaldığı Yerden Devam Etsin Mi?", "Uyarı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    satir = endingRow;
                }
                else if (result == DialogResult.No)
                {
                    satir = 0;
                }
            }
            progressBar1.Maximum = dataGridView1.Rows.Count + 1;
            progressBar1.Value = satir;

            while (satir < dataGridView1.Rows.Count)
            {
                DataGridViewRow dr = dataGridView1.Rows[satir];
                progressBar1.Value++;
                try
                {                    
                    //**************ÖĞRENCİ BİLGİLERİ

                    if (radioButton1.Checked == true)
                    {
                        eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG01001.aspx");
                        bekle(50);
                        eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                        veri = eokul.FindElement(By.Id("OGRMenu1_txtTC"));
                        veri.SendKeys(dr.Cells["ogrNo"].Value.ToString());
                        eokul.FindElement(By.Id("OGRMenu1_btnAra")).Click();
                        bekle(50);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG00001.aspx");
                        bekle(50);
                        //eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                        veri = eokul.FindElement(By.Id("OGRMenu1_txtTCYeni"));
                        veri.SendKeys(dr.Cells["ogrNo"].Value.ToString());
                        eokul.FindElement(By.Id("btnOgrenciAra")).Click();
                        bekle(50);
                    }
                    else if (radioButton3.Checked == true)
                    {
                        try
                        {
                            veri = eokul.FindElement(By.Id("mdlOOO"));
                            veri.Click();
                        }
                        catch
                        {
                            eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG01001.aspx");
                        }
                        
                        veri = eokul.FindElement(By.Id("txtOkulNo"));
                        veri.SendKeys(dr.Cells["ogrNo"].Value.ToString());
                        veri = eokul.FindElement(By.Id("btnListele"));
                        veri.Click();
                        bekle(150);
                        eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
                        bekle(500);
                        eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
                        bekle(500);
                        Application.DoEvents();
                        aranan = eokul.FindElements(By.XPath("//i[@class='fas fa-folder']"));
                        aranan[0].Click();
                        bekle(50);
                    }
                    else if (radioButton4.Checked == true)
                    {
                        eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG01001.aspx");
                        bekle(50);
                        eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                        veri = eokul.FindElement(By.Id("OGRMenu1_txtTC"));
                        veri.SendKeys(dr.Cells["ogrNo"].Value.ToString());
                        eokul.FindElement(By.Id("OGRMenu1_btnAra")).Click();
                        bekle(50);
                    }



                    veri = eokul.FindElement(By.Id("txtAdi"));
                    adSoyad = veri.GetAttribute("value").ToString();
                    
                    if (adSoyad.Trim() != "")
                    {
                        if (Checked(ogrenciListBox,ogr_list_Row,"ad_soyad"))
                            {
                            dataGridView1.Rows[satir].Cells["ad"].Value = adSoyad;
                            veri = eokul.FindElement(By.Id("txtSoyadi"));
                            adSoyad = veri.GetAttribute("value").ToString();
                            dataGridView1.Rows[satir].Cells["soyad"].Value = adSoyad;
                        }
                        if (Checked(ogrenciListBox,ogr_list_Row,"tcNo"))
                        {
                            try
                            {
                                veri = eokul.FindElement(By.Id("txtKisiTCKimlikNo"));
                                dataGridView1.Rows[satir].Cells["tcNo"].Value = veri.GetAttribute("value").ToString();
                            }
                            catch { dataGridView1.Rows[satir].Cells["tcNo"].Value = "Hata"; }
                        }
                        if (Checked(ogrenciListBox,ogr_list_Row,"sinif"))
                        {
                            try
                            {
                                if (radioButton1.Checked == true)
                                    veri = eokul.FindElement(By.Id("IOMPageHeader1_lblSinif"));
                                else
                                    veri = eokul.FindElement(By.Id("OOMPageHeader1_lblSinif"));

                                dataGridView1.Rows[satir].Cells["sinif"].Value = veri.Text.ToString();
                            }
                            catch { dataGridView1.Rows[satir].Cells["sinif"].Value = "Hata"; }
                        }
                        if (Checked(ogrenciListBox, ogr_list_Row, "foto"))
                        {
                            string sinifi;
                            string nosu;
                            try
                            {
                                sinifi = dataGridView1.Rows[satir].Cells["sinif"].Value.ToString().Replace("/", "-");
                                nosu = dataGridView1.Rows[satir].Cells["ogrNo"].Value.ToString();

                                if (radioButton1.Checked == true)
                                {
                                    veri = eokul.FindElement(By.Id("IOMPageHeader1_imgOgrenciResim"));
                                }
                                else
                                {
                                    veri = eokul.FindElement(By.Id("OOMPageHeader1_imgOgrenciResim"));
                                }
                                foto = ((ITakesScreenshot)veri).GetScreenshot();
                                string yol = Application.StartupPath;
                                Directory.CreateDirectory(yol + "\\" + sinifi);
                                foto.SaveAsFile(yol + "\\" + sinifi + "\\" + nosu + ".jpg", ScreenshotImageFormat.Jpeg);


                            }
                            catch { sinifi = "Hata"; }



                        }
                        if (Checked(ogrenciListBox,ogr_list_Row,"veli"))
                        {
                            try
                            {
                                SelectElement se = new SelectElement(eokul.FindElement(By.Id("ddlVelisi")));

                                dataGridView1.Rows[satir].Cells["veli"].Value = se.SelectedOption.Text.ToString();
                            }
                            catch { dataGridView1.Rows[satir].Cells["veli"].Value = "Hata"; }
                        }

                        if (Checked(ogrenciListBox,ogr_list_Row,"uyruk") || Checked(ogrenciListBox, ogr_list_Row, "cinsiyet") || Checked(ogrenciListBox,ogr_list_Row,"dogumTarihi") || Checked(ogrenciListBox,ogr_list_Row, "dogumYeri") || Checked(ogrenciListBox,ogr_list_Row, "ciltNo"))
                        {
                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02003.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02003.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/OOG02003.aspx");

                            bekle(50);

                            gozleriAc(2);
                            if (Checked(ogrenciListBox, ogr_list_Row, "uyruk"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.XPath("//*[@id='uyruk']"));
                                    dataGridView1.Rows[satir].Cells["uyruk"].Value = veri.Text;
                                }
                                catch { dataGridView1.Rows[satir].Cells["uyruk"].Value = "Hata"; }
                            }
                            if (Checked(ogrenciListBox, ogr_list_Row, "cinsiyet"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.XPath("//*[@id='cinsiyet']"));
                                    dataGridView1.Rows[satir].Cells["cinsiyet"].Value = veri.Text;
                                }
                                catch { dataGridView1.Rows[satir].Cells["cinsiyet"].Value = "Hata"; }
                            }
                            if (Checked(ogrenciListBox,ogr_list_Row,"dogumTarihi"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("dogumTarihi"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["dogumTarihi"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["dogumTarihi"].Value = "Hata"; }
                            }
                            if (Checked(ogrenciListBox,ogr_list_Row,"dogumYeri"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("dogumYeri"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["dogumYeri"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["dogumYeri"].Value = "Hata"; }
                            }
                            if (Checked(ogrenciListBox,ogr_list_Row,"ciltNo"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("ciltNo"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["ciltNo"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["ciltNo"].Value = "Hata"; }
                            }
                            if (Checked(ogrenciListBox,ogr_list_Row,"mahalleKoy"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("nufusMahalle"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["mahalleKoy"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["mahalleKoy"].Value = "Hata"; }
                            }
                        }

                        if (Checked(ogrenciListBox,ogr_list_Row,"boy") || Checked(ogrenciListBox,ogr_list_Row, "kilo") || Checked(ogrenciListBox,ogr_list_Row, "tasima"))
                        {
                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/iog02002.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02002.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/OOG02002.aspx");

                            bekle(50);
                            if (Checked(ogrenciListBox,ogr_list_Row,"boy"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("txtBoy"));
                                    dataGridView1.Rows[satir].Cells["boy"].Value = veri.GetAttribute("value").ToString();                                   
                                }
                                catch { dataGridView1.Rows[satir].Cells["boy"].Value = "Hata"; }
                            }
                            if (Checked(ogrenciListBox,ogr_list_Row,"kilo"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("txtKilo"));
                                    dataGridView1.Rows[satir].Cells["kilo"].Value = veri.GetAttribute("value").ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["kilo"].Value = "Hata"; }
                            }
                            if (Checked(ogrenciListBox,ogr_list_Row,"tasima"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("chkTasimaPalanDahilmi"));

                                    if (veri.Selected == true)
                                        dataGridView1.Rows[satir].Cells["tasima"].Value = "Evet";
                                    else
                                        dataGridView1.Rows[satir].Cells["tasima"].Value = "Hayır";
                                }
                                catch { dataGridView1.Rows[satir].Cells["tasima"].Value = "Hata"; }
                            }
                        }

                        if (Checked(ogrenciListBox,ogr_list_Row,"ozurluDev") || Checked(ogrenciListBox,ogr_list_Row, "ozursuzDev"))
                        {
                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02015.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02015.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/OOG02015.aspx");

                            bekle(50);

                            if (Checked(ogrenciListBox,ogr_list_Row,"ozurluDev"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("tblOzurluDevamsizlikToplam"));
                                    veri = veri.FindElement(By.Id("Table3"));
                                    IList<IWebElement> tableRow = veri.FindElements(By.TagName("tr"));
                                    IList<IWebElement> tableTD = tableRow[tableRow.Count - 2].FindElements(By.TagName("td"));
                                    dataGridView1.Rows[satir].Cells["ozurluDev"].Value = tableTD[3].Text.ToString().Replace("gün", "").Trim();
                                }
                                catch
                                {
                                    dataGridView1.Rows[satir].Cells["ozurluDev"].Value = "0";
                                }
                            }
                            if (Checked(ogrenciListBox,ogr_list_Row,"ozursuzDev"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("tblOzursuzDevamsizlikToplam"));
                                    veri = veri.FindElement(By.Id("Table3"));
                                    IList<IWebElement> tableRow = veri.FindElements(By.TagName("tr"));
                                    IList<IWebElement> tableTD = tableRow[tableRow.Count - 2].FindElements(By.TagName("td"));
                                    dataGridView1.Rows[satir].Cells["ozursuzDev"].Value = tableTD[3].Text.ToString().Replace("gün", "").Trim();
                                }
                                catch
                                {
                                    dataGridView1.Rows[satir].Cells["ozursuzDev"].Value = "0";
                                }
                            }
                        }


                        //**************BABA BİLGİLERİ

                        if (Checked(babaListBox, baba_list_Row, "babaAdSoyad") || Checked(babaListBox, baba_list_Row, "babaTcNo") || Checked(babaListBox, baba_list_Row, "babaTel") || Checked(babaListBox, baba_list_Row, "babaSO") || Checked(babaListBox, baba_list_Row, "babaBA") || Checked(babaListBox, baba_list_Row, "babaMezuniyet") || Checked(babaListBox, baba_list_Row, "babaDT") || Checked(babaListBox, baba_list_Row, "babaMslk"))
                        {

                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02005.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02005.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02005.aspx");


                            bekle(50);
                            gozleriAc(1);


                            aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                            if (Checked(babaListBox, baba_list_Row, "babaAdSoyad"))
                            {
                                try
                                {
                                    veri = aranan[0].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf("BitMapResim=") + 12);
                                    adSoyad = geciciVeri.Substring(0, geciciVeri.IndexOf("\""));
                                    veri = aranan[2].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf("BitMapResim=") + 12);
                                    adSoyad += " " + geciciVeri.Substring(0, geciciVeri.IndexOf("\""));

                                    dataGridView1.Rows[satir].Cells["babaAdSoyad"].Value = adSoyad;
                                }
                                catch { dataGridView1.Rows[satir].Cells["babaAdSoyad"].Value = "Hata"; }
                            }
                            if (Checked(babaListBox, baba_list_Row, "babaTel"))
                            {
                                try
                                {
                                    veri = aranan[15].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("src").ToString();

                                    dataGridView1.Rows[satir].Cells["babaTel"].Value = geciciVeri.Remove(0, geciciVeri.IndexOf("=") + 1);
                                }
                                catch { dataGridView1.Rows[satir].Cells["babaTel"].Value = "Hata"; }
                            }
                            if (Checked(babaListBox, baba_list_Row, "babaTcNo"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-6"));
                                    veri = aranan[0].FindElement(By.TagName("h4"));

                                    dataGridView1.Rows[satir].Cells["babaTcNo"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["babaTcNo"].Value = "Hata"; }
                            }
                            if (Checked(babaListBox, baba_list_Row, "babaSO"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                                    veri = aranan[4].FindElement(By.TagName("span"));
                                    if (veri.Text.ToString() == "Sağ" || veri.Text.ToString() == "Ölü")
                                        dataGridView1.Rows[satir].Cells["babaSO"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["babaSO"].Value = "Hata"; }
                            }
                            if (Checked(babaListBox, baba_list_Row, "babaBA"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.XPath("//div[@class='form-check form-check-inline']"));
                                    veri = veri.FindElement(By.TagName("span"));
                                    if (veri.Text.ToString() == "Birlikte" || veri.Text.ToString() == "Ayrı")
                                        dataGridView1.Rows[satir].Cells["babaBA"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["babaBA"].Value = "Hata"; }
                            }
                            if (Checked(babaListBox, baba_list_Row, "babaDT"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                                    veri = aranan[9].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("src").ToString();
                                    geciciVeri = geciciVeri.Substring(geciciVeri.IndexOf("=") + 1);
                                    dataGridView1.Rows[satir].Cells["babaDT"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["babaDT"].Value = "Hata"; }
                            }
                            if (Checked(babaListBox, baba_list_Row, "babaMezuniyet"))
                            {
                                bekle(100);
                                bool hataVar = false;
                                do
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(eokul.FindElement(By.Id("ogrenimDurumu")));
                                        dataGridView1.Rows[satir].Cells["babaMezuniyet"].Value = se.SelectedOption.Text.ToString();
                                        hataVar = false;
                                    }
                                    catch
                                    {
                                        dataGridView1.Rows[satir].Cells["babaMezuniyet"].Value = "Hata";
                                        hataVar = true;
                                        eokul.Navigate().Refresh();
                                        bekle(500);
                                    }
                                } while (hataVar == true);
                            }
                            if (Checked(babaListBox, baba_list_Row, "babaMslk"))
                            {
                                bekle(100);
                                bool hataVar = false;
                                do
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(eokul.FindElement(By.Id("cmbMeslek")));
                                        dataGridView1.Rows[satir].Cells["babaMslk"].Value = se.SelectedOption.Text.ToString();
                                        hataVar = false;
                                    }
                                    catch
                                    {
                                        dataGridView1.Rows[satir].Cells["babaMslk"].Value = "Hata";
                                        hataVar = true;
                                        eokul.Navigate().Refresh();
                                        bekle(500);
                                    }
                                } while (hataVar == true);
                            }

                        }

                        //**************ANNE BİLGİLERİ

                        if (Checked(anneListBox, anne_list_Row, "anneAdSoyad") || Checked(anneListBox, anne_list_Row, "anneTcNo") || Checked(anneListBox, anne_list_Row, "anneTel") || Checked(anneListBox, anne_list_Row, "anneSO") || Checked(anneListBox, anne_list_Row, "anneBA") || Checked(anneListBox, anne_list_Row, "anneMezuniyet") || Checked(anneListBox, anne_list_Row, "anneDT") || Checked(anneListBox, anne_list_Row, "anneMslk"))
                        {
                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02006.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02006.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02006.aspx");

                            bekle(50);
                            gozleriAc(1);

                            aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                            if (Checked(anneListBox, anne_list_Row, "anneAdSoyad"))
                            {
                                try
                                {
                                    veri = aranan[0].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf("BitMapResim=") + 12);
                                    adSoyad = geciciVeri.Substring(0, geciciVeri.IndexOf("\""));
                                    veri = aranan[2].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf("BitMapResim=") + 12);
                                    adSoyad += " " + geciciVeri.Substring(0, geciciVeri.IndexOf("\""));

                                    dataGridView1.Rows[satir].Cells["anneAdSoyad"].Value = adSoyad;
                                }
                                catch { dataGridView1.Rows[satir].Cells["anneAdSoyad"].Value = "Hata"; }
                            }
                            if (Checked(anneListBox, anne_list_Row, "anneTel"))
                            {
                                try
                                {
                                    veri = aranan[15].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("src").ToString();

                                    dataGridView1.Rows[satir].Cells["anneTel"].Value = geciciVeri.Remove(0, geciciVeri.IndexOf("=") + 1);
                                }
                                catch { dataGridView1.Rows[satir].Cells["anneTel"].Value = "Hata"; }
                            }
                            if (Checked(anneListBox, anne_list_Row, "anneTcNo"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-6"));
                                    veri = aranan[0].FindElement(By.TagName("h4"));

                                    dataGridView1.Rows[satir].Cells["anneTcNo"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["anneTcNo"].Value = "Hata"; }
                            }
                            if (Checked(anneListBox, anne_list_Row, "anneSO"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                                    veri = aranan[4].FindElement(By.TagName("span"));
                                    if (veri.Text.ToString() == "Sağ" || veri.Text.ToString() == "Ölü")
                                        dataGridView1.Rows[satir].Cells["anneSO"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["anneSO"].Value = "Hata"; }
                            }
                            if (Checked(anneListBox, anne_list_Row, "anneBA"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.XPath("//div[@class='form-check form-check-inline']"));
                                    veri = veri.FindElement(By.TagName("span"));
                                    if (veri.Text.ToString() == "Birlikte" || veri.Text.ToString() == "Ayrı")
                                        dataGridView1.Rows[satir].Cells["anneBA"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["anneBA"].Value = "Hata"; }
                            }
                            if (Checked(anneListBox, anne_list_Row, "anneDT"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                                    veri = aranan[9].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("src").ToString();
                                    geciciVeri = geciciVeri.Substring(geciciVeri.IndexOf("=") + 1);
                                    dataGridView1.Rows[satir].Cells["anneDT"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["anneDT"].Value = "Hata"; }
                            }
                            if (Checked(anneListBox, anne_list_Row, "anneMezuniyet"))
                            {
                                bekle(100);
                                bool hataVar = false;
                                do
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(eokul.FindElement(By.Id("ogrenimDurumu")));
                                        dataGridView1.Rows[satir].Cells["anneMezuniyet"].Value = se.SelectedOption.Text.ToString();
                                        hataVar = false;
                                    }
                                    catch
                                    {
                                        dataGridView1.Rows[satir].Cells["anneMezuniyet"].Value = "Hata";
                                        hataVar = true;
                                        eokul.Navigate().Refresh();
                                        bekle(500);
                                    }
                                } while (hataVar == true);
                            }
                            if (Checked(anneListBox, anne_list_Row, "anneMslk"))
                            {
                                bekle(100);
                                bool hataVar = false;
                                do
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(eokul.FindElement(By.Id("cmbMeslek")));
                                        dataGridView1.Rows[satir].Cells["anneMslk"].Value = se.SelectedOption.Text.ToString();
                                        hataVar = false;
                                    }
                                    catch
                                    {
                                        dataGridView1.Rows[satir].Cells["anneMslk"].Value = "Hata";
                                        hataVar = true;
                                        eokul.Navigate().Refresh();
                                        bekle(500);
                                    }
                                } while (hataVar == true);
                            }
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[satir].Cells["adSoyad"].Value = "Öğrenci bulunamadı";
                        dataGridView1.Rows[satir].Cells["adSoyad"].Style.BackColor = Color.PaleVioletRed;
                    }
                    
                    endingRow = satir;
                }
                catch
                {

                }
                finally
                {
                    satir++;
                    Application.DoEvents();
                    bekle(10);
                }
            }
            progressBar1.Value = progressBar1.Maximum;

        }        

        private void gozleriAc(byte secim)
        {
            ((IJavaScriptExecutor)eokul).ExecuteScript("document.getElementsByClassName('dropdown drp-user')[0].setAttribute('style', 'visibility: hidden;')");

            IList<IWebElement> aranan;
            DateTime start;

            start = DateTime.Now;
            do
            {
                if (secim == 1)
                    aranan = eokul.FindElements(By.XPath("//i[@class='feather icon-eye f-20']"));
                else
                    aranan = eokul.FindElements(By.XPath("//i[@class='feather icon-eye f-20 bak']"));

                if (Convert.ToInt32((DateTime.Now - start).TotalSeconds) > 5)
                {
                    eokul.Navigate().Refresh();
                    bekle(100);
                }

            } while (aranan.Count == 0);

            bekle(50);
            eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
            do
            {
                foreach (IWebElement deger in aranan)
                {
                    try
                    {
                        deger.Click();
                        bekle(10);
                    }
                    catch { }
                    finally { Application.DoEvents(); }
                }
                if (secim == 1)
                    aranan = eokul.FindElements(By.XPath("//i[@class='feather icon-eye f-20']"));
                else
                    aranan = eokul.FindElements(By.XPath("//i[@class='feather icon-eye f-20 bak']"));
            } while (aranan.Count > 0);
            Application.DoEvents();
        }

        private void bekle(int saniye)
        {
            int speed = 1;
            if (speed_rb_normal.Checked == true) { speed = 1; }
            else if (speed_rb_slow.Checked == true) { speed = 2; }
            else if (speed_rb_slower.Checked == true) { speed = 3; }
            DateTime start = DateTime.Now;
            while (Convert.ToInt32((DateTime.Now - start).TotalMilliseconds) < saniye*speed)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                ogrenciListBox.SetItemChecked(i, true);
                babaListBox.SetItemChecked(i, true);
                anneListBox.SetItemChecked(i, true);
            }
            try
            {
                seting_Load();
            }
            catch
            {
                seting_Save();

            }
            endingRow = 0;
        }
            private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Veri büyüklüğüne göre Excel'e aktarım zaman alabilir lütfen Bitti uyarısı gelene kadar başka işlem yapmayınız.", "Excel'e Aktarım", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                
                worksheet = workbook.Sheets["Sayfa1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Excel Dışa Aktarım";
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {
                            worksheet.Cells[i + 2, j + 1].NumberFormat = "@";
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        catch { }
                    }
                }
                
                MessageBox.Show("Excel'e aktarım hatasız bir şekilde bitti. Tamam tuşuna basarak Excel dosyasına erişebilirsiniz.", "Excel'e Aktarım Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                app.Visible = true;
            }
            catch
            {
                MessageBox.Show("Excel'e aktarım sırasında hata oluştu. Eğer sorun yaşamaya devam ederseniz verileri kopyalayıp Excel'e yapıştırabilirsiniz.", "Veri Aktarım Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                seting_Save();
                eokul.Close();
                eokul.Dispose();

            }
            catch
            {

            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

            dataGridView1.SelectAll();
            Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void babaListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void aihlGiris()
        {
            IWebElement veri;
            veri = eokul.FindElement(By.Id("mdlOOO"));
            veri.Click();
            bekle(50);
            veri = eokul.FindElement(By.Id("btnListele"));
            veri.Click();
            bekle(150);
            eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
            bekle(500);
            eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
            bekle(500);
            Application.DoEvents();
            IList<IWebElement> aranan = eokul.FindElements(By.XPath("//i[@class='fas fa-folder']"));
            aranan[0].Click();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void seting_Save()
        {




            for (int i = 0; i < ogrenciListBox.Items.Count; i++)
            {

                IniIslemleri.VeriYaz("Listbox", "ogr_list" + i, ogrenciListBox.GetItemChecked(i).ToString());
            }
            for (int i = 0; i < babaListBox.Items.Count; i++)
            {

                IniIslemleri.VeriYaz("Listbox", "baba_list" + i, babaListBox.GetItemChecked(i).ToString());
            }
            for (int i = 0; i < anneListBox.Items.Count; i++)
            {

                IniIslemleri.VeriYaz("Listbox", "anne_list" + i, anneListBox.GetItemChecked(i).ToString());
            }

            string radioButtonName_Hiz = "";
            foreach (Control control in groupBox1.Controls)
            {
                if (control is RadioButton && ((RadioButton)control).Checked)
                {
                    radioButtonName_Hiz = control.Name;
                    IniIslemleri.VeriYaz("radioButton", "Hiz", radioButtonName_Hiz);
                    break;
                }
            }

            string radioButtonName_Okul = "";
            foreach (Control control in groupBox2.Controls)
            {
                if (control is RadioButton && ((RadioButton)control).Checked)
                {
                    radioButtonName_Okul = control.Name;
                    IniIslemleri.VeriYaz("radioButton", "Okul", radioButtonName_Okul);
                    break;
                }
            }


        }

        private void seting_Load()
        {



            for (int i = 0; i < ogrenciListBox.Items.Count; i++)
            {
                ogrenciListBox.SetItemChecked(i, Convert.ToBoolean(IniIslemleri.VeriOku("Listbox", "ogr_list" + i)));
            }

            for (int i = 0; i < anneListBox.Items.Count; i++)
            {
                anneListBox.SetItemChecked(i, Convert.ToBoolean(IniIslemleri.VeriOku("Listbox", "anne_list" + i)));
            }

            for (int i = 0; i < babaListBox.Items.Count; i++)
            {
                babaListBox.SetItemChecked(i, Convert.ToBoolean(IniIslemleri.VeriOku("Listbox", "baba_list" + i)));
            }

            String Hiz = IniIslemleri.VeriOku("radioButton", "Hiz");
            RadioButton button_hiz = this.Controls.Find(Hiz, true).FirstOrDefault() as RadioButton;
            button_hiz.Checked = true;

            String Okul = IniIslemleri.VeriOku("radioButton", "Okul");
            RadioButton button_okul = this.Controls.Find(Okul, true).FirstOrDefault() as RadioButton;
            button_okul.Checked = true;







        }




    }
}
