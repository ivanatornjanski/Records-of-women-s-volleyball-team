using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;
using KlaseMapiranja;

namespace PoslovnaLogika
{
    public class clsPoslovnaPravila
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsPoslovnaPravila(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // privatne metode

        // public metode
        public bool DaLiImaMestaZaZaposljavanje(string IDPredstavaIzBazePodataka)
        {
            bool imaMesta = false;

            int UkupnoEvidencija = 0;
            clsEvidencijaDB objEvidencijaDB = new clsEvidencijaDB(pStringKonekcije);
            UkupnoEvidencija = objEvidencijaDB.DajUkupnoEvidencijaZaPredstave(IDPredstavaIzBazePodataka);

            string IdZvanjeWS = "";
            clsMaper objMaper = new clsMaper(pStringKonekcije);
            IdZvanjeWS = objMaper.DajSifruPozoristaZaWebServis(IDPredstaveIzBazePodataka);

            WSKadrovskiPodaci.Service1 objOgranicenja = new WSKadrovskiPodaci.Service1();
            int MaxBrojNastavnika = objOgranicenja.DajMaxBrojNastavnika(IdZvanjeWS);

            if (UkupnoEvidencija < MaxBrojEvidencija)
            {
                imaMesta = true;
            }
            else
            {
                imaMesta = false;
            }


            return imaMesta;
        }

    }
}
