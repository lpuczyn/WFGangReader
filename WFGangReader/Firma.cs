using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WFGangReader
{    
    class Firma
    {
        private _SQLConnection _conn;
        private decimal idFirmy;
        private string nazwa;

        public Firma(_SQLConnection _conn, decimal idFirmy, string nazwa)
        {
            this._conn = _conn;
            this.idFirmy = idFirmy;
            this.nazwa = nazwa;
        }

        public static SortedDictionary<decimal, Firma> pobierzFirmy(_SQLConnection _conn)
        {
            SortedDictionary<decimal, Firma> result = new SortedDictionary<decimal, Firma>();
            try
            {
                string query = "SELECT ID_FIRMY, NAZWA from FIRMA";
                DataTable dt = _conn.ExecSql(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    decimal idFirmy = dr.Field<decimal>("ID_FIRMY");
                    string nazwaFirmy = dr.Field<string>("NAZWA");
                    result[idFirmy] = new Firma(_conn, idFirmy, nazwaFirmy);
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z pobraniem danych firm. | " + ex.Message);
                return result;
            }
        }

        public override string ToString()
        {
            return this.nazwa;
        }
    }
}
