namespace atiba
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.coyp_Data = new System.Windows.Forms.Button();
            this.set_Data_Excel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.get_Data = new System.Windows.Forms.Button();
            this.get_student = new System.Windows.Forms.Button();
            this.get_students_List = new System.Windows.Forms.Button();
            this.open_Eokul = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.speed_rb_slower = new System.Windows.Forms.RadioButton();
            this.speed_rb_slow = new System.Windows.Forms.RadioButton();
            this.speed_rb_normal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sub_School = new System.Windows.Forms.ComboBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.anneListBox = new System.Windows.Forms.CheckedListBox();
            this.babaListBox = new System.Windows.Forms.CheckedListBox();
            this.ogrenciListBox = new System.Windows.Forms.CheckedListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(650, 528);
            this.tabControl2.TabIndex = 31;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Controls.Add(this.coyp_Data);
            this.tabPage4.Controls.Add(this.set_Data_Excel);
            this.tabPage4.Controls.Add(this.progressBar1);
            this.tabPage4.Controls.Add(this.get_Data);
            this.tabPage4.Controls.Add(this.get_student);
            this.tabPage4.Controls.Add(this.get_students_List);
            this.tabPage4.Controls.Add(this.open_Eokul);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(642, 502);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Veri Sayfası";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(535, 484);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "Her zaman üstte";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // coyp_Data
            // 
            this.coyp_Data.Location = new System.Drawing.Point(493, 438);
            this.coyp_Data.Name = "coyp_Data";
            this.coyp_Data.Size = new System.Drawing.Size(70, 43);
            this.coyp_Data.TabIndex = 37;
            this.coyp_Data.Text = "Verileri Kopyala";
            this.coyp_Data.UseVisualStyleBackColor = true;
            this.coyp_Data.Click += new System.EventHandler(this.coyp_Data_Click);
            // 
            // set_Data_Excel
            // 
            this.set_Data_Excel.Location = new System.Drawing.Point(569, 438);
            this.set_Data_Excel.Name = "set_Data_Excel";
            this.set_Data_Excel.Size = new System.Drawing.Size(70, 43);
            this.set_Data_Excel.TabIndex = 36;
            this.set_Data_Excel.Text = "Excel\'e Aktar";
            this.set_Data_Excel.UseVisualStyleBackColor = true;
            this.set_Data_Excel.Click += new System.EventHandler(this.set_Data_Excel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(638, 23);
            this.progressBar1.TabIndex = 35;
            // 
            // get_Data
            // 
            this.get_Data.Location = new System.Drawing.Point(326, 438);
            this.get_Data.Name = "get_Data";
            this.get_Data.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.get_Data.Size = new System.Drawing.Size(102, 61);
            this.get_Data.TabIndex = 34;
            this.get_Data.Text = "Bilgileri Çek";
            this.get_Data.UseVisualStyleBackColor = true;
            this.get_Data.Click += new System.EventHandler(this.get_Data_Click);
            // 
            // get_student
            // 
            this.get_student.Location = new System.Drawing.Point(82, 439);
            this.get_student.Margin = new System.Windows.Forms.Padding(2);
            this.get_student.Name = "get_student";
            this.get_student.Size = new System.Drawing.Size(75, 61);
            this.get_student.TabIndex = 33;
            this.get_student.Text = "Öğrenci Elle Ekleme";
            this.get_student.UseVisualStyleBackColor = true;
            this.get_student.Click += new System.EventHandler(this.get_student_Click);
            // 
            // get_students_List
            // 
            this.get_students_List.Location = new System.Drawing.Point(0, 439);
            this.get_students_List.Name = "get_students_List";
            this.get_students_List.Size = new System.Drawing.Size(77, 61);
            this.get_students_List.TabIndex = 31;
            this.get_students_List.Text = "Öğrenci Listesi Yükle";
            this.get_students_List.UseVisualStyleBackColor = true;
            this.get_students_List.Click += new System.EventHandler(this.get_students_List_Click);
            // 
            // open_Eokul
            // 
            this.open_Eokul.Location = new System.Drawing.Point(242, 438);
            this.open_Eokul.Name = "open_Eokul";
            this.open_Eokul.Size = new System.Drawing.Size(78, 61);
            this.open_Eokul.TabIndex = 32;
            this.open_Eokul.Text = "e-Okul Aç";
            this.open_Eokul.UseVisualStyleBackColor = true;
            this.open_Eokul.Click += new System.EventHandler(this.open_Eokul_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.Size = new System.Drawing.Size(639, 403);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Controls.Add(this.anneListBox);
            this.tabPage5.Controls.Add(this.babaListBox);
            this.tabPage5.Controls.Add(this.ogrenciListBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage5.Size = new System.Drawing.Size(642, 502);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Ayarlar";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.speed_rb_slower);
            this.groupBox1.Controls.Add(this.speed_rb_slow);
            this.groupBox1.Controls.Add(this.speed_rb_normal);
            this.groupBox1.Location = new System.Drawing.Point(306, 302);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(141, 127);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veri Çekme Hızı";
            // 
            // speed_rb_slower
            // 
            this.speed_rb_slower.AutoSize = true;
            this.speed_rb_slower.Location = new System.Drawing.Point(6, 53);
            this.speed_rb_slower.Margin = new System.Windows.Forms.Padding(2);
            this.speed_rb_slower.Name = "speed_rb_slower";
            this.speed_rb_slower.Size = new System.Drawing.Size(77, 17);
            this.speed_rb_slower.TabIndex = 2;
            this.speed_rb_slower.Text = "Çok Yavaş";
            this.speed_rb_slower.UseVisualStyleBackColor = true;
            // 
            // speed_rb_slow
            // 
            this.speed_rb_slow.AutoSize = true;
            this.speed_rb_slow.Location = new System.Drawing.Point(6, 35);
            this.speed_rb_slow.Margin = new System.Windows.Forms.Padding(2);
            this.speed_rb_slow.Name = "speed_rb_slow";
            this.speed_rb_slow.Size = new System.Drawing.Size(55, 17);
            this.speed_rb_slow.TabIndex = 1;
            this.speed_rb_slow.Text = "Yavaş";
            this.speed_rb_slow.UseVisualStyleBackColor = true;
            // 
            // speed_rb_normal
            // 
            this.speed_rb_normal.AutoSize = true;
            this.speed_rb_normal.Checked = true;
            this.speed_rb_normal.Location = new System.Drawing.Point(6, 17);
            this.speed_rb_normal.Margin = new System.Windows.Forms.Padding(2);
            this.speed_rb_normal.Name = "speed_rb_normal";
            this.speed_rb_normal.Size = new System.Drawing.Size(58, 17);
            this.speed_rb_normal.TabIndex = 0;
            this.speed_rb_normal.TabStop = true;
            this.speed_rb_normal.Text = "Normal";
            this.speed_rb_normal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.sub_School);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(12, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 127);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Okul Türü";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(22, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Lise Türü seçiniz";
            // 
            // sub_School
            // 
            this.sub_School.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sub_School.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sub_School.FormattingEnabled = true;
            this.sub_School.Items.AddRange(new object[] {
            "Lise",
            "Anadolu Meslek Programı",
            "Anadolu Teknik Programı"});
            this.sub_School.Location = new System.Drawing.Point(112, 52);
            this.sub_School.Margin = new System.Windows.Forms.Padding(2);
            this.sub_School.Name = "sub_School";
            this.sub_School.Size = new System.Drawing.Size(172, 21);
            this.sub_School.TabIndex = 32;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 102);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(136, 17);
            this.radioButton4.TabIndex = 31;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "*Okul Öncesi (Deneme)";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 79);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(99, 17);
            this.radioButton3.TabIndex = 30;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "AİHL (Alternatif)";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(44, 17);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.Text = "Lise";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(107, 17);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "İlkokul / Ortaokul";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // anneListBox
            // 
            this.anneListBox.FormattingEnabled = true;
            this.anneListBox.Items.AddRange(new object[] {
            "Anne Ad-Soyad",
            "Anne TC No",
            "Anne Tel",
            "Anne Sağ/Ölü",
            "Anne Birlikte/Ayrı",
            "Anne Mezuniyet",
            "Anne Doğum Tarihi",
            "Anne Meslek"});
            this.anneListBox.Location = new System.Drawing.Point(304, 18);
            this.anneListBox.Name = "anneListBox";
            this.anneListBox.Size = new System.Drawing.Size(143, 274);
            this.anneListBox.TabIndex = 7;
            // 
            // babaListBox
            // 
            this.babaListBox.FormattingEnabled = true;
            this.babaListBox.Items.AddRange(new object[] {
            "Baba Ad-Soyad",
            "Baba TC No",
            "Baba Tel",
            "Baba Sağ/Ölü",
            "Baba Birlikte/Ayrı",
            "Baba Mezuniyet",
            "Baba Doğum Tarihi",
            "Baba Meslek"});
            this.babaListBox.Location = new System.Drawing.Point(158, 18);
            this.babaListBox.Name = "babaListBox";
            this.babaListBox.Size = new System.Drawing.Size(143, 274);
            this.babaListBox.TabIndex = 6;
            // 
            // ogrenciListBox
            // 
            this.ogrenciListBox.FormattingEnabled = true;
            this.ogrenciListBox.Items.AddRange(new object[] {
            "Öğrenci Ad-Soyad",
            "Öğrenci TC No",
            "Öğrenci Sınıf",
            "Öğrenci Fotoğraf",
            "Veli",
            "Uyruğu",
            "Cinsiyeti",
            "Doğum Tarihi",
            "Doğum Yeri",
            "Cilt No",
            "Aile Sıra No",
            "Sıra No",
            "Mahalle-Köy",
            "Boy",
            "Kilo",
            "Taşıma",
            "Özürlü Devamsızlık",
            "Özürsüz Devamsızlık"});
            this.ogrenciListBox.Location = new System.Drawing.Point(12, 17);
            this.ogrenciListBox.Name = "ogrenciListBox";
            this.ogrenciListBox.Size = new System.Drawing.Size(142, 274);
            this.ogrenciListBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 526);
            this.Controls.Add(this.tabControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atiba - eOkul Scrapper 3.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button coyp_Data;
        private System.Windows.Forms.Button set_Data_Excel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button get_Data;
        private System.Windows.Forms.Button get_student;
        private System.Windows.Forms.Button get_students_List;
        private System.Windows.Forms.Button open_Eokul;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton speed_rb_slower;
        private System.Windows.Forms.RadioButton speed_rb_slow;
        private System.Windows.Forms.RadioButton speed_rb_normal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckedListBox anneListBox;
        private System.Windows.Forms.CheckedListBox babaListBox;
        private System.Windows.Forms.CheckedListBox ogrenciListBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox sub_School;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
    }
}

