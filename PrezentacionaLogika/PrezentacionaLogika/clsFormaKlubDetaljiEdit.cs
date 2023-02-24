using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaKlubDetaljiEdit
    {
   // atributi i property
        private string pStringKonekcije;
        private clsKlubDB objKlubDB;

        private clsKlub objPreuzetiKlub;
        private clsKlub objIzmenjeniKlub;

        private string pSifraPreuzetiKlub;
        private string pNazivPreuzetiKlub;

        private string pSifraIzmenjeniKlub;
        private string pNazivIzmenjeniKlub;
        
// PROPERTY

        public string SifraPreuzetiKlub
        {
            get { return pSifraPreuzetiKlub; }
            set { pSifraPreuzetiKlub = value; pNazivPreuzetiKlub = DajNaziv(pSifraPreuzetiKlub); }
        }

        public string NazivPreuzetiKlub
        {
            get { return pNazivPreuzetiKlub; }
            // OVO NECEMO DA OMOGUCIMO, JER SE RACUNA IZ SIFRE set { pNazivPreuzetogZvanja = value; }
        }

        public string SifraIzmenjeniKlub
        {
            get { return pSifraIzmenjeniKlub; }
            set { pSifraIzmenjeniKlub = value; }
        }


        public string NazivIzmenjeniKlub
        {
            get { return pNazivIzmenjeniKlub; }
            set { pNazivIzmenjeniKlub = value; }
        }


    // konstruktor
        public clsFormaKlubDetaljiEdit(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
            objKlubDB = new clsKlubDB(pStringKonekcije);
        }

        // privatne metode
        private string DajNaziv(string pomSifra)
        {
            string pomNaziv ="";
            DataSet dsPodaci = new DataSet();
            pomNaziv = objKlubDB.DajNazivPremaIDKluba(pomSifra); 

            return pomNaziv;
        }

        // javne metode
        public bool ObrisiKlub()
        {
            // zvanje koje je trenutno u atributima dato, TJ. preuzeta sifra je bitna
            bool uspehBrisanja = false;
            uspehBrisanja = objKlubDB.ObrisiKlub(pSifraPreuzetiKlub);  

            return uspehBrisanja;

        }

        public bool IzmeniKlub()
        {
            bool uspehIzmene = false;
            objPreuzetiKlub = new clsKlub();
            objIzmenjeniKlub = new clsKlub();

            objPreuzetiKlub.Sifra = pSifraPreuzetiKlub;
            objPreuzetiKlub.Naziv = pNazivPreuzetiKlub;

            objIzmenjeniKlub.Sifra = pSifraIzmenjeniKlub;
            objIzmenjeniKlub.Naziv = pNazivIzmenjeniKlub;

            uspehIzmene = objKlubDB.IzmeniKlub(objPreuzetiKlub, objIzmenjeniKlub);  

            return uspehIzmene;
        }
    }
}
