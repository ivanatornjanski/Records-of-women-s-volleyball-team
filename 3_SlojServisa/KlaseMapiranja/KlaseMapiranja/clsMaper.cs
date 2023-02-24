using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;

namespace KlaseMapiranja
{
    public class clsMaper
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsMaper(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }


        public string DajSifruKlubaZaWebServis(string IdKlubaIzBazePodataka)
        {
            string IDKlubaWS = "";
            clsKlubDB objKlubDB = new clsKlubDB(pStringKonekcije);
            string nazivKlubaIzBazePodataka = objKlubDB.DajNazivPremaIDKluba(IdKlubaIzBazePodataka);

            // sifra zvanja za web servis je prvo slovo naziva zvanja, znaci za docent je "d"
            IDKlubaWS = nazivKlubaIzBazePodataka[0].ToString();

            return IDKlubaWS;

        }

    }
}
