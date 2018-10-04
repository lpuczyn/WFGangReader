using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WFGangReader
{
    partial class wyborSkladnikow : Form
    {
        Form1 form1;

        public _SQLConnection _conn;
        public Dictionary<decimal, SkladnikPlacowy> listaSkladnikow;
        private FileStream listaSkladnikowKonfig;

        public wyborSkladnikow( Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this._conn = form1._conn;
            this.listaSkladnikow = form1.listaSkladnikow;

            this.listView1Reset();
            this.pobierzListeSkladnikow();
            this.wczytajWybraneZPliku();
            this.wypelnijListeSkladnikow();

        }

        private void listView1Reset()
        {
            
            this.listView1.Clear();
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnHeader1,
                this.columnHeader2,
                this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.columnHeader1.Text = "KOLEJNOSC";
            this.columnHeader1.Width = 100;
            this.columnHeader2.Text = "NAZWA";
            this.columnHeader2.Width = 100;
            this.columnHeader3.Text = "ID_SKLADNIKA";
            this.columnHeader3.Width = 100;

        }

        private void pobierzListeSkladnikow()
        {
            string query = "SELECT KOLEJNOSC, ID_SKLADNIKA, NAZWA from SKLADNIK_PLACOWY " +
                           "WHERE ID_TYPU_LISTY=1 ORDER BY KOLEJNOSC ASC";

            DataTable dt = _conn.ExecSql(query);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                listaSkladnikow[dr.Field<decimal>("ID_SKLADNIKA")] =
                            new SkladnikPlacowy(dr.Field<int>("KOLEJNOSC"), 
                                                dr.Field<decimal>("ID_SKLADNIKA"),
                                                dr.Field<string>("NAZWA"));                
            }
        }

        private void wypelnijListeSkladnikow()
        {
            foreach ( SkladnikPlacowy sp in listaSkladnikow.Values)
            {
                ListViewItem listitem = new ListViewItem(sp.Kolejnosc().ToString());
                listitem.SubItems.Add(sp.Nazwa());
                listitem.SubItems.Add(sp.IdSkladnika().ToString());
                this.listView1.Items.Add(listitem);
                if( sp.Wybrany()) { listitem.Checked = true; }
            }
            this.listView1.Columns[1].Width = -1;
            this.listView1.Columns[2].Width = 100;
        }

        private void ustawWybraneSkladniki()
        {
            foreach (ListViewItem li in listView1.Items)
            {
                decimal idSkladnika = decimal.Parse(li.SubItems[2].Text);
                SkladnikPlacowy sp = listaSkladnikow[idSkladnika];
                if (li.Checked) { sp.setWybrany(true); } else { sp.setWybrany(false); }
            }
        }

        private void zapiszSkladnikiDoPliku()
        {
            try
            {
                this.listaSkladnikowKonfig = new FileStream(form1.filepath +
                    form1.listaSkladnikowKonfigFileName,
                    FileMode.Create,
                    FileAccess.Write);
                StreamWriter sw = new StreamWriter(listaSkladnikowKonfig);
                List<string> buf = new List<string>();
                foreach( ListViewItem li in listView1.Items)
                {
                    if (li.Checked)
                    {
                        buf.Add(li.SubItems[2].Text);
                    }                    
                }
                sw.WriteLine(string.Join(";", buf));
                sw.Close();
            }catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void wczytajWybraneZPliku()
        {
            try
            {
                this.listaSkladnikowKonfig = new FileStream(form1.filepath +
                    form1.listaSkladnikowKonfigFileName,
                    FileMode.OpenOrCreate,
                    FileAccess.Read);
                StreamReader sr = new StreamReader(listaSkladnikowKonfig);
                string buf = sr.ReadToEnd();
                string[] bufSplitted = buf.Trim().Split(';');
                sr.Close();

                HashSet<decimal> wybraneSkladniki = new HashSet<decimal>();
                foreach ( string idSkladnika in bufSplitted)
                {
                    decimal s;
                    if (decimal.TryParse(idSkladnika, out s)) {
                        wybraneSkladniki.Add(s);
                    }                    
                }
                
                foreach (decimal idSkladnika in listaSkladnikow.Keys)
                {
                    SkladnikPlacowy sp = listaSkladnikow[idSkladnika];
                    if (wybraneSkladniki.Contains(idSkladnika))
                    {
                        sp.setWybrany(true);
                    } else {
                        sp.setWybrany(false);
                    }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void zatwierdzSkladniki_Click(object sender, EventArgs e)
        {
            this.ustawWybraneSkladniki();
            this.zapiszSkladnikiDoPliku();
            this.Close();
        }

        private void ZaznaczWszystkieButton_Click(object sender, EventArgs e)
        {
            foreach ( ListViewItem li in listView1.Items)
            {
                if( !li.Checked)
                {
                    li.Checked = true;
                }
            }
        }

        private void OdznaczWszystkieButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in listView1.Items)
            {
                if (li.Checked)
                {
                    li.Checked = false;
                }
            }
        }
    }
}
