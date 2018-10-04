namespace WFGangReader
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.WFGangConnectButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eksportListDoXlsButton = new System.Windows.Forms.Button();
            this.wybierzSkladnikiButton = new System.Windows.Forms.Button();
            this.OdwrocZaznaczButton = new System.Windows.Forms.Button();
            this.serverHostBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dbNameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.wyborFirmyComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WFGangConnectButton
            // 
            this.WFGangConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WFGangConnectButton.Location = new System.Drawing.Point(12, 17);
            this.WFGangConnectButton.Name = "WFGangConnectButton";
            this.WFGangConnectButton.Size = new System.Drawing.Size(108, 46);
            this.WFGangConnectButton.TabIndex = 5;
            this.WFGangConnectButton.Text = "POŁĄCZ";
            this.WFGangConnectButton.UseVisualStyleBackColor = true;
            this.WFGangConnectButton.Click += new System.EventHandler(this.WFGangConnectButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 580);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(615, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(12, 230);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(108, 20);
            this.PasswordBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "hasło do bazy";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.disconnectButton.Location = new System.Drawing.Point(13, 262);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(105, 36);
            this.disconnectButton.TabIndex = 6;
            this.disconnectButton.Text = "ROZŁĄCZ";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy MM";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(325, 44);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(161, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.onDateTimePicker1ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dostępne listy płac dla ";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Enabled = false;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(126, 69);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(360, 508);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID LISTY";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "NAZWA";
            this.columnHeader2.Width = 52;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "NUMER";
            this.columnHeader3.Width = 300;
            // 
            // eksportListDoXlsButton
            // 
            this.eksportListDoXlsButton.Enabled = false;
            this.eksportListDoXlsButton.Location = new System.Drawing.Point(489, 156);
            this.eksportListDoXlsButton.Name = "eksportListDoXlsButton";
            this.eksportListDoXlsButton.Size = new System.Drawing.Size(114, 47);
            this.eksportListDoXlsButton.TabIndex = 11;
            this.eksportListDoXlsButton.Text = "Eksport wybranych list do xls";
            this.eksportListDoXlsButton.UseVisualStyleBackColor = true;
            this.eksportListDoXlsButton.Click += new System.EventHandler(this.eksportListDoXlsButton_Click);
            // 
            // wybierzSkladnikiButton
            // 
            this.wybierzSkladnikiButton.Enabled = false;
            this.wybierzSkladnikiButton.Location = new System.Drawing.Point(489, 104);
            this.wybierzSkladnikiButton.Name = "wybierzSkladnikiButton";
            this.wybierzSkladnikiButton.Size = new System.Drawing.Size(114, 46);
            this.wybierzSkladnikiButton.TabIndex = 10;
            this.wybierzSkladnikiButton.Text = "Wybierz składniki listy do eksportu";
            this.wybierzSkladnikiButton.UseVisualStyleBackColor = true;
            this.wybierzSkladnikiButton.Click += new System.EventHandler(this.wybierzSkladnikiButton_Click);
            // 
            // OdwrocZaznaczButton
            // 
            this.OdwrocZaznaczButton.Enabled = false;
            this.OdwrocZaznaczButton.Location = new System.Drawing.Point(489, 69);
            this.OdwrocZaznaczButton.Name = "OdwrocZaznaczButton";
            this.OdwrocZaznaczButton.Size = new System.Drawing.Size(114, 29);
            this.OdwrocZaznaczButton.TabIndex = 11;
            this.OdwrocZaznaczButton.Text = "Odwróć zaznaczenie";
            this.OdwrocZaznaczButton.UseVisualStyleBackColor = true;
            this.OdwrocZaznaczButton.Click += new System.EventHandler(this.OdwrocZaznaczButton_Click);
            // 
            // serverHostBox
            // 
            this.serverHostBox.Location = new System.Drawing.Point(12, 95);
            this.serverHostBox.Name = "serverHostBox";
            this.serverHostBox.Size = new System.Drawing.Size(108, 20);
            this.serverHostBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "serwer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "login";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(12, 186);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(108, 20);
            this.loginBox.TabIndex = 3;
            this.loginBox.Text = "sa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "nazwa bazy";
            // 
            // dbNameBox
            // 
            this.dbNameBox.Location = new System.Drawing.Point(12, 142);
            this.dbNameBox.Name = "dbNameBox";
            this.dbNameBox.Size = new System.Drawing.Size(108, 20);
            this.dbNameBox.TabIndex = 2;
            this.dbNameBox.Text = "WFGANG";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Firma";
            // 
            // wyborFirmyComboBox
            // 
            this.wyborFirmyComboBox.Enabled = false;
            this.wyborFirmyComboBox.FormattingEnabled = true;
            this.wyborFirmyComboBox.Location = new System.Drawing.Point(247, 17);
            this.wyborFirmyComboBox.Name = "wyborFirmyComboBox";
            this.wyborFirmyComboBox.Size = new System.Drawing.Size(239, 21);
            this.wyborFirmyComboBox.TabIndex = 19;
            this.wyborFirmyComboBox.SelectionChangeCommitted += new System.EventHandler(this.wyborFirmyComboBox_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 602);
            this.Controls.Add(this.wyborFirmyComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dbNameBox);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serverHostBox);
            this.Controls.Add(this.OdwrocZaznaczButton);
            this.Controls.Add(this.wybierzSkladnikiButton);
            this.Controls.Add(this.eksportListDoXlsButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.WFGangConnectButton);
            this.Name = "Form1";
            this.Text = "WFGangReader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WFGangConnectButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button eksportListDoXlsButton;
        private System.Windows.Forms.Button wybierzSkladnikiButton;
        private System.Windows.Forms.Button OdwrocZaznaczButton;
        private System.Windows.Forms.TextBox serverHostBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dbNameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox wyborFirmyComboBox;
    }
}

