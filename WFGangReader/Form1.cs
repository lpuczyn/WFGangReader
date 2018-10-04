using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;


/*  schemat tabel bazy danych
 *  dbo_WARTOSC_SKLADNIKA
 *      ID_PRACOWNIK numeric
 *      ID_LISTY    numeric
 *      ID_SKLADNIKA numeric
 *      WARTOSC decimal
 * 
 *  dbo_SKLADNIK_PLACOWY
 *      ID_SKLADNIKA
 *      NAZWA
 *      
 *  dbo_PRZYPORZADKOWANIE
 *      ID_LISTY
 *      ID_PRACOWNIKA
 *      
 *  dbo_LISTA_PLAC
 *      ID_LISTY
 *      ID_TYPU_LISTY
 *      NAZWA
 *      NUMER
 *      
 *  dbo_PRACOWNIK
 *      ID_PRACOWNIKA
 *      KOD_PRACOWNIKA
 *      NAZWISKO
 *      IMIE_1
 *      
 */

namespace WFGangReader

{
    partial class Form1 : Form
    {

        public _SQLConnection _conn = new _SQLConnection();
        public Dictionary<decimal, SkladnikPlacowy> listaSkladnikow = 
            new Dictionary<decimal, SkladnikPlacowy>();
        public SortedDictionary<decimal, ListaPlac> listaListPlac =
            new SortedDictionary<decimal, ListaPlac>();
        
        private FileStream listaSkladnikowKonfig;
        private SortedDictionary<decimal, Firma> firmy;
        private decimal idWybranaFirma = 1;

        public string listaSkladnikowKonfigFileName = "WFGANG_listaSkladnikowKonfig.txt";
        public string filepath = Application.StartupPath;

        public int date2GDate(DateTime d)
        {
            DateTime firstOfMonth = new DateTime(d.Year, d.Month, 1);
            DateTime gangDate = new DateTime(1800, 12, 28);
            return (int)(firstOfMonth - gangDate).TotalDays;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool daneLogowaniaNiepuste()
        {
            if (serverHostBox.Text == "")
            {
                toolStripStatusLabel1.Text = "Wpisz adres serwera do połączenia!";
                return false;
            }

            if (dbNameBox.Text == "")
            {
                toolStripStatusLabel1.Text = "Wpisz nazwę bazy danych do połączenia!";
                return false;
            }

            if (loginBox.Text == "")
            {
                toolStripStatusLabel1.Text = "Wpisz login do połączenia!";
                return false;
            }

            if (PasswordBox.Text == "")
            {
                toolStripStatusLabel1.Text = "Wpisz hasło do połączenia!";
                return false;
            }
            return true;
        }

        private void aktualizujWyborFirmyComboBox()
        {
            wyborFirmyComboBox.Items.Clear();
            wyborFirmyComboBox.DataSource = new BindingSource(firmy, null);
            wyborFirmyComboBox.DisplayMember = "Value";
            wyborFirmyComboBox.ValueMember = "Key";

        }

        private void WFGangConnectButton_Click(object sender, EventArgs e)
        {
            if (!daneLogowaniaNiepuste())
            {
                return;
            }

            toolStripStatusLabel1.Text = "Łącze z bazą ...";

            _conn.UpdateConnectionString(   host:serverHostBox.Text,
                                            dbname:dbNameBox.Text,
                                            user:loginBox.Text,
                                            pass:PasswordBox.Text);

            listaSkladnikowKonfigFileName = "WFGANG_listaSkladnikowKonfig.txt";

            if ( _conn.ConnectDb() == true)
            {
                toolStripStatusLabel1.Text = "Połączono z " + dbNameBox.Text;
                WFGangConnectButton.Enabled = false;
                disconnectButton.Enabled = true;
                
                this.firmy = Firma.pobierzFirmy(_conn);

                if(this.firmy.Count > 0)
                {
                    this.wyborFirmyComboBox.Enabled = true;
                    aktualizujWyborFirmyComboBox();                    
                }
                else
                {
                    toolStripStatusLabel1.Text = "Nie udało się wyciągnąć danych firm z podanej bazy. Nie mogę ustalić ID firmy.";
                }

            }
            else
            {
                toolStripStatusLabel1.Text = "Nie udało się połączyć z bazą.";
                MessageBox.Show(_conn.GetErrorInfo(), "Błąd połączenia z bazą", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            _conn.Close();            
            toolStripStatusLabel1.Text = "Rozłączono.";
            WFGangConnectButton.Enabled = true;
            disconnectButton.Enabled = false;
            this.listView1.Clear();
            this.listView1.Enabled = false;
            this.wyborFirmyComboBox.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.eksportListDoXlsButton.Enabled = false;
            this.wybierzSkladnikiButton.Enabled = false;
            this.OdwrocZaznaczButton.Enabled = false;
        }

        private void pobierzListeListPlac(DateTime okresListy)
        {
            try
            {
                this.listaListPlac.Clear();
                string query = "SELECT ID_LISTY, NAZWA, OKRES, NUMER from LISTA_PLAC" +
                               " where ID_FIRMY=" + this.idWybranaFirma.ToString() +
                               " and OKRES=" + this.date2GDate(okresListy);

                DataTable dt = _conn.ExecSql(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    decimal idListy = dr.Field<decimal>("ID_LISTY");
                    string nazwa = dr.Field<string>("NAZWA");
                    int okres = dr.Field<int>("OKRES");
                    string numer = dr.Field<string>("NUMER");
                    this.listaListPlac[idListy] = new ListaPlac(_conn, idListy, nazwa, okres, numer);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Problem z pobraniem list plac dla okresu " +
                    okresListy.ToString() + " | " + ex.Message);
            }            
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
            this.columnHeader1.Text = "ID LISTY";
            this.columnHeader2.Text = "NAZWA";
            this.columnHeader2.Width = 106;
            this.columnHeader3.Text = "NUMER";
            this.columnHeader3.Width = 152;
            this.columnHeader3.Text = "NUMER";
            this.columnHeader3.Width = 152;

            foreach( int idListy in listaListPlac.Keys)
            {
                ListaPlac lp = listaListPlac[idListy];
                ListViewItem listitem = new ListViewItem(lp.IdListy.ToString());
                listitem.SubItems.Add(lp.Nazwa);
                listitem.SubItems.Add(lp.Numer.ToString());
                this.listView1.Items.Add(listitem);
            }        
            this.listView1.Columns[1].Width = -1;
            this.listView1.Columns[2].Width = -1;
        }

        private void onDateTimePicker1ValueChanged(object sender, EventArgs e)
        {            
            if ( !_conn.Connected())
            {
                toolStripStatusLabel1.Text = "Najpierw połącz się z bazą.";
                return;
            }

            this.label2.Text = "Dostępne listy płac dla " + this.dateTimePicker1.Text;
            this.pobierzListeListPlac(this.dateTimePicker1.Value);
            this.listView1.Enabled = true;
            this.listView1Reset();
            this.eksportListDoXlsButton.Enabled = true;
            this.wybierzSkladnikiButton.Enabled = true;
            this.OdwrocZaznaczButton.Enabled = true;
        }

        private void pobierzDaneZaznaczonychListPlac()
        {
            if(listaSkladnikow.Count == 0)
            {
                this.wczytajWybraneZPliku();
            }
            int licznikPrzerobionychList = 0;
            toolStripStatusLabel1.Text = "Pobieram dane wybranych list płac.";
            foreach (ListViewItem li in listView1.Items)
            {
                decimal idListy;
                if (li.Checked && decimal.TryParse(li.Text, out idListy))
                {
                    toolStripStatusLabel1.Text = "Pobieram dane wybranych list płac | " 
                                                + li.SubItems[1].Text;
                    listaListPlac[idListy].pobierzDanePracownikow(listaSkladnikow);
                    licznikPrzerobionychList++;
                }                                
            }
        }

        private void zapiszNaglowekXls(Excel.Worksheet ws)
        {
            ws.Cells[1, 1] = "Kod pracownika";
            ws.Cells[1, 2] = "Imie nazwisko";
            ws.Cells[1, 3] = "dzial";

            int kol = 4;

            foreach (KeyValuePair<decimal, SkladnikPlacowy> sp in listaSkladnikow.Where( 
                s => s.Value.Wybrany() == true))
            {
                ws.Cells[1, kol] = sp.Value.Nazwa();
                ws.Cells[2, kol] = sp.Key.ToString();
                kol++;                                
            }                        
        }

        private void zapiszDaneZaznaczonychListPlac(Excel.Worksheet ws)
        {
            int row = 3;
            foreach( ListaPlac lp in listaListPlac.Values)
            {
                int kol = 1;
                toolStripStatusLabel1.Text = "Zapisuje dane wybranych list płac | " +
                                            " Lista: " + lp.Nazwa + " - " + lp.Numer;
                foreach ( Pracownik p in lp.ListaPracownikow.Values)
                {
                    kol = p.zapiszDaneListyDoXLS(ws, row, listaSkladnikow);
                    ws.Cells[row, 3] = lp.Nazwa;
                    ws.Cells[row, ++kol] = lp.IdListy + "|" + lp.Numer;
                    row++;
                }
                

            }
        }

        private void eksportListDoXlsButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Przygotowuje xls.";
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            toolStripStatusLabel1.Text = "Pobieram dane zaznaczonych list płac.";
            this.pobierzDaneZaznaczonychListPlac();
            toolStripStatusLabel1.Text = "Zapisz nagłowek xls.";
            this.zapiszNaglowekXls(xlWorkSheet);
            this.zapiszDaneZaznaczonychListPlac(xlWorkSheet);
            
            string filepath = Application.StartupPath;
            string filename = "\\listaPlac_"+ this.dateTimePicker1.Text + 
                "_" + DateTime.Now.ToFileTime() + ".xls";
            try
            {
                xlWorkBook.SaveAs(filepath + filename,
                                Excel.XlFileFormat.xlWorkbookNormal,
                                misValue,
                                misValue,
                                misValue,
                                misValue,
                                Excel.XlSaveAsAccessMode.xlExclusive,
                                misValue,
                                misValue,
                                misValue,
                                misValue,
                                misValue);

                MessageBox.Show("Plik utworzony. " + filepath + filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przy zapisie xls'a: " + ex.ToString());
            }
            finally
            {
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }            
        }

        private void wybierzSkladnikiButton_Click(object sender, EventArgs e)
        {
            if ( !_conn.Connected() )
            {
                toolStripStatusLabel1.Text = "Najpierw połącz się z bazą.";
                return;
            }

            System.Windows.Forms.Form ws = new wyborSkladnikow(this);
            ws.ShowDialog();
        }

        private void OdwrocZaznaczButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in listView1.Items) li.Checked = !li.Checked;
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

        private void wczytajWybraneZPliku()
        {
            this.pobierzListeSkladnikow();
            try
            {
                this.listaSkladnikowKonfig = new FileStream(this.filepath +
                    this.listaSkladnikowKonfigFileName,
                    FileMode.OpenOrCreate,
                    FileAccess.Read);
                StreamReader sr = new StreamReader(listaSkladnikowKonfig);
                string buf = sr.ReadToEnd();
                string[] bufSplitted = buf.Trim().Split(';');
                sr.Close();

                HashSet<decimal> wybraneSkladniki = new HashSet<decimal>();
                foreach (string idSkladnika in bufSplitted)
                {
                    decimal s;
                    if (decimal.TryParse(idSkladnika, out s))
                    {
                        wybraneSkladniki.Add(s);
                    }
                }

                foreach (decimal idSkladnika in listaSkladnikow.Keys)
                {
                    SkladnikPlacowy sp = listaSkladnikow[idSkladnika];
                    if (wybraneSkladniki.Contains(idSkladnika))
                    {
                        sp.setWybrany(true);
                    }
                    else
                    {
                        sp.setWybrany(false);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void wyborFirmyComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.idWybranaFirma =  ((KeyValuePair<decimal, Firma>) wyborFirmyComboBox.SelectedItem).Key;
            this.listView1.Clear();
            this.dateTimePicker1.Enabled = true;
        }

    }
}
