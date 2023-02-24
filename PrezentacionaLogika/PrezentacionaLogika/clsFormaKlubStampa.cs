using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaKlubStampa
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsFormaKlubStampa(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            clsKlubDB objKlubDB = new clsKlubDB(pStringKonekcije);
            if (!filter.Equals(""))
            {
                dsPodaci = objKlubDB.DajKlubPoNazivu(filter);
            }
            else
            {
                dsPodaci = objKlubDB.DajSveKlubove();
            }
            return dsPodaci;
        }
    }
}
