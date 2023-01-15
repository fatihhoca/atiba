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


        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sub_School.SelectedIndex = 0;
            ogrenciListBox.Items.AddRange(ogr_list_Row);
            babaListBox.Items.AddRange(baba_list_Row);
            anneListBox.Items.AddRange(anne_list_Row);
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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                seting_Save();
                eokul.Close();
                eokul.Dispose();
            }
            catch
            { }
        }


        private static int endingRow;
        private static string[] ogr_list_Row = { "Adi", "Soyadi", "Tc_No", "Sinif", "foto", "Veli", "Uyruk", "Cinsiyet", "Dogum_Tarihi", "Dogum_Yeri", "Cilt_No", "Aile_Sira_No", "Sira_No", "Mahalle_Koy", "Boy", "Kilo", "Tasima", "Ozurlu_Dev", "Ozursuz_Dev" };
        private static string[] baba_list_Row = { "Baba_Adi_Soyadi", "Baba_Tc_No", "Baba_Tel", "Baba_Sag_Olu", "Baba_Birlikte", "Baba_Mezuniyet", "Baba_Doğum_Tarihi", "Baba_Mslk" };
        private static string[] anne_list_Row = { "Anne_Adi_Soyadi", "Anne_Tc_No", "Anne_Tel", "Anne_Sağ_Olu", "Anne_Birlikte", "Anne_Mezuniyet", "Anne_Dogum_Tarihi", "Anne_Mslk" };

        private static IWebDriver eokul;
        private static IWebElement veri;
        private static Screenshot foto;
        private static IList<IWebElement> aranan;
        private static int satir = 0;
        private static string adSoyad, geciciVeri;
        private static DateTime start;



        private void get_students_List_Click(object sender, EventArgs e)
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
                        dataGridView1.Columns.Add("No", "No");
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
                        MessageBox.Show("Seçtiğiniz EXCEL içinde Öğrenci No alanı tespit edilemedi\nTablonuzda Öğrenci No adlı bir sütun ve altında öğrenci numaraları olması yeterli", "Öğrenci No Sütunu Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        private void open_Eokul_Click(object sender, EventArgs e)
        {
            eokul = new ChromeDriver();
            eokul.Manage().Window.Maximize();
            eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/");
        }

        private void set_Data_Excel_Click(object sender, EventArgs e)
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
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].Name.ToString();
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
        private void coyp_Data_Click(object sender, EventArgs e)
        {

            dataGridView1.SelectAll();
            Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
        }
        private void get_student_Click(object sender, EventArgs e)
        {
            AddColumn("No");
            dataGridView1.Rows.Add("No Yaz");
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
        private void AddColumn(string columnName)
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
                dataGridView1.Columns.Add(columnName, columnName);
            }
        }
        public bool Checked(string value)
        {

            string[] foundInList = null;
            CheckedListBox myListBox = null;
            int ogrIndex = Array.IndexOf(ogr_list_Row, value);
            int babaIndex = Array.IndexOf(baba_list_Row, value);
            int anneIndex = Array.IndexOf(anne_list_Row, value);
            if (ogrIndex != -1)
            {
                foundInList = ogr_list_Row;
                myListBox = ogrenciListBox;
            }
            else if (babaIndex != -1)
            {
                foundInList = baba_list_Row;
                myListBox = babaListBox;
            }
            else if (anneIndex != -1)
            {
                foundInList = anne_list_Row;
                myListBox = anneListBox;
            }



            int index = Array.IndexOf(foundInList, value);
            return myListBox.GetItemChecked(index);
        }
        private void open_Eyes(byte secim)
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
                    next_Wait(100);
                }

            } while (aranan.Count == 0);

            next_Wait(50);
            eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
            do
            {
                foreach (IWebElement deger in aranan)
                {
                    try
                    {
                        deger.Click();
                        next_Wait(10);
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

        private void get_Data_Click(object sender, EventArgs e)
        {

            if (Checked("Adi")) AddColumn("Adi");
            if (Checked("Soyadi")) AddColumn("Soyadi");
            if (Checked("Tc_No")) AddColumn("Tc_No");
            if (Checked("Sinif")) AddColumn("Sinif");
            if (Checked("Veli")) AddColumn("Veli");
            if (Checked("Uyruk")) AddColumn("Uyruk");
            if (Checked("Cinsiyet")) AddColumn("Cinsiyet");
            if (Checked("Dogum_Tarihi")) AddColumn("Dogum_Tarihi");
            if (Checked("Dogum_Yeri")) AddColumn("Dogum_Yeri");
            if (Checked("Cilt_No")) AddColumn("Cilt_No");
            if (Checked("Aile_Sira_No")) AddColumn("Aile_Sira_No");
            if (Checked("Sira_No")) AddColumn("Sira_No");
            if (Checked("Mahalle_Koy")) AddColumn("Mahalle_Koy");
            if (Checked("Boy")) AddColumn("Boy");
            if (Checked("Kilo")) AddColumn("Kilo");
            if (Checked("Tasima")) AddColumn("Tasima");
            if (Checked("Ozurlu_Dev")) AddColumn("Ozurlu_Dev");
            if (Checked("Ozursuz_Dev")) AddColumn("Ozursuz_Dev");

            if (Checked("Baba_Adi_Soyadi")) AddColumn("Baba_Adi_Soyadi");
            if (Checked("Baba_Tc_No")) AddColumn("Baba_Tc_No");
            if (Checked("Baba_Tel")) AddColumn("Baba_Tel");
            if (Checked("Baba_Sag_Olu")) AddColumn("Baba_Sag_Olu");
            if (Checked("Baba_Birlikte")) AddColumn("Baba_Birlikte");
            if (Checked("Baba_Mezuniyet")) AddColumn("Baba_Mezuniyet");
            if (Checked("Baba_Doğum_Tarihi")) AddColumn("Baba_Doğum_Tarihi");
            if (Checked("Baba_Mslk")) AddColumn("Baba_Mslk");

            if (Checked("Anne_Adi_Soyadi")) AddColumn("Anne_Adi_Soyadi");
            if (Checked("Anne_Tc_No")) AddColumn("Anne_Tc_No");
            if (Checked("Anne_Tel")) AddColumn("Anne_Tel");
            if (Checked("Anne_Sağ_Olu")) AddColumn("Anne_Sağ_Olu");
            if (Checked("Anne_Birlikte")) AddColumn("Anne_Birlikte");
            if (Checked("Anne_Mezuniyet")) AddColumn("Anne_Mezuniyet");
            if (Checked("Anne_Dogum_Tarihi")) AddColumn("Anne_Dogum_Tarihi");
            if (Checked("Anne_Mslk")) AddColumn("Anne_Mslk");


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

            while (satir < dataGridView1.Rows.Count - 1)

            {
                DataGridViewRow dr = dataGridView1.Rows[satir];
                progressBar1.Value++;
                try
                {
                    //**************ÖĞRENCİ BİLGİLERİ
                    if (radioButton1.Checked == true)
                    {
                        eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG01001.aspx");
                        next_Wait(50);
                        eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                        veri = eokul.FindElement(By.Id("OGRMenu1_txtTC"));
                        veri.SendKeys(dr.Cells["No"].Value.ToString());
                        eokul.FindElement(By.Id("OGRMenu1_btnAra")).Click();
                        next_Wait(50);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG00001.aspx");
                        next_Wait(50);
                        //eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                        aranan = eokul.FindElements(By.Id("OGRMenu1_ddlOkulAltTurYeni"));
                        if (aranan.Count > 0)
                        {
                            aranan[0].SendKeys(sub_School.Text);
                            next_Wait(100);
                        }

                        veri = eokul.FindElement(By.Id("OGRMenu1_txtTCYeni"));
                        veri.SendKeys(dr.Cells["No"].Value.ToString());
                        eokul.FindElement(By.Id("btnOgrenciAra")).Click();
                        next_Wait(50);
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
                        veri.SendKeys(dr.Cells["No"].Value.ToString());
                        veri = eokul.FindElement(By.Id("btnListele"));
                        veri.Click();
                        next_Wait(150);
                        eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
                        next_Wait(500);
                        eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
                        next_Wait(500);
                        Application.DoEvents();
                        aranan = eokul.FindElements(By.XPath("//i[@class='fas fa-folder']"));
                        aranan[0].Click();
                        next_Wait(50);
                    }
                    else if (radioButton4.Checked == true)
                    {
                        eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG01001.aspx");
                        next_Wait(50);
                        eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                        veri = eokul.FindElement(By.Id("OGRMenu1_txtTC"));
                        veri.SendKeys(dr.Cells["No"].Value.ToString());
                        eokul.FindElement(By.Id("OGRMenu1_btnAra")).Click();
                        next_Wait(50);
                    }



                    veri = eokul.FindElement(By.Id("txtAdi"));
                    adSoyad = veri.GetAttribute("value").ToString();

                    if (adSoyad.Trim() != "")
                    {
                        if (Checked("Adi"))
                        {


                            veri = eokul.FindElement(By.Id("txtAdi"));
                            geciciVeri = veri.GetAttribute("value").ToString();
                            dataGridView1.Rows[satir].Cells["Adi"].Value = geciciVeri;
                        }
                        if (Checked("Soyadi"))
                        {
                            veri = eokul.FindElement(By.Id("txtSoyadi"));
                            geciciVeri = veri.GetAttribute("value").ToString();
                            dataGridView1.Rows[satir].Cells["Soyadi"].Value = geciciVeri;
                        }
                        if (Checked("Tc_No"))
                        {
                            try
                            {
                                veri = eokul.FindElement(By.Id("txtKisiTCKimlikNo"));
                                dataGridView1.Rows[satir].Cells["Tc_No"].Value = veri.GetAttribute("value").ToString();
                            }
                            catch { dataGridView1.Rows[satir].Cells["Tc_No"].Value = "Hata"; }
                        }
                        if (Checked("Sinif"))
                        {
                            try
                            {
                                if (radioButton1.Checked == true)
                                    veri = eokul.FindElement(By.Id("IOMPageHeader1_lblSinif"));
                                else
                                    veri = eokul.FindElement(By.Id("OOMPageHeader1_lblSinif"));

                                dataGridView1.Rows[satir].Cells["Sinif"].Value = veri.Text.ToString();
                            }
                            catch { dataGridView1.Rows[satir].Cells["Sinif"].Value = "Hata"; }
                        }
                        if (Checked("foto"))
                        {
                            //Burada kaldın
                            string sinifi;
                            string nosu;
                            try
                            {
                                sinifi = dataGridView1.Rows[satir].Cells["Sinif"].Value.ToString().Replace("/", "-");
                                nosu = dataGridView1.Rows[satir].Cells["No"].Value.ToString();
                                ((IJavaScriptExecutor)eokul).ExecuteScript("document.getElementsByTagName('img')[0].setAttribute('style', 'border-radius:0px;border-style: none;height:171px;width:133px;')");
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
                        if (Checked("Veli"))
                        {
                            try
                            {
                                SelectElement se = new SelectElement(eokul.FindElement(By.Id("ddlVelisi")));

                                dataGridView1.Rows[satir].Cells["Veli"].Value = se.SelectedOption.Text.ToString();
                            }
                            catch { dataGridView1.Rows[satir].Cells["Veli"].Value = "Hata"; }
                        }
                        if (Checked("Uyruk") || Checked("Cinsiyet") || Checked("Dogum_Tarihi") || Checked("Dogum_Yeri") || Checked("Cilt_No") || Checked("Aile_Sira_No") || Checked("Sira_No"))
                        {
                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02003.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02003.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/OOG02003.aspx");

                            next_Wait(50);

                            open_Eyes(2);
                            if (Checked("Uyruk"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.XPath("//*[@id='uyruk']"));
                                    dataGridView1.Rows[satir].Cells["Uyruk"].Value = veri.Text;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Uyruk"].Value = "Hata"; }
                            }
                            if (Checked("Cinsiyet"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.XPath("//*[@id='cinsiyet']"));
                                    dataGridView1.Rows[satir].Cells["Cinsiyet"].Value = veri.Text;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Cinsiyet"].Value = "Hata"; }
                            }
                            if (Checked("Dogum_Tarihi"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("dogumTarihi"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["Dogum_Tarihi"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Dogum_Tarihi"].Value = "Hata"; }
                            }
                            if (Checked("Dogum_Yeri"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("dogumYeri"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["Dogum_Yeri"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Dogum_Yeri"].Value = "Hata"; }
                            }
                            if (Checked("Cilt_No"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("Cilt_No"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["Cilt_No"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Cilt_No"].Value = "Hata"; }
                            }
                            if (Checked("Aile_Sira_No"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("aileSiraNo"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["Aile_Sira_No"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Aile_Sira_No"].Value = "Hata"; }
                            }


                            if (Checked("Sira_No"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("siraNo"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["Sira_No"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Sira_No"].Value = "Hata"; }
                            }




                            if (Checked("Mahalle_Koy"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("nufusMahalle"));
                                    veri = veri.FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                                    geciciVeri = geciciVeri.Substring(0, geciciVeri.Length - 2);
                                    dataGridView1.Rows[satir].Cells["Mahalle_Koy"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Mahalle_Koy"].Value = "Hata"; }
                            }
                        }
                        if (Checked("Boy") || Checked("Kilo") || Checked("Tasima"))
                        {
                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/iog02002.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02002.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/OOG02002.aspx");

                            next_Wait(50);
                            if (Checked("Boy"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("txtBoy"));
                                    dataGridView1.Rows[satir].Cells["Boy"].Value = veri.GetAttribute("value").ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["Boy"].Value = "Hata"; }
                            }
                            if (Checked("Kilo"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("txtKilo"));
                                    dataGridView1.Rows[satir].Cells["Kilo"].Value = veri.GetAttribute("value").ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["Kilo"].Value = "Hata"; }
                            }
                            if (Checked("Tasima"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("chkTasimaPalanDahilmi"));

                                    if (veri.Selected == true)
                                        dataGridView1.Rows[satir].Cells["Tasima"].Value = "Evet";
                                    else
                                        dataGridView1.Rows[satir].Cells["Tasima"].Value = "Hayır";
                                }
                                catch { dataGridView1.Rows[satir].Cells["Tasima"].Value = "Hata"; }
                            }
                        }
                        if (Checked("Ozurlu_Dev") || Checked("Ozursuz_Dev"))
                        {
                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02015.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02015.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/OOG02015.aspx");

                            next_Wait(50);

                            if (Checked("Ozurlu_Dev"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("tblOzurluDevamsizlikToplam"));
                                    veri = veri.FindElement(By.Id("Table3"));
                                    IList<IWebElement> tableRow = veri.FindElements(By.TagName("tr"));
                                    IList<IWebElement> tableTD = tableRow[tableRow.Count - 2].FindElements(By.TagName("td"));
                                    dataGridView1.Rows[satir].Cells["Ozurlu_Dev"].Value = tableTD[3].Text.ToString().Replace("gün", "").Trim();
                                }
                                catch
                                {
                                    dataGridView1.Rows[satir].Cells["Ozurlu_Dev"].Value = "0";
                                }
                            }
                            if (Checked("Ozursuz_Dev"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.Id("tblOzursuzDevamsizlikToplam"));
                                    veri = veri.FindElement(By.Id("Table3"));
                                    IList<IWebElement> tableRow = veri.FindElements(By.TagName("tr"));
                                    IList<IWebElement> tableTD = tableRow[tableRow.Count - 2].FindElements(By.TagName("td"));
                                    dataGridView1.Rows[satir].Cells["Ozursuz_Dev"].Value = tableTD[3].Text.ToString().Replace("gün", "").Trim();
                                }
                                catch
                                {
                                    dataGridView1.Rows[satir].Cells["Ozursuz_Dev"].Value = "0";
                                }
                            }
                        }


                        //**************BABA BİLGİLERİ

                        if (Checked("Baba_Adi_Soyadi") || Checked("bBaba_Tc_No") || Checked("Baba_Tel") || Checked("Baba_Sag_Olu") || Checked("Baba_Birlikte") || Checked("Baba_Mezuniyet") || Checked("Baba_Doğum_Tarihi") || Checked("Baba_Mslk"))
                        {

                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02005.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02005.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02005.aspx");


                            next_Wait(50);
                            open_Eyes(1);


                            aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                            if (Checked("Baba_Adi_Soyadi"))
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

                                    dataGridView1.Rows[satir].Cells["Baba_Adi_Soyadi"].Value = adSoyad;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Baba_Adi_Soyadi"].Value = "Hata"; }
                            }
                            if (Checked("Baba_Tel"))
                            {
                                try
                                {
                                    veri = aranan[15].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("src").ToString();

                                    dataGridView1.Rows[satir].Cells["Baba_Tel"].Value = geciciVeri.Remove(0, geciciVeri.IndexOf("=") + 1);
                                }
                                catch { dataGridView1.Rows[satir].Cells["Baba_Tel"].Value = "Hata"; }
                            }
                            if (Checked("Baba_Tc_No"))
                            {
                                if (Checked("Baba_Tc_No"))
                                {
                                    try
                                    {
                                        aranan = eokul.FindElements(By.Id("yeniBabaTc"));
                                        if (aranan.Count == 0)
                                        {
                                            aranan = eokul.FindElements(By.ClassName("col-6"));
                                            veri = aranan[0].FindElement(By.TagName("h4"));
                                            dataGridView1.Rows[satir].Cells["Baba_Tc_No"].Value = veri.Text.ToString();
                                        }
                                        else
                                        {
                                            veri = eokul.FindElement(By.Id("yeniBabaTc"));
                                            dataGridView1.Rows[satir].Cells["Baba_Tc_No"].Value = veri.GetAttribute("value");
                                        }
                                    }
                                    catch { dataGridView1.Rows[satir].Cells["Baba_Tc_No"].Value = "Hata"; }
                                }

                            }
                            if (Checked("Baba_Sag_Olu"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                                    veri = aranan[4].FindElement(By.TagName("span"));
                                    if (veri.Text.ToString() == "Sağ" || veri.Text.ToString() == "Ölü")
                                        dataGridView1.Rows[satir].Cells["Baba_Sag_Olu"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["Baba_Sag_Olu"].Value = "Hata"; }
                            }
                            if (Checked("Baba_Birlikte"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.XPath("//div[@class='form-check form-check-inline']"));
                                    veri = veri.FindElement(By.TagName("span"));
                                    if (veri.Text.ToString() == "Birlikte" || veri.Text.ToString() == "Ayrı")
                                        dataGridView1.Rows[satir].Cells["Baba_Birlikte"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["Baba_Birlikte"].Value = "Hata"; }
                            }
                            if (Checked("Baba_Doğum_Tarihi"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                                    veri = aranan[9].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("src").ToString();
                                    geciciVeri = geciciVeri.Substring(geciciVeri.IndexOf("=") + 1);
                                    dataGridView1.Rows[satir].Cells["Baba_Doğum_Tarihi"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Baba_Doğum_Tarihi"].Value = "Hata"; }
                            }
                            if (Checked("Baba_Mezuniyet"))
                            {
                                next_Wait(100);
                                bool hataVar = false;
                                do
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(eokul.FindElement(By.Id("ogrenimDurumu")));
                                        dataGridView1.Rows[satir].Cells["Baba_Mezuniyet"].Value = se.SelectedOption.Text.ToString();
                                        hataVar = false;
                                    }
                                    catch
                                    {
                                        dataGridView1.Rows[satir].Cells["Baba_Mezuniyet"].Value = "Hata";
                                        hataVar = true;
                                        eokul.Navigate().Refresh();
                                        next_Wait(500);
                                    }
                                } while (hataVar == true);
                            }
                            if (Checked("Baba_Mslk"))
                            {
                                next_Wait(100);
                                bool hataVar = false;
                                do
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(eokul.FindElement(By.Id("cmbMeslek")));
                                        dataGridView1.Rows[satir].Cells["Baba_Mslk"].Value = se.SelectedOption.Text.ToString();
                                        hataVar = false;
                                    }
                                    catch
                                    {
                                        dataGridView1.Rows[satir].Cells["Baba_Mslk"].Value = "Hata";
                                        hataVar = true;
                                        eokul.Navigate().Refresh();
                                        next_Wait(500);
                                    }
                                } while (hataVar == true);
                            }

                        }

                        //**************ANNE BİLGİLERİ

                        if (Checked("Anne_Adi_Soyadi") || Checked("Anne_Tc_No") || Checked("Anne_Tel") || Checked("Anne_Sağ_Olu") || Checked("Anne_Birlikte") || Checked("Anne_Mezuniyet") || Checked("Anne_Dogum_Tarihi") || Checked("Anne_Mslk"))
                        {
                            if (radioButton1.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02006.aspx");
                            else if (radioButton2.Checked == true || radioButton3.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02006.aspx");
                            else if (radioButton4.Checked == true)
                                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02006.aspx");

                            next_Wait(50);
                            open_Eyes(1);

                            aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                            if (Checked("Anne_Adi_Soyadi"))
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

                                    dataGridView1.Rows[satir].Cells["Anne_Adi_Soyadi"].Value = adSoyad;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Anne_Adi_Soyadi"].Value = "Hata"; }
                            }
                            if (Checked("Anne_Tel"))
                            {
                                try
                                {
                                    veri = aranan[15].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("src").ToString();

                                    dataGridView1.Rows[satir].Cells["Anne_Tel"].Value = geciciVeri.Remove(0, geciciVeri.IndexOf("=") + 1);
                                }
                                catch { dataGridView1.Rows[satir].Cells["Anne_Tel"].Value = "Hata"; }
                            }
                            if (Checked("Anne_Tc_No"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.XPath("//*[@id='chartdiv']/div/div[3]/div/div/div/div/div[2]/div/div[2]/div/div[1]/input"));
                                    if (aranan.Count == 0)
                                    {
                                        aranan = eokul.FindElements(By.ClassName("col-6"));
                                        veri = aranan[0].FindElement(By.TagName("h4"));
                                        dataGridView1.Rows[satir].Cells["Anne_Tc_No"].Value = veri.Text.ToString();
                                    }
                                    else
                                    {
                                        veri = eokul.FindElement(By.XPath("//*[@id='chartdiv']/div/div[3]/div/div/div/div/div[2]/div/div[2]/div/div[1]/input"));
                                        dataGridView1.Rows[satir].Cells["Anne_Tc_No"].Value = veri.GetAttribute("value");
                                    }
                                }
                                catch { dataGridView1.Rows[satir].Cells["Anne_Tc_No"].Value = "Hata"; }
                            }
                            if (Checked("Anne_Sağ_Olu"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                                    veri = aranan[4].FindElement(By.TagName("span"));
                                    if (veri.Text.ToString() == "Sağ" || veri.Text.ToString() == "Ölü")
                                        dataGridView1.Rows[satir].Cells["Anne_Sağ_Olu"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["Anne_Sağ_Olu"].Value = "Hata"; }
                            }
                            if (Checked("Anne_Birlikte"))
                            {
                                try
                                {
                                    veri = eokul.FindElement(By.XPath("//div[@class='form-check form-check-inline']"));
                                    veri = veri.FindElement(By.TagName("span"));
                                    if (veri.Text.ToString() == "Birlikte" || veri.Text.ToString() == "Ayrı")
                                        dataGridView1.Rows[satir].Cells["Anne_Birlikte"].Value = veri.Text.ToString();
                                }
                                catch { dataGridView1.Rows[satir].Cells["Anne_Birlikte"].Value = "Hata"; }
                            }
                            if (Checked("Anne_Dogum_Tarihi"))
                            {
                                try
                                {
                                    aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                                    veri = aranan[9].FindElement(By.TagName("img"));
                                    geciciVeri = veri.GetAttribute("src").ToString();
                                    geciciVeri = geciciVeri.Substring(geciciVeri.IndexOf("=") + 1);
                                    dataGridView1.Rows[satir].Cells["Anne_Dogum_Tarihi"].Value = geciciVeri;
                                }
                                catch { dataGridView1.Rows[satir].Cells["Anne_Dogum_Tarihi"].Value = "Hata"; }
                            }
                            if (Checked("Anne_Mezuniyet"))
                            {
                                next_Wait(100);
                                bool hataVar = false;
                                do
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(eokul.FindElement(By.Id("ogrenimDurumu")));
                                        dataGridView1.Rows[satir].Cells["Anne_Mezuniyet"].Value = se.SelectedOption.Text.ToString();
                                        hataVar = false;
                                    }
                                    catch
                                    {
                                        dataGridView1.Rows[satir].Cells["Anne_Mezuniyet"].Value = "Hata";
                                        hataVar = true;
                                        eokul.Navigate().Refresh();
                                        next_Wait(500);
                                    }
                                } while (hataVar == true);
                            }
                            if (Checked("Anne_Mslk"))
                            {
                                next_Wait(100);
                                bool hataVar = false;
                                do
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(eokul.FindElement(By.Id("cmbMeslek")));
                                        dataGridView1.Rows[satir].Cells["Anne_Mslk"].Value = se.SelectedOption.Text.ToString();
                                        hataVar = false;
                                    }
                                    catch
                                    {
                                        dataGridView1.Rows[satir].Cells["Anne_Mslk"].Value = "Hata";
                                        hataVar = true;
                                        eokul.Navigate().Refresh();
                                        next_Wait(500);
                                    }
                                } while (hataVar == true);
                            }
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[satir].Cells["Adi"].Value = "Öğrenci bulunamadı";
                        dataGridView1.Rows[satir].Cells["Adi"].Style.BackColor = Color.PaleVioletRed;
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
                    next_Wait(10);

                }



            }
            progressBar1.Value = progressBar1.Maximum;
            get_Data.Text = "Bilgileri Çek";




        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sub_School.Enabled = false;
            label1.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sub_School.Enabled = false;
            label1.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            sub_School.Enabled = false;
            label1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sub_School.Enabled = true;
            label1.Enabled = true;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void next_Wait(int saniye)
        {
            int speed = 1;
            if (speed_rb_normal.Checked == true) { speed = 1; }
            else if (speed_rb_slow.Checked == true) { speed = 2; }
            else if (speed_rb_slower.Checked == true) { speed = 3; }
            DateTime start = DateTime.Now;
            while (Convert.ToInt32((DateTime.Now - start).TotalMilliseconds) < saniye * speed)
            {

            }
        }






    }
}
