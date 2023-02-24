using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class clsKorisnikDB
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
        public clsKorisnikDB(string NoviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
            pStringKonekcije = NoviStringKonekcije; 
        }

        // privatne metode

        // javne metode
        public DataSet DajKorisnikaPoKorisnickomImenuISifri(string pomKorisnickoIme, string pomSifra)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajKorisnikaPoKorisnickomImenuISifri", Veza);
            Komanda.Parameters.Add("@KorisnickoIme", SqlDbType.NVarChar).Value = pomKorisnickoIme;
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = pomSifra;
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }
        public bool SnimiNovogKorisnika(clsKorisnik objNoviKorisnik)
        {
            int brojSlogova = 0;
            bool uspehSnimanja = false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DodajNovogKorisnika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = objNoviKorisnik.Prezime;
            Komanda.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = objNoviKorisnik.Ime;
            Komanda.Parameters.Add("@KorisnickoIme", SqlDbType.NVarChar).Value = objNoviKorisnik.KorisnickoIme;
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = objNoviKorisnik.Sifra;
            Komanda.Parameters.Add("@Status", SqlDbType.NVarChar).Value = objNoviKorisnik.Status;

            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            if (brojSlogova > 0)
            {
                uspehSnimanja = true;
            }

            else
            {
                uspehSnimanja = false;
            }

            return uspehSnimanja;


        }
    }
}
