namespace WFGangReader
{
    partial class wyborSkladnikow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zatwierdzSkladniki = new System.Windows.Forms.Button();
            this.ZaznaczWszystkieButton = new System.Windows.Forms.Button();
            this.OdznaczWszystkieButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(601, 773);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "KOLEJNOSC";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "NAZWA";
            this.columnHeader2.Width = 400;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID_SKLADNIKA";
            this.columnHeader3.Width = 90;
            // 
            // zatwierdzSkladniki
            // 
            this.zatwierdzSkladniki.Location = new System.Drawing.Point(619, 12);
            this.zatwierdzSkladniki.Name = "zatwierdzSkladniki";
            this.zatwierdzSkladniki.Size = new System.Drawing.Size(98, 80);
            this.zatwierdzSkladniki.TabIndex = 1;
            this.zatwierdzSkladniki.Text = "Zatwierdź składniki";
            this.zatwierdzSkladniki.UseVisualStyleBackColor = true;
            this.zatwierdzSkladniki.Click += new System.EventHandler(this.zatwierdzSkladniki_Click);
            // 
            // ZaznaczWszystkieButton
            // 
            this.ZaznaczWszystkieButton.Location = new System.Drawing.Point(619, 134);
            this.ZaznaczWszystkieButton.Name = "ZaznaczWszystkieButton";
            this.ZaznaczWszystkieButton.Size = new System.Drawing.Size(98, 52);
            this.ZaznaczWszystkieButton.TabIndex = 2;
            this.ZaznaczWszystkieButton.Text = "Zaznacz wszystkie";
            this.ZaznaczWszystkieButton.UseVisualStyleBackColor = true;
            this.ZaznaczWszystkieButton.Click += new System.EventHandler(this.ZaznaczWszystkieButton_Click);
            // 
            // OdznaczWszystkieButton
            // 
            this.OdznaczWszystkieButton.Location = new System.Drawing.Point(619, 192);
            this.OdznaczWszystkieButton.Name = "OdznaczWszystkieButton";
            this.OdznaczWszystkieButton.Size = new System.Drawing.Size(98, 51);
            this.OdznaczWszystkieButton.TabIndex = 3;
            this.OdznaczWszystkieButton.Text = "Odznacz wszystkie";
            this.OdznaczWszystkieButton.UseVisualStyleBackColor = true;
            this.OdznaczWszystkieButton.Click += new System.EventHandler(this.OdznaczWszystkieButton_Click);
            // 
            // wyborSkladnikow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 797);
            this.Controls.Add(this.OdznaczWszystkieButton);
            this.Controls.Add(this.ZaznaczWszystkieButton);
            this.Controls.Add(this.zatwierdzSkladniki);
            this.Controls.Add(this.listView1);
            this.Name = "wyborSkladnikow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybór składników listy płac";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button zatwierdzSkladniki;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button ZaznaczWszystkieButton;
        private System.Windows.Forms.Button OdznaczWszystkieButton;
    }
}