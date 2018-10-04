using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WFGangReader
{
    class Pracownik
    {
        private _SQLConnection _conn;
        private decimal idPracownika;
        private int kodPracownika;
        private string nazwisko;
        private string imie;
        private Dictionary<decimal, SkladnikPlacowy> listaSkladnikow =
            new Dictionary<decimal, SkladnikPlacowy>();


        public Pracownik(_SQLConnection _conn, decimal idPracownika)
        {
            this._conn = _conn;
            this.idPracownika = idPracownika;
        }

        public string imieNazwisko()
        {
            return this.imie + " " + this.nazwisko;
        }

        public string nazwiskoImie()
        {
            return this.nazwisko + " " + this.imie;
        }

        public bool pobierzDanePracownika()
        {
            try
            {
                string query = "SELECT KOD_PRACOWNIKA, NAZWISKO, IMIE_1" +
                               " from PRACOWNIK where ID_PRACOWNIKA=" + 
                               this.idPracownika.ToString();

                DataTable dt = _conn.ExecSql(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    this.kodPracownika = dr.Field<int>("KOD_PRACOWNIKA");
                    this.nazwisko = dr.Field<string>("NAZWISKO");
                    this.imie = dr.Field<string>("IMIE_1");                  
                }
                return true;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z pobraniem danych Pracownika. | " + ex.Message);
                return false;
            }
        }

        public bool pobierzWartosciSkladnikow(
            Dictionary<decimal, SkladnikPlacowy> listaSkladnikowKonfig, decimal idListy)
        {
            List<string> wybraneSkladniki = new List<string>();

            foreach( int idSkladnika in listaSkladnikowKonfig.Keys)
            {
                SkladnikPlacowy sp = listaSkladnikowKonfig[idSkladnika];
                if (sp.Wybrany())
                {
                    wybraneSkladniki.Add(idSkladnika.ToString());
                }
            }

            string wybraneSkladnikiSQL = string.Join(",", wybraneSkladniki);

            //MessageBox.Show(string.Join(",",listaWybranychSkladnikow.Keys.ToArray().Select(x => x.ToString())));
            try
            {
                string query = "SELECT ID_SKLADNIKA, WARTOSC" +
                               " from WARTOSC_SKLADNIKA where " +
                               " ID_PRACOWNIKA=" + this.idPracownika.ToString() + " and " + 
                               " ID_LISTY=" + idListy.ToString() + " and " +
                               " ID_SKLADNIKA in (" + wybraneSkladnikiSQL + ")";

                DataTable dt = _conn.ExecSql(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    
                    decimal idSkladnika = dr.Field<decimal>("ID_SKLADNIKA");
                    decimal wartosc = dr.Field<decimal>("WARTOSC");
                    int kolejnosc = listaSkladnikowKonfig[idSkladnika].Kolejnosc();
                    string nazwa = listaSkladnikowKonfig[idSkladnika].Nazwa();

                    this.listaSkladnikow[idSkladnika] = new SkladnikPlacowy(
                        kolejnosc, idSkladnika, nazwa, wartosc);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z pobraniem danych skladnika placowego. | " + ex.Message);
                return false;
            }
        }

        public int zapiszDaneListyDoXLS(Excel.Worksheet ws, int row,
            Dictionary<decimal, SkladnikPlacowy> listaSkladnikowKonfig)
        {
            ws.Cells[row, 1] = this.kodPracownika.ToString();
            ws.Cells[row, 2] = this.nazwiskoImie();
            int kol = 4;
            foreach (KeyValuePair<decimal, SkladnikPlacowy> sp in listaSkladnikowKonfig.Where(
    s => s.Value.Wybrany() == true))
            {
                if (listaSkladnikow.ContainsKey(sp.Key))
                {
                    ws.Cells[row, kol] = listaSkladnikow[sp.Key].Wartosc;
                }
                else
                {
                    ws.Cells[row, kol] = 0;
                }                
                kol++;
            }
            return kol;
        }
    }
}
