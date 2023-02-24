using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data.SqlClient; 

namespace DBUtils
{
    public class clsKonekcija
    {

         /* ODGOVORNOST: Konekcija na celinu baze podataka, SQL server tipa  */

        #region Atributi
        private SqlConnection pKonekcija;
        //
        private string pPutanjaBaze;
        private string pNazivBaze;
        private string pNaziv_DBMSinstance;
        private string pStringKonekcije;
        #endregion

        #region Konstruktor
        public clsKonekcija(string naziv_DBMSInstance, string putanjaBaze, string NazivBaze)
        {
            pPutanjaBaze = putanjaBaze;
            pNazivBaze = NazivBaze;
            pNaziv_DBMSinstance = naziv_DBMSInstance;
            pStringKonekcije = "";
        }

        public clsKonekcija(string noviStringKonekcije)
        {
            pPutanjaBaze = "";
            pNazivBaze = "";
            pNaziv_DBMSinstance = "";
            pStringKonekcije = noviStringKonekcije;
        }
        #endregion

        #region Privatne metode
        private string DajStringKonekcije()
        {
            string mStringKonekcije;
            if (pStringKonekcije.Length.Equals(0) || pStringKonekcije == null)
            {
                // AKO NEMAMO GOTOV STRING KONEKCIJE KOJI JE DAT PUTEM KONSTRUKTORA
                if (pPutanjaBaze.Length.Equals(0) || pPutanjaBaze == null)
                {
                    mStringKonekcije = "Data Source=" + pNaziv_DBMSinstance + " ;Initial Catalog=" + pNazivBaze + ";Integrated Security=True";
                }
                else
                {
                    mStringKonekcije = "Data Source=.\\" + pNaziv_DBMSinstance + ";AttachDbFilename=" + pPutanjaBaze + "\\" + pNazivBaze + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
                }
            }
            else
            {
                // AKO IMAMO VEC DAT GOTOV STRING KONEKCIJE
                mStringKonekcije = pStringKonekcije;
            }
            return mStringKonekcije;
        }
        #endregion

        #region Javne metode
        public bool OtvoriKonekciju()
        {
            bool uspeh;
            pKonekcija = new SqlConnection();
            pKonekcija.ConnectionString = DajStringKonekcije();

            try
            {
                pKonekcija.Open();
                uspeh = true;
            }
            catch
            {
                uspeh = false;
            }
            return uspeh;
        }

        public SqlConnection DajKonekciju()
        {
            return pKonekcija;
        }

        public void ZatvoriKonekciju()
        {
            pPutanjaBaze = "";
            pKonekcija.Close();
            pKonekcija.Dispose();
        }

        #endregion

    }
}
