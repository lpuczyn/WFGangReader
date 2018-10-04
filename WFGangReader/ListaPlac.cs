using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace WFGangReader
{
    class ListaPlac
    {
        private _SQLConnection _conn;
        private decimal idListy;
        private string nazwa;
        private int okres;
        private string numer;
        private SortedDictionary<decimal, Pracownik> listaPracownikow =
            new SortedDictionary<decimal, Pracownik>();



        public ListaPlac( _SQLConnection _conn, decimal idListy, string nazwa, int okres, string numer)
        {
            this._conn = _conn;
            this.IdListy = idListy;
            this.Nazwa = nazwa;
            this.Okres = okres;
            this.Numer = numer;
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int Okres { get => okres; set => okres = value; }
        public string Numer { get => numer; set => numer = value; }
        public decimal IdListy { get => idListy; set => idListy = value; }
        internal SortedDictionary<decimal, Pracownik> ListaPracownikow { get => listaPracownikow; set => listaPracownikow = value; }

        public bool pobierzDanePracownikow(Dictionary<decimal, SkladnikPlacowy> listaSkladnikow)
        {
            try
            {                
                string query = "SELECT ID_PRACOWNIKA from PRZYPORZADKOWANIE" +
                               " where ID_LISTY=" + this.idListy.ToString();

                DataTable dt = _conn.ExecSql(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    decimal idPracownika = dr.Field<decimal>("ID_PRACOWNIKA");
                    Pracownik p = new Pracownik(_conn, idPracownika);
                    if( p.pobierzDanePracownika() && 
                        p.pobierzWartosciSkladnikow(listaSkladnikow, this.idListy))
                    {
                        this.listaPracownikow[idPracownika] = p;
                    }
                }

                if (dt.Rows.Count == this.listaPracownikow.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Problem z pobraniem idPracownika. | " + ex.Message);
                return false;
            }
        }
    }
}
