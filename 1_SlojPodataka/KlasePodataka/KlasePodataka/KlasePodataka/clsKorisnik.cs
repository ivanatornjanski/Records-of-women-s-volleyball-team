using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsKorisnik
    {
        private int pID;
        private string pPrezime;
        private string pIme;
        private string pKorisnickoIme;
        private string pSifra;
        private string pStatus;

        public int ID
        {
            get { return pID; }
            set { pID = value; }
        }
        public string Prezime
        {
            get { return pPrezime; }
            set { pPrezime = value; }
        }
        public string Ime
        {
            get { return pIme; }
            set { pIme = value; }
        }

        public string KorisnickoIme
        {
            get { return pKorisnickoIme; }
            set { pKorisnickoIme = value; }
        }

        public string Sifra

        {
            get { return pSifra; }
            set { pSifra = value; }
        }

        public string Status

        {
            get { return pStatus; }
            set { pStatus = value; }
        }




    }
}
