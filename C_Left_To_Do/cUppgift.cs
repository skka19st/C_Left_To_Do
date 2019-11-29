// namespace som används
using System;
using System.Collections.Generic;

namespace C_Left_To_Do
{
    // public = klassen kan användas av andra projekt
    // internal = endast egna projektet (standard)
    // protected = nås även av sub(underliggande) klasser
    public class cUppgift {
        // klassens attribut
        private string text;
        private string status;

        // constructor, initierar klassens datafält
        // constructor visar vilka värden som är obligatoriska
        // constructor lämnar inget returvärde
        // constructor måste ha samma namn som klassen
        // this används när man refererar till klassens egna variabler
        //      till skillnad mot inkommande data
        // status sätts alltid till 'E' (ej klar)
        public cUppgift(string text) {
            this.text = text;
            this.status = "E";
        }          
        // property/egenskap för beskrivning av uppgiften
        // get = läsbehörighet
        public string Text { 
            get { return text; } 
        }            
        // property/egenskap för uppgiftens status
        public string Status { 
            get { return status; } 
            set { status = value; }
        }
        // ändring av status
        // från 'E' (ej klar) till 'K' (klar)
        // från 'K' (klar) till 'E' (ej klar)
        public void StatusChange() {

                if (status == "E") {
                    status = "K";
                    return;
                } 
                if (status == "K") {
                   status = "E";
                   return;
                } 
        }
        // Arkivera uppgiften
        // uppgiften måste ha status 'K' (klar)
        public void StatusArkivera() {
            if (status == "K") {                    
                status = "A";
            }
        }        
        // skapa en redigerad rad för utskrift        
        // denna metod anropas även från subklasserna
        protected string ByggUtskriftRad() {
            string utskrift = text;
            utskrift += ", status: ";
            utskrift += StatusKlartext();
            utskrift += ". ";
            return utskrift;
        }
        // status-koden byts mot ett förklarande ord
        private string StatusKlartext() {
            if (status == "E") {
                return "Ej utförd"; 
            }
            if (status == "K") {
                return "Klar"; 
            }
            if (status == "A") {
                return "Arkiverad"; 
            }
            return "statuskod saknas";
        }
        // skapa en redigerad rad för utskrift
        // anropar en egen metod som delas med subklasserna
        // virtual = metod med samma namn kan finnas i subklasserna
        public virtual string SkapaUtskriftRad() {
            string utskriftsrad;
            utskriftsrad = ByggUtskriftRad();
            return utskriftsrad;
        }
    }
}