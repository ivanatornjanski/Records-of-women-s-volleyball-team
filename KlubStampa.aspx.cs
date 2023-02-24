using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using PrezentacionaLogika;
using System.Configuration; 

namespace KorisnickiInterfejs
{
    public partial class KlubStampa : System.Web.UI.Page
    {
        // atributi

        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakKlub.DataSource = ds.Tables[0];
            gvSpisakKlub.DataBind();
        }
        
                
        protected void Page_Load(object sender, EventArgs e)
        {
            clsFormaKlubStampa objFormaKlubStampa = new clsFormaKlubStampa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            string filter = Request.QueryString["filter"].ToString();

            if (filter.Equals(""))
            {
                lblNaslov.Text = "SPISAK SVIH KLUBOVA"; 
            }
            else
            {
                lblNaslov.Text = "FILTRIRANI SPISAK , naziv=" + filter; 
            }

            NapuniGrid(objFormaKlubStampa.DajPodatkeZaGrid(filter)); 
        }
    }
}