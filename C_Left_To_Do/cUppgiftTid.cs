// namespace som används
using System;
using System.Collections.Generic;

namespace C_Left_To_Do
{
    // public = klassen kan användas av andra projekt
    // internal = endast egna projektet (standard)
    // protected = nås även av sub(underliggande) klasser 
    // cUppgiftTid är en subklass till cUppgift
    // :cUppgift = CUppgiftTid ärver cUppgift
    public class cUppgiftTid : cUppgift {
        // klassens attribut
        private int tid;

        // constructor, initierar klassens datafält
        // constructor visar vilka värden som är obligatoriska
        // constructor lämnar inget returvärde
        // constructor måste ha samma namn som klassen

        // :base() refererar till basklassens constructor
        // variabeln text som kommer till denna constructor, skickas
        // vidare till basklassens constructor
        // this. används när man refererar till klassens egna variabler
        // till skillnad mot inkommande data
        public cUppgiftTid(string text, int tid) : base (text) {
            this.tid = tid;
        }

        // property/egenskap för beräknad tidsåtgång
        public int Tid { 
            get { return tid; } 
            set { tid = value; }
        }
        
        // skapa en redigerad rad för utskrift
        // anropar en metod i basklassen 
        // sedan läggs attribut från denna klass till
        // override = finns i basklassen, men denna gäller
        public override string SkapaUtskriftRad() {
            string utskriftsrad;
            utskriftsrad = ByggUtskriftRad();
            utskriftsrad += "Beräknad tid (timmar): ";
            utskriftsrad += tid;
            return utskriftsrad;
        }
    }
}