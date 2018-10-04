using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFGangReader
{
    class SkladnikPlacowy
    {
        private int kolejnosc;
        private decimal idSkladnika;
        private string nazwa;
        private bool wybrany = false;
        private decimal wartosc = 0;

        public decimal Wartosc { get => wartosc; set => wartosc = value; }    
        public int Kolejnosc() { return this.kolejnosc; }
        public decimal IdSkladnika() { return this.idSkladnika; }
        public string Nazwa() { return nazwa; }
        public bool Wybrany() { return this.wybrany; }
        public void setWybrany(bool w) { this.wybrany = w; }


        public SkladnikPlacowy(int kolejnosc, decimal idSkladnika, string nazwa)
        {
            this.kolejnosc = kolejnosc;
            this.idSkladnika = idSkladnika;
            this.nazwa = nazwa;
        }

        public SkladnikPlacowy(int kolejnosc, decimal idSkladnika, string nazwa, decimal wartosc)
        {
            this.kolejnosc = kolejnosc;
            this.idSkladnika = idSkladnika;
            this.nazwa = nazwa;
            this.Wartosc = wartosc;
        }

    }
}
