using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsEvidencijaLista
    {

        // atributi
        private List<clsEvidencija> pListaEvidencija; 

        // property
        public List<clsEvidencija> ListaEvidencija
        {
            get
            {
                return pListaEvidencija;
            }
            set
            {
                if (this.pListaEvidencija != value)
                    this.pListaEvidencija = value;
            }
        }

        // konstruktor
        public clsEvidencijaLista()
        {
            pListaEvidencija = new List<clsEvidencija>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(clsEvidencija objNovaEvidencija)
        {
            pListaEvidencija.Add(objNovaEvidencija);
        }

        public void ObrisiElementListe(clsEvidencija objEvidencijaZaBrisanje)
        {
            pListaEvidencija.Remove(objEvidencijaZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaEvidencija.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsEvidencija objStaraEvidencija, clsEvidencija objNovaEvidencija)
        {
            int indexStareEvidencije = 0;
            indexStareEvidencije = pListaEvidencija.IndexOf(objNovaEvidencija);
            pListaEvidencija.RemoveAt(indexStareEvidencije);
            pListaEvidencija.Insert(indexStareEvidencije, objNovaEvidencija);   
        }

           
    }
}
