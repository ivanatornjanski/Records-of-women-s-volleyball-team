using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class clsEvidencijaDB
    {
        // atributi
        private string pStringKonekcije;

        // property
        // 1. nacin
        public string StringKonekcije
        {
            get
            {
                return pStringKonekcije;
            }
        }
        // konstruktor
        // 2. nacin prijema vrednosti stringa konekcije spolja i dodele atributu
        public clsEvidencijaDB(string NoviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
            pStringKonekcije = NoviStringKonekcije; 
        }

        // privatne metode

        // javne metode
        public DataSet DajSveEvidencije()
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveEvidencijeSaJoin", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }

        public DataSet DajEvidencijePoImenuIgraca(string IgracIme)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajEvidencijePoImenuIgraca", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@EvidencijaIgracIme", SqlDbType.NVarChar).Value = IgracIme;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }


        public DataSet DajEvidencijePoIDIgraca(int IDIgraca)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajEvidencijePoIDIgraca", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@EvidencijaIDIgraca", SqlDbType.Int).Value =IDIgraca;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public int DajUkupnoEvidencijaZaKlubove(string IDKluba)
        {
            int ukupnoEvidencija = 0;
            DataSet dsPodaci = new DataSet();
            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajBrojEvidencijaZaKlubove", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IDKluba", SqlDbType.Char).Value = IDKluba;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            ukupnoEvidencija = int.Parse(dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString());
            return ukupnoEvidencija;
        }


        private clsEvidencijaLista DajListuSvihEvidencija()
        {
            // PRIPREMA PROMENLJIVIH
            clsEvidencijaLista objEvidencijaLista = new clsEvidencijaLista();
            DataSet dsPodaciEvidencija = new DataSet();
            clsEvidencija objEvidencija;
            clsKlub objKlub;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveEvidencijaSaJoinSifromKluba", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaciEvidencija);
            Veza.Close();
            Veza.Dispose();

            // FORMIRANJE OBJEKATA I UBACIVANJE U LISTU
            for (int brojac = 0; brojac < dsPodaciEvidencija.Tables[0].Rows.Count; brojac++)
            {
                objKlub = new clsKlub();
                objKlub.Sifra = dsPodaciEvidencija.Tables[0].Rows[brojac].ItemArray[4].ToString();
                objKlub.Naziv = dsPodaciEvidencija.Tables[0].Rows[brojac].ItemArray[3].ToString();

                objEvidencija = new clsEvidencija();
                objEvidencija.IDIgraca= int.Parse (dsPodaciEvidencija.Tables[0].Rows[brojac].ItemArray [0].ToString ());
                objEvidencija.IgracIme = dsPodaciEvidencija.Tables[0].Rows[brojac].ItemArray [0].ToString ();
                objEvidencija.IgracPrezime = dsPodaciEvidencija.Tables[0].Rows[brojac].ItemArray[0].ToString();
                objEvidencija.GodinaRodjenja = int.Parse(dsPodaciEvidencija.Tables[0].Rows[brojac].ItemArray[0].ToString());
                objEvidencija.BrojNaDresu= int.Parse(dsPodaciEvidencija.Tables[0].Rows[brojac].ItemArray[0].ToString());
                objEvidencija.Klub = objKlub;
                objEvidencijaLista.DodajElementListe (objEvidencija);
            }

            return objEvidencijaLista;
        }
        

        public bool SnimiNovuEvidenciju(clsEvidencija objNovaEvidencija)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova =0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNovuEvidenciju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IDIgraca", SqlDbType.Int).Value = objNovaEvidencija.IDIgraca ;
            Komanda.Parameters.Add("@IgracIme", SqlDbType.NVarChar ).Value = objNovaEvidencija.IgracIme;
            Komanda.Parameters.Add("@IgracPrezime", SqlDbType.NVarChar).Value = objNovaEvidencija.IgracPrezime;
            Komanda.Parameters.Add("@GodinaRodjenja", SqlDbType.Int).Value = objNovaEvidencija.GodinaRodjenja;
            Komanda.Parameters.Add("@BrojNaDresu", SqlDbType.Int).Value = objNovaEvidencija.BrojNaDresu;
            Komanda.Parameters.Add("@IDKluba", SqlDbType.Char).Value = objNovaEvidencija.Klub.Sifra;
            
           
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();
     
            // 2. varijanta
            return (brojSlogova > 0);

        }

        public bool ObrisiEvidenciju(string IDIgracaZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiEvidenciju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IDIgraca", SqlDbType.Int).Value = IDIgracaZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniEvidenciju(clsEvidencija objStaraEvidencija, clsEvidencija objNovaEvidencija)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniEvidenciju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IDIgraca", SqlDbType.Int).Value = objStaraEvidencija.IDIgraca;
            Komanda.Parameters.Add("@IgracIme", SqlDbType.NVarChar).Value = objNovaEvidencija.IgracIme;
            Komanda.Parameters.Add("@IgracPrezime", SqlDbType.NVarChar).Value = objNovaEvidencija.IgracPrezime;
            Komanda.Parameters.Add("@GodinaRodjenja", SqlDbType.Int).Value = objNovaEvidencija.GodinaRodjenja;
            Komanda.Parameters.Add("@BrojNaDresu", SqlDbType.Int).Value = objStaraEvidencija.BrojNaDresu;
            Komanda.Parameters.Add("@IDKluba", SqlDbType.Char).Value = objNovaEvidencija.Klub.Sifra;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        


    }
}
