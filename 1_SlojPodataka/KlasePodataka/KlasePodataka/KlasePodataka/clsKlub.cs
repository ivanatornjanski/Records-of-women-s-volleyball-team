﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsKlub
    {
        // atributi
        private string pSifra;
        private string pNaziv;

        // property
        public string Sifra
        {
            get
            {
                return pSifra;
            }
            set
            {
                if (this.pSifra != value)
                    this.pSifra = value;
            }
        }

        public string Naziv
        {
            get
            {
                return pNaziv;
            }
            set
            {
                if (this.pNaziv != value)
                    this.pNaziv = value;
            }
        }


        // konstruktor
        public clsKlub()
        {
            pSifra = "";
            pNaziv = "";
        }

        // privatne metode

        // javne metode
    }
}
