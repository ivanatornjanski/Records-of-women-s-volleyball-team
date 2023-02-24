using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaEvidencijaSpisak
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsFormaEvidencijaSpisak(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            clsEvidencijaDB objEvidencijaDB = new clsEvidencijaDB(pStringKonekcije);
            if (filter.Equals(""))
            {
                dsPodaci = objEvidencijaDB.DajSveEvidencije();
            }
            else
            {
                dsPodaci = objEvidencijaDB.DajEvidencijePoImenuIgraca(filter);
            }
            return dsPodaci;
        }

    }
}
