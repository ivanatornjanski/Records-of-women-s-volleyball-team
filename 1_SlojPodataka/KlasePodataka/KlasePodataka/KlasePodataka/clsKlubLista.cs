using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsKlubLista
    {
        // atributi
        private List<clsKlub> pListaKlub; 

        // property
        public List<clsKlub> ListaKlub
        {
            get
            {
                return pListaKlub;
            }
            set
            {
                if (this.pListaKlub != value)
                    this.pListaKlub = value;
            }
        }

        // konstruktor
        public clsKlubLista()
        {
            pListaKlub = new List<clsKlub>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(clsKlub objNoviKlub)
        {
            pListaKlub.Add(objNoviKlub);
        }

        public void ObrisiElementListe(clsKlub objKlubZaBrisanje)
        {
            pListaKlub.Remove(objKlubZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaKlub.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsKlub objStariKlub, clsKlub objNoviKlub)
        {
            int indexStarogKluba = 0;
            indexStarogKluba = pListaKlub.IndexOf(objStariKlub);
            pListaKlub.RemoveAt(indexStarogKluba);
            pListaKlub.Insert(indexStarogKluba, objNoviKlub);   
        }

           

     




    }
}
