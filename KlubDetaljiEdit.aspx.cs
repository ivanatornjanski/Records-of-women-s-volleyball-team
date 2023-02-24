using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PrezentacionaLogika;
//


namespace KorisnickiInterfejs
{
    public partial class KlubDetaljiEdit : System.Web.UI.Page
    {
        // atributi
        private string pSifra = "";
        clsFormaKlubDetaljiEdit objFormaKlubDetaljiEdit; 

        // nase metode
        private void IsprazniKontrole()
        {
            txbSifra.Text = "";
            txbNaziv.Text = ""; 

        }

        private void AktivirajKontrole()
        {
            txbSifra.Enabled = true;
            txbNaziv.Enabled = true;
        }

        private void DeaktivirajKontrole()
        {
            txbSifra.Enabled = false ;
            txbNaziv.Enabled = false;
        }

        private void PrikaziPodatke(clsFormaKlubDetaljiEdit objFormaKlubDetaljiEdit)
        {
            // podacima stranice upravlja klasa prezentacione logike, zato se uzimaju iz nje za prikaz
            txbSifra.Text = objFormaKlubDetaljiEdit.SifraPreuzetiKlub;
            txbNaziv.Text = objFormaKlubDetaljiEdit.NazivPreuzetiKlub; 

        }

        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaKlubDetaljiEdit = new clsFormaKlubDetaljiEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            pSifra = Request.QueryString["Sifra"].ToString();
            objFormaKlubDetaljiEdit.SifraPreuzetiKlub = pSifra;
            // OVDE SE NE DOBIJA NAZIV SPOLJA, VEC SE IZRACUNAVA NAZIV na set svojstvu property za sifru UNUTAR KLASE  
            if (!IsPostBack)
            {
                PrikaziPodatke(objFormaKlubDetaljiEdit);
            }  
        }

        protected void btnObrisi_Click(object sender, EventArgs e)
        {
            objFormaKlubDetaljiEdit.SifraPreuzetiKlub = txbSifra.Text;
            bool uspehBrisanja = objFormaKlubDetaljiEdit.ObrisiKlub();
            if (uspehBrisanja)
            {
                lblStatus.Text = "Uspesno obrisan zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
            }
        }

        protected void btnIzmeni_Click(object sender, EventArgs e)
        {
       
            AktivirajKontrole();
            txbSifra.Focus();
 
        }

        protected void btnSnimiIzmenu_Click(object sender, EventArgs e)
        {
            objFormaKlubDetaljiEdit.SifraIzmenjeniKlub = txbSifra.Text;
            objFormaKlubDetaljiEdit.NazivIzmenjeniKlub= txbNaziv.Text;
            bool uspehIzmene =objFormaKlubDetaljiEdit.IzmeniKlub();
            if (uspehIzmene)
            {
                lblStatus.Text = "Uspesno izmenjen zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
            }
            DeaktivirajKontrole();
        }
    }
}
