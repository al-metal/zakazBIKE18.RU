namespace Обработчик_заказов_BIKE18.RU
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nomer_zakaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zakazchik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oplata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stoimost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_soadaniya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_puth_dogovor = new System.Windows.Forms.TextBox();
            this.button_file_dogovor = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox_com_manager = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_login_nethouse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_pass_nethouse = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_pochta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_pass_pocha = new System.Windows.Forms.TextBox();
            this.button_auth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomer_zakaza,
            this.zakazchik,
            this.status,
            this.oplata,
            this.stoimost,
            this.data_soadaniya});
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(948, 315);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // nomer_zakaza
            // 
            this.nomer_zakaza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nomer_zakaza.Frozen = true;
            this.nomer_zakaza.HeaderText = "№ заказа";
            this.nomer_zakaza.Name = "nomer_zakaza";
            this.nomer_zakaza.ReadOnly = true;
            this.nomer_zakaza.Width = 187;
            // 
            // zakazchik
            // 
            this.zakazchik.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.zakazchik.HeaderText = "Заказчик";
            this.zakazchik.Name = "zakazchik";
            this.zakazchik.ReadOnly = true;
            this.zakazchik.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.zakazchik.Width = 187;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.status.Width = 187;
            // 
            // oplata
            // 
            this.oplata.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.oplata.HeaderText = "Оплата";
            this.oplata.Name = "oplata";
            this.oplata.ReadOnly = true;
            this.oplata.Width = 187;
            // 
            // stoimost
            // 
            this.stoimost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.stoimost.HeaderText = "Стоимость";
            this.stoimost.Name = "stoimost";
            this.stoimost.ReadOnly = true;
            this.stoimost.Width = 187;
            // 
            // data_soadaniya
            // 
            this.data_soadaniya.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.data_soadaniya.HeaderText = "Дата создания";
            this.data_soadaniya.Name = "data_soadaniya";
            this.data_soadaniya.ReadOnly = true;
            this.data_soadaniya.Width = 187;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Обработать выделенные заказы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(222, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "Обработка с прикреплением договора";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(226, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Обработка без прикрепления договора";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_puth_dogovor);
            this.groupBox1.Controls.Add(this.button_file_dogovor);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(310, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 157);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обработка заказов";
            // 
            // textBox_puth_dogovor
            // 
            this.textBox_puth_dogovor.Enabled = false;
            this.textBox_puth_dogovor.Location = new System.Drawing.Point(75, 70);
            this.textBox_puth_dogovor.Name = "textBox_puth_dogovor";
            this.textBox_puth_dogovor.Size = new System.Drawing.Size(211, 20);
            this.textBox_puth_dogovor.TabIndex = 5;
            // 
            // button_file_dogovor
            // 
            this.button_file_dogovor.Enabled = false;
            this.button_file_dogovor.Location = new System.Drawing.Point(6, 67);
            this.button_file_dogovor.Name = "button_file_dogovor";
            this.button_file_dogovor.Size = new System.Drawing.Size(63, 23);
            this.button_file_dogovor.TabIndex = 4;
            this.button_file_dogovor.Text = "Browse...";
            this.button_file_dogovor.UseVisualStyleBackColor = true;
            this.button_file_dogovor.Click += new System.EventHandler(this.button_file_dogovor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new System.Drawing.Point(619, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 157);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Лог";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 18);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(330, 133);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(886, 349);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 37);
            this.button3.TabIndex = 8;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(439, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Страница 1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(886, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(75, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "О программе";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox_com_manager);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBox_price);
            this.groupBox3.Location = new System.Drawing.Point(19, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 157);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры";
            // 
            // richTextBox_com_manager
            // 
            this.richTextBox_com_manager.Location = new System.Drawing.Point(97, 73);
            this.richTextBox_com_manager.Name = "richTextBox_com_manager";
            this.richTextBox_com_manager.Size = new System.Drawing.Size(170, 78);
            this.richTextBox_com_manager.TabIndex = 4;
            this.richTextBox_com_manager.Text = "Произведите оплату вашего заказа удобным для вас способом. Срок доставки 2-3 неде" +
    "ли с момента оплаты.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Комментарий\r\nменеджера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Цена";
            // 
            // textBox_price
            // 
            this.textBox_price.Location = new System.Drawing.Point(97, 39);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(100, 20);
            this.textBox_price.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Логин nethouse.ru";
            // 
            // textBox_login_nethouse
            // 
            this.textBox_login_nethouse.Location = new System.Drawing.Point(116, 2);
            this.textBox_login_nethouse.Name = "textBox_login_nethouse";
            this.textBox_login_nethouse.Size = new System.Drawing.Size(100, 20);
            this.textBox_login_nethouse.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Пароль nethouse.ru";
            // 
            // textBox_pass_nethouse
            // 
            this.textBox_pass_nethouse.Location = new System.Drawing.Point(332, 2);
            this.textBox_pass_nethouse.Name = "textBox_pass_nethouse";
            this.textBox_pass_nethouse.PasswordChar = '*';
            this.textBox_pass_nethouse.Size = new System.Drawing.Size(100, 20);
            this.textBox_pass_nethouse.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(439, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Почта";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox_pochta
            // 
            this.textBox_pochta.Location = new System.Drawing.Point(482, 2);
            this.textBox_pochta.Name = "textBox_pochta";
            this.textBox_pochta.Size = new System.Drawing.Size(100, 20);
            this.textBox_pochta.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(588, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Пароль от почты";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBox_pass_pocha
            // 
            this.textBox_pass_pocha.Location = new System.Drawing.Point(686, 2);
            this.textBox_pass_pocha.Name = "textBox_pass_pocha";
            this.textBox_pass_pocha.PasswordChar = '*';
            this.textBox_pass_pocha.Size = new System.Drawing.Size(100, 20);
            this.textBox_pass_pocha.TabIndex = 21;
            this.textBox_pass_pocha.TextChanged += new System.EventHandler(this.textBox_pass_pocha_TextChanged);
            // 
            // button_auth
            // 
            this.button_auth.Enabled = false;
            this.button_auth.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_auth.Location = new System.Drawing.Point(792, 1);
            this.button_auth.Name = "button_auth";
            this.button_auth.Size = new System.Drawing.Size(88, 21);
            this.button_auth.TabIndex = 22;
            this.button_auth.Text = "Auth";
            this.button_auth.UseVisualStyleBackColor = true;
            this.button_auth.Click += new System.EventHandler(this.button_auth_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 558);
            this.Controls.Add(this.button_auth);
            this.Controls.Add(this.textBox_pass_pocha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_pochta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_pass_nethouse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_login_nethouse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Обработчик заказов BIKE18.RU";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomer_zakaza;
        private System.Windows.Forms.DataGridViewTextBoxColumn zakazchik;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn oplata;
        private System.Windows.Forms.DataGridViewTextBoxColumn stoimost;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_soadaniya;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_com_manager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_login_nethouse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_pass_nethouse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_pochta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_pass_pocha;
        private System.Windows.Forms.TextBox textBox_puth_dogovor;
        private System.Windows.Forms.Button button_file_dogovor;
        private System.Windows.Forms.Button button_auth;
    }
}

