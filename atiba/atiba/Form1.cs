using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;


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
            ogrenciListBox.Items.AddRange(Ogr_list_Row);
            babaListBox.Items.AddRange(Baba_list_Row);
            anneListBox.Items.AddRange(Anne_list_Row);

            try
            {
                seting_Load();
            }
            catch
            {
                seting_Save();

            }
            endingRow = 0;
            SlnGetData.Set_Speed(IniIslemleri.VeriOku("radioButton", "Hiz"));
            SlnGetData.Set_School(IniIslemleri.VeriOku("radioButton", "Okul"));

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            seting_Save();
            SlnGetData.BaglantiKes();
            //SlnGetData.eokul.Close();
            //SlnGetData.eokul.Dispose();

        }


        private static int endingRow;

        private static string[] Ogr_list_Row = SlnGetData.Set_List("Ogr");
        private static string[] Baba_list_Row = SlnGetData.Set_List("Baba");
        private static string[] Anne_list_Row = SlnGetData.Set_List("Anne");

        private static int satir = 0;





        private void get_students_List_Click(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.Rows.Clear();
                //dataGridView1.Columns.Clear();
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
                    // dataGridView1.Rows.Clear();

                    string name = "Sheet1";
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DosyaYolu + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    OleDbConnection Con = new OleDbConnection(constr);
                    OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$]", Con);
                    Con.Open();

                    OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    int ay = -1;
                    if (data.Columns.IndexOf("Öğrenci No") != -1)
                    {
                        AddColumn("Ogr_No");

                        foreach (DataRow drx in data.Rows)
                        {
                            if (drx["Öğrenci No"].ToString() != "")


                                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                                {
                                    ay = -1;
                                    if (dataGridView1.Rows[i].Cells["Ogr_No"].Value.ToString() == drx["Öğrenci No"].ToString())
                                    {
                                        ay = i;
                                        break;
                                    }
                                };


                            if (ay == -1 && drx["Öğrenci No"].ToString() != "")
                            { dataGridView1.Rows.Add(drx["Öğrenci No"]); }





                        }


                        dataGridView1.ReadOnly = false;
                        dataGridView1.Columns[0].Width = 100;
                        dataGridView1.ClearSelection();
                    }
                    else if (data.Columns.IndexOf("Ogr_No") != -1)
                    {
                        foreach (DataColumn column in data.Columns)
                        {
                            AddColumn(column.ColumnName);

                        }

                        foreach (DataRow row in data.Rows)
                        {
                            int index = dataGridView1.Rows.Add();
                            for (int i = 0; i < data.Columns.Count; i++)
                            {
                                dataGridView1.Rows[index].Cells[i].Value = row[i];
                            }
                        }
                        endingRow = dataGridView1.Rows.Count - 1;


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

            SlnGetData.Baglan();



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
                worksheet.Name = "Sheet1";
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
            AddColumn("Ogr_No");
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
            int ogrIndex = Array.IndexOf(Ogr_list_Row, value);
            int babaIndex = Array.IndexOf(Baba_list_Row, value);
            int anneIndex = Array.IndexOf(Anne_list_Row, value);
            if (ogrIndex != -1)
            {
                foundInList = Ogr_list_Row;
                myListBox = ogrenciListBox;
            }
            else if (babaIndex != -1)
            {
                foundInList = Baba_list_Row;
                myListBox = babaListBox;
            }
            else if (anneIndex != -1)
            {
                foundInList = Anne_list_Row;
                myListBox = anneListBox;
            }



            int index = Array.IndexOf(foundInList, value);
            return myListBox.GetItemChecked(index);
        }

        private void get_Data_Click(object sender, EventArgs e)
        {
            if (SlnGetData.eokul == null)
            {
                MessageBox.Show("Eokul için Chrome Tarayıcısı açılmamış\nEokulu yandaki butonu kullanarak açın.", "Her şeyin Sırası var", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                /*  string[][] lists = { Ogr_list_Row, Baba_list_Row, Anne_list_Row };

                  for (int i = 0; i < lists.Length; i++)
                  {
                      for (int j = 0; j < lists[i].Length; j++)
                      {
                          if (Checked(lists[i][j])) AddColumn(lists[i][j]);

                      }
                  }

  */

                DialogResult xxx = MessageBox.Show("Eokul'dan " + SlnGetData.School + " okul türünde\n" + (dataGridView1.Rows.Count - 1) + " Öğrenci\nBilgisi Çekilecek?", "Son Kontroller", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (xxx == DialogResult.No)
                {
                    return;
                }

                foreach (string item in ogrenciListBox.CheckedItems) AddColumn(item);
                foreach (string item in babaListBox.CheckedItems) AddColumn(item);
                foreach (string item in anneListBox.CheckedItems) AddColumn(item);


                if (satir != endingRow)
                {
                    DialogResult result = MessageBox.Show("İşlem Kaldığı Yerden Devam Etsin Mi?", "Uyarı", MessageBoxButtons.YesNo);

                    satir = (result == DialogResult.Yes) ? endingRow : 0;
                }
                progressBar1.Maximum = dataGridView1.Rows.Count + 1;
                progressBar1.Value = satir;

                while (satir < dataGridView1.Rows.Count - 1)

                {
                    DataGridViewRow dr = dataGridView1.Rows[satir];
                    progressBar1.Value++;
                    try
                    {
                        //Öğrernci bilgi çekmek
                        SlnGetData.SearchStudent(dr.Cells["Ogr_No"].Value.ToString());
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            if (column.Index != 0)
                            {
                                dr.Cells[column.Name].Value = typeof(SlnGetData).GetMethod("Get_" + column.Name).Invoke(typeof(SlnGetData), null);
                            }

                        }

                        endingRow = satir;
                    }
                    catch
                    { }
                    finally
                    {
                        satir++;
                        Application.DoEvents();
                    }
                }
                progressBar1.Value = progressBar1.Maximum;
                get_Data.Text = "Bilgileri Çek";

            }
        }





        private void topmost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = topmost.Checked;
        }


        private void school_rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            SlnGetData.Set_School(rb.Name);
            if (rb.Name != "OrtaOgretim")
            {
                sub_School.Enabled = false;
                SlnGetData.SubSchool = "";
                label1.Enabled = false;
            }
            else
            {
                sub_School.Enabled = true;
                SlnGetData.SubSchool = sub_School.Text;
                label1.Enabled = true;
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void speed_rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            SlnGetData.Set_Speed(rb.Name);
        }



        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void sub_School_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlnGetData.SubSchool = sub_School.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (string item in babaListBox.CheckedItems) AddColumn(item);


        }
    }
}
