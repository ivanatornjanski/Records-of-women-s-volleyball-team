using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;
using PoslovnaLogika;

namespace PrezentacionaLogika
{
    public class clsFormaEvidencijaUnos
    {
        // atributi
        private string pStringKonekcije;
        private int pIDIgraca;
        private string pIgracIme;
        private string pIgracPrezime;
        private int pGodinaRodjenja;
        private int pBrojNaDresu;
       
        private string pNazivKluba;

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
       

        public string NazivKluba
        {
            get { return pNazivKluba; }
            set { pNazivKluba = value; }
        }
        
        // konstruktor
        public clsFormaEvidencijaUnos(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaCombo()
        {
            DataSet dsPodaci = new DataSet();
            clsKlubDB objKlubDB = new clsKlubDB(pStringKonekcije);

            dsPodaci = objKlubDB.DajSveKlubove() ; 
            
            return dsPodaci;
        }

        public bool DaLiJeSvePopunjeno()
        {
            bool SvePopunjeno = false;

            if ((pIDIgraca > 0) && (pIgracIme.Length > 0) && (pIgracPrezime.Length > 0) && (pGodinaRodjenja > 0) && (pBrojNaDresu > 0)  && (!pNazivKluba.Equals("Izaberite...")))
            {
                SvePopunjeno = true;
            }
            else
            {
                SvePopunjeno = false;
            }

            return SvePopunjeno;
        }


        public bool DaLiJeJedinstvenZapis()
        {
            bool JedinstvenZapis = false;
            DataSet dsPodaci = new DataSet();
            clsEvidencijaDB objEvidencijaDB = new clsEvidencijaDB(pStringKonekcije);
            dsPodaci =objEvidencijaDB.DajEvidencijePoImenuIgraca(pIgracIme);
            
            if (dsPodaci.Tables[0].Rows.Count == 0)
            {
                JedinstvenZapis = true;
            }
            else
            {
                JedinstvenZapis = false;
            }

            return JedinstvenZapis;

        }

        public bool SnimiPodatke()
        {
            bool uspehSnimanja=false;

            clsEvidencijaDB objEvidencijaDB = new clsEvidencijaDB(pStringKonekcije);

            clsEvidencija objNovaEvidencija = new clsEvidencija();
            objNovaEvidencija.IDIgraca = pIDIgraca;
            objNovaEvidencija.IgracIme = pIgracIme;
            objNovaEvidencija.IgracPrezime = pIgracPrezime; 
            objNovaEvidencija.GodinaRodjenja = pGodinaRodjenja;
            objNovaEvidencija.BrojNaDresu = pBrojNaDresu;
            clsKlub objKlub = new clsKlub();

            clsKlubDB objKlubDB = new clsKlubDB(pStringKonekcije);
            objKlub.Sifra = objKlubDB.DajSifruKlubaPoNazivu(pNazivKluba);
            objKlub.Naziv = pNazivKluba;

            objNovaEvidencija.Klub = objKlub; 
            
            uspehSnimanja = objEvidencijaDB.SnimiNovuEvidenciju(objNovaEvidencija); 


            return uspehSnimanja;
        }

    }
}
