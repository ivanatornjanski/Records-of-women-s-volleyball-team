using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using PrezentacionaLogika;
using KlasePodataka;

namespace KorisnickiInterfejs
{
    public partial class EvidencijaUnos : System.Web.UI.Page
    {
        // atributi
        clsFormaEvidencijaUnos objFormaEvidencijaUnos; 
        
        // konstruktor


        // nase metode
        private void NapuniCombo()
        {
            // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
            DataSet dsKlub = new DataSet();
            dsKlub = objFormaEvidencijaUnos.DajPodatkeZaCombo();

            int ukupno = dsKlub.Tables[0].Rows.Count;

            // PUNJENJE COMBO PODACIMA IZ DATASETA
            ddlKlubovi.Items.Add("Izaberite...");
            for (int i = 0; i < ukupno; i++)
            {
                ddlKlubovi.Items.Add(dsKlub.Tables[0].Rows[i].ItemArray[1].ToString());
            }

        }

        private void IsprazniKontrole()
        {
            txbIDIgraca.Text = "";
            txbIgracIme.Text = "";
            txbIgracPrezime.Text = "";
            txbGodinaRodjenja.Text = "";
            txbBrojNaDresu.Text = "";
            ddlKlubovi.Text ="Izaberite...";
            lblStatus.Text = ""; 
        }

        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaEvidencijaUnos = new clsFormaEvidencijaUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            if (!IsPostBack)
            {
                NapuniCombo();
            }
        }

        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            // ***********preuzimanje vrednosti sa korisnickog interfejsa
            // 2. nacin - preuzimaju atributi klase prezentacione logike
            objFormaEvidencijaUnos.IDIgraca = int.Parse(txbIDIgraca.Text);
            objFormaEvidencijaUnos.IgracIme = txbIgracIme.Text;
            objFormaEvidencijaUnos.IgracPrezime = txbIgracPrezime.Text;
            objFormaEvidencijaUnos.GodinaRodjenja = int.Parse(txbGodinaRodjenja.Text);
            objFormaEvidencijaUnos.BrojNaDresu = int.Parse(txbBrojNaDresu.Text);
            objFormaEvidencijaUnos.NazivKluba = ddlKlubovi.Text;  
            
            // *********** provera ispravnosti vrednosti
            // 1. provera popunjenosti
            bool SvePopunjeno = objFormaEvidencijaUnos.DaLiJeSvePopunjeno();

            // 2. provera ispravnosti - karakteri, vrednost iz domena, jedinstvenost zapisa
            bool JedinstvenZapis = objFormaEvidencijaUnos.DaLiJeJedinstvenZapis();

            // ********** snimanje u bazu podataka
            string porukaStatusaSnimanja = "";
            if (SvePopunjeno)
            {
                if (JedinstvenZapis)
                {
                    
                        // snimanje podataka
                        objFormaEvidencijaUnos.SnimiPodatke();
                        // priprema teksta poruke o uspehu snimanja
                        porukaStatusaSnimanja = "USPESNO SNIMLJENI PODACI!";

                }
                else
                {
                    porukaStatusaSnimanja = "VEC POSTOJI EVIDENCIJA SA ISTIM IDIgraca!";
                }
            }
            else
            { 
                // priprema teksta poruke o gresci
                porukaStatusaSnimanja = "NISU SVI PODACI POPUNJENI!";
              
            }


            // ********** obavestavanje korisnika o statusu snimanja
            lblStatus.Text = porukaStatusaSnimanja; 


        }

        protected void btnPonisti_Click(object sender, EventArgs e)
        {
            IsprazniKontrole();
        }

        protected void ddlKlubovi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txbBrojNaDresu_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txbIDIgraca_TextChanged(object sender, EventArgs e)
        {

        }
    }
}