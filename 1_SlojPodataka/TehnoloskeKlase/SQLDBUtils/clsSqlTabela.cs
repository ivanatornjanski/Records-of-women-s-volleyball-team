using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data.SqlClient; 

namespace SqlDBUtils
{
    public class clsSqlTabela
    {
        #region Atributi
        
        private string pNazivTabele;
        private clsSqlKonekcija pKonekcija;
        private SqlDataAdapter pAdapter;
        private System.Data.DataSet pDataSet;
        
        #endregion

        #region Konstruktor

        public clsSqlTabela(clsSqlKonekcija Konekcija, string NazivTabele)
        {
            pKonekcija = Konekcija;
            pNazivTabele = NazivTabele;
        }
        
        #endregion

        #region Privatne metode

        private void KreirajAdapter(string SelectUpit, string InsertUpit, string DeleteUpit, string UpdateUpit)
        {
            SqlCommand mSelectKomanda, mInsertKomanda, mDeleteKomanda, mUpdateKomanda;

            mSelectKomanda = new SqlCommand();
            mSelectKomanda.CommandText = SelectUpit;
            mSelectKomanda.Connection = pKonekcija.DajKonekciju();

            mInsertKomanda = new SqlCommand();
            mInsertKomanda.CommandText = InsertUpit;
            mInsertKomanda.Connection = pKonekcija.DajKonekciju();

            mDeleteKomanda = new SqlCommand();
            mDeleteKomanda.CommandText = DeleteUpit;
            mDeleteKomanda.Connection = pKonekcija.DajKonekciju();

            mUpdateKomanda = new SqlCommand();
            mUpdateKomanda.CommandText = UpdateUpit;
            mUpdateKomanda.Connection = pKonekcija.DajKonekciju();

            pAdapter = new SqlDataAdapter();
            pAdapter.SelectCommand = mSelectKomanda;
            pAdapter.InsertCommand = mInsertKomanda;
            pAdapter.UpdateCommand = mUpdateKomanda;
            pAdapter.DeleteCommand = mDeleteKomanda;
        }

        private void KreirajDataset()
        {
            pDataSet = new System.Data.DataSet();
            pAdapter.Fill(pDataSet, pNazivTabele);
            
        }

        private void ZatvoriAdapterDataset()
        {
            pAdapter.Dispose();
            pDataSet.Dispose();
        }
        
        #endregion

        #region Javne metode

        public System.Data.DataSet DajPodatke(string SelectUpit)
            // izdvaja podatke u odnosu na dat selectupit
        {
            KreirajAdapter(SelectUpit, "", "", "");
            KreirajDataset();
            return pDataSet;
        }

        public int DajBrojSlogova()
        {
            int BrojSlogova = pDataSet.Tables[0].Rows.Count; 
            return BrojSlogova;
        }

        public bool IzvrsiAzuriranje(string Upit)
            // izvrzava azuriranje unos/brisanje/izmena u odnosu na dati i upit
        {

            //
            bool uspeh = false;
           SqlConnection mKonekcija;
           SqlCommand Komanda;
           SqlTransaction mTransakcija = null; 
            try
            {
                mKonekcija = pKonekcija.DajKonekciju();
                // aktivan kod  

                // povezivanje
                Komanda = new SqlCommand();
                Komanda.Connection = mKonekcija;
                Komanda = mKonekcija.CreateCommand();
                // pokretanje
                // NE TREBA OPEN JER DOBIJAMO OTVORENU KONEKCIJU KROZ KONSTRUKTOR
                // mKonekcija.Open();
                mTransakcija = mKonekcija.BeginTransaction();
                Komanda.Transaction = mTransakcija;
                Komanda.CommandText = Upit;
                Komanda.ExecuteNonQuery();
                mTransakcija.Commit();
                uspeh = true;
            }
            catch
            {
                mTransakcija.Rollback();
                uspeh = false;
            }
            return uspeh;
        }


        #endregion

    }
}
