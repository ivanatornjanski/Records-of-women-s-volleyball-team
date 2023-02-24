using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;
//OVO SE KORISTI KOD WEB APP using System.Configuration; 

namespace KlasePodataka
{
    public class clsKlubDB
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
            set // OVO NIJE DOBRO, MOZE SE STRING KONEKCIJE STAVITI NA PRAZAN STRING
            {
                if (this.pStringKonekcije != value)
                    this.pStringKonekcije = value;
            }
        }
        // konstruktor
        // 2. nacin prijema vrednosti stringa konekcije spolja i dodele atributu
        public clsKlubDB(string NoviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
            pStringKonekcije = NoviStringKonekcije; 
        }

        // privatne metode

        // javne metode
        public DataSet DajSveKlubove()
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveKlubove", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }

        public string DajNazivPremaIDKluba(string SifraKluba)
        {
            string NazivKluba = "";

            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajKlubPoSifri", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@SifraKluba", SqlDbType.Char).Value = SifraKluba;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            NazivKluba = dsPodaci.Tables[0].Rows[0].ItemArray[1].ToString();

            return NazivKluba;
        }

        public string DajSifruKlubaPoNazivu(string NazivKluba)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajKlubPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivKluba", SqlDbType.NVarChar).Value = NazivKluba;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString () ;
        }



        public DataSet DajKlubPoNazivu(string NazivKluba)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajKlubPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivKluba", SqlDbType.NVarChar).Value = NazivKluba;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        // overloading metoda - isto se zove, ima drugaciji parametar
        public DataSet DajKlubPoNazivu(clsKlub objKlubZaFilter)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajKlubPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivKluba", SqlDbType.NVarChar).Value = objKlubZaFilter.Naziv;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public bool SnimiNoviKlub(clsKlub objNoviKlub)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova =0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNoviKlub", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = objNoviKlub.Sifra;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNoviKlub.Naziv;
           
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            // NEGATIVNO PITANJE - NIJE DOBRO if (brojSlogova ==0)
            /* 1. VARIJANTA - SKOLSKA
             * if (brojSlogova>0)
            {
                uspehSnimanja=true;
            }
            else
            {
                uspehSnimanja=false;
            }

            return uspehSnimanja;
             */
            
            // 2. varijanta
            return (brojSlogova > 0);

            //3. varijanta
            // NEMA SMISLA, ISTO KAO 2. VARIJANTA
            //return (brojSlogova > 0) ? true : false;
            
            //4. varijanta - NEGACIJA NEGACIJE, NIJE RAZUMLJIVO 
            //return (brojSlogova == 0) ? false : true;
            
        }

        public bool ObrisiKlub(clsKlub objKlubZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiKlub", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = objKlubZaBrisanje.Sifra;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

         }

        // method overloading - ista procedura sa razlicitim parametrom
        public bool ObrisiKlub(string SifraKlubZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiKlub", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = SifraKlubZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniKlub(clsKlub objStariKlub, clsKlub objNoviKlub)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniKlub", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StaraSifra", SqlDbType.Char).Value = objStariKlub.Sifra;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = objNoviKlub.Sifra;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNoviKlub.Naziv;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        // method overloading - ista metoda, samo drugaciji parametri
        public bool IzmeniKlub(string SifraStarogKluba, clsKlub objNoviKlub)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniKlub", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StaraSifra", SqlDbType.Char).Value = SifraStarogKluba;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = objNoviKlub.Sifra;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNoviKlub.Naziv;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }


    }
}
