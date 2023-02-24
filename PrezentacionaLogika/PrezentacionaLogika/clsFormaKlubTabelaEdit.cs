using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaKlubTabelaEdit
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsFormaKlubTabelaEdit(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            clsKlubDB objKlubDB = new clsKlubDB(pStringKonekcije);            
            if (filter.Equals(""))
            {
                dsPodaci = objKlubDB.DajSveKlubove(); 
            }
            else
            {
                dsPodaci = objKlubDB.DajKlubPoNazivu(filter); 
            }
            return dsPodaci;
        }
    }
}
