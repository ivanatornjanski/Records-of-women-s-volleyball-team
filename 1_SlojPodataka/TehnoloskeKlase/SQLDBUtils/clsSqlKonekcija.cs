using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data.SqlClient; 

namespace SqlDBUtils
{
    public class clsSqlKonekcija
    {
        /* ODGOVORNOST: Konekcija na celinu baze podataka, SQL server tipa  */

        #region Atributi
        private SqlConnection pKonekcija;
        //
        private string pPutanjaSQLBaze;
        private string pNazivBaze;
        private string pNazivSQL_DBMSinstance;
        #endregion

        #region Konstruktor
        public clsSqlKonekcija(string nazivSQL_DBMSInstance, string putanjaSqlBaze, string NazivBaze)
        {
            pPutanjaSQLBaze = putanjaSqlBaze;
            pNazivBaze = NazivBaze;
            pNazivSQL_DBMSinstance = nazivSQL_DBMSInstance; 
        }
        #endregion

        #region Privatne metode
        private string DajStringKonekcije()
        {
            string mStringKonekcije;
            if (pPutanjaSQLBaze.Length.Equals(0) || pPutanjaSQLBaze==null)
            {
                mStringKonekcije = "Data Source=" + pNazivSQL_DBMSinstance + " ;Initial Catalog=" + pNazivBaze + ";Integrated Security=True";
            }
            else
            {  
                mStringKonekcije = "Data Source=.\\" + pNazivSQL_DBMSinstance + ";AttachDbFilename=" + pPutanjaSQLBaze + "\\" + pNazivBaze +  ";Integrated Security=True;Connect Timeout=30;User Instance=True";
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
            pPutanjaSQLBaze = "";
            pKonekcija.Close();
            pKonekcija.Dispose();
        }

        #endregion

    }
}
