using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using System.Configuration;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class EvidencijaSpisak : System.Web.UI.Page
    {
        // atributi
        private clsFormaEvidencijaSpisak objFormaEvidencijaSpisak;

        // konstruktor


        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvEvidencija.DataSource = ds.Tables[0];
            gvEvidencija.DataBind();
        }

      
         
        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaEvidencijaSpisak = new clsFormaEvidencijaSpisak(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);  
        }

        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            NapuniGrid(objFormaEvidencijaSpisak.DajPodatkeZaGrid(txbFilter.Text));   
        }

        protected void btnSvi_Click(object sender, EventArgs e)
        {
            NapuniGrid(objFormaEvidencijaSpisak.DajPodatkeZaGrid(""));
        }
    }
}