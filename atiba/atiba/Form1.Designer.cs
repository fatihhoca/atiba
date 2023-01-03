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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ogrenciListBox = new System.Windows.Forms.CheckedListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button5 = new System.Windows.Forms.Button();
            this.babaListBox = new System.Windows.Forms.CheckedListBox();
            this.anneListBox = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.speed_rb_slower = new System.Windows.Forms.RadioButton();
            this.speed_rb_slow = new System.Windows.Forms.RadioButton();
            this.speed_rb_normal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Öğrenci Listesi Yükle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "e-Okul Aç";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(2, 493);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 49);
            this.button3.TabIndex = 9;
            this.button3.Text = "Bilgileri Çek";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(149, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.Size = new System.Drawing.Size(830, 624);
            this.dataGridView1.TabIndex = 1;
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
            "Mahalle-Köy",
            "Boy",
            "Kilo",
            "Taşıma",
            "Özürlü Devamsızlık",
            "Özürsüz Devamsızlık"});
            this.ogrenciListBox.Location = new System.Drawing.Point(0, 0);
            this.ogrenciListBox.Name = "ogrenciListBox";
            this.ogrenciListBox.Size = new System.Drawing.Size(135, 214);
            this.ogrenciListBox.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(2, 579);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Excel\'e Aktar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 544);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(145, 23);
            this.progressBar1.TabIndex = 25;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(2, 603);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "Verileri Kopyala";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.babaListBox.Location = new System.Drawing.Point(0, 0);
            this.babaListBox.Name = "babaListBox";
            this.babaListBox.Size = new System.Drawing.Size(135, 109);
            this.babaListBox.TabIndex = 5;
            this.babaListBox.SelectedIndexChanged += new System.EventHandler(this.babaListBox_SelectedIndexChanged);
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
            this.anneListBox.Location = new System.Drawing.Point(0, 0);
            this.anneListBox.Name = "anneListBox";
            this.anneListBox.Size = new System.Drawing.Size(135, 109);
            this.anneListBox.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(145, 240);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ogrenciListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(137, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Öğrenci";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.babaListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(137, 228);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Baba";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.anneListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(137, 228);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Anne";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.speed_rb_slower);
            this.groupBox1.Controls.Add(this.speed_rb_slow);
            this.groupBox1.Controls.Add(this.speed_rb_normal);
            this.groupBox1.Location = new System.Drawing.Point(6, 413);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(141, 77);
            this.groupBox1.TabIndex = 28;
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
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(6, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 91);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Okul Türü";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 70);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(136, 17);
            this.radioButton4.TabIndex = 31;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "*Okul Öncesi (Deneme)";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 53);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(99, 17);
            this.radioButton3.TabIndex = 30;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "AİHL (Alternatif)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 36);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(44, 17);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.Text = "Lise";
            this.radioButton2.UseVisualStyleBackColor = true;
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
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(77, 2);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 40);
            this.button6.TabIndex = 30;
            this.button6.Text = "Öğrenci Elle Ekleme";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 629);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atiba - eOkul Scrapper 3.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox ogrenciListBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckedListBox babaListBox;
        private System.Windows.Forms.CheckedListBox anneListBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton speed_rb_slower;
        private System.Windows.Forms.RadioButton speed_rb_slow;
        private System.Windows.Forms.RadioButton speed_rb_normal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button button6;
    }
}

