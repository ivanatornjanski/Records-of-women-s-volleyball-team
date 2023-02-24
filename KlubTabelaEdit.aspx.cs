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
    public partial class KlubTabelaEdit : System.Web.UI.Page
    {
        
        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakKlubEdit.DataSource = ds.Tables[0];
            gvSpisakKlubEdit.DataBind();
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsFormaKlubTabelaEdit objFormaKlubTabelaEdit = new clsFormaKlubTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                NapuniGrid(objFormaKlubTabelaEdit.DajPodatkeZaGrid(""));
            }
        }

        protected void gvSpisakKlubEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("KlubDetaljiEdit.aspx?Sifra=" + gvSpisakKlubEdit.Rows[gvSpisakKlubEdit.SelectedIndex].Cells[1].Text); 
        }

       
    }
}