using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsEvidencija
    {
        // atributi
        private int pIDIgraca;
        private string pIgracIme;
        private string pIgracPrezime;
        private int pGodinaRodjenja;
        private int pBrojNaDresu;
        private clsKlub objKlub;

        // property
        public int IDIgraca
        {
            get { return pIDIgraca; }
            set { pIDIgraca = value; }
        }

        public string IgracIme
        {
            get { return pIgracIme; }
            set { pIgracIme = value; }
        }

        public string IgracPrezime
        {
            get { return pIgracPrezime; }
            set { pIgracPrezime = value; }
        }
        public int GodinaRodjenja
        {
            get { return pGodinaRodjenja; }
            set { pGodinaRodjenja = value; }
        }

        public int BrojNaDresu
        {
            get { return pBrojNaDresu; }
            set { pBrojNaDresu = value; }
        }

        public clsKlub Klub
        {
            get { return objKlub; }
            set { objKlub = value; }
        }
    }
}
