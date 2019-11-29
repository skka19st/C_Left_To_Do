using System;
using System.Collections.Generic;

namespace C_Left_To_Do
{
    class Program
    {
        // lista som lagrar samtliga registrerade uppgifter 
        private List<cUppgift> lista = new List<cUppgift>();
        static void Main(string[] args)
        {
            // loop som avslutas med val '6 - Avsluta'
            bool fortsatt = true;
            while (fortsatt) 
            {
                // ta in menyval från skärmen
                string svar = HanteraMeny();

                // innehållet i variabeln 'svar' testas
                switch(svar)
                {                    
                    case "1":               // lägg till uppgift
                        NyUppgift();
                        break;                    
                    case "2":               // arkivera
                        Arkivera();
                        break;                    
                    case "3":               // lista dagens uppgifter
                        ListaUppgifter();
                        break;                    
                    case "4":               // lista arkiverad uppgifter
                        ListaArkiverade();
                        break;                                      
                    case "0":               // avsluta
                        Avsluta();
                        fortsatt = false;
                        break;                    
                    default:                // hopsamlingsheat för 'icke träff'
                        FelaktigtVal();
                        break;
                }
            }            
        }
        // skriver ut meny och tar in val från skärmen
        private string HanteraMeny()
        {
            Console.WriteLine(" ");
            Console.WriteLine("SKRIV IN FÖRKLARANDE TEXT");
            Console.WriteLine("[1] Lägg till ny uppgift");
            Console.WriteLine("[2] Arkivera utförda uppgifter");
            Console.WriteLine("[3] Lista dagens uppgifter");
            Console.WriteLine("[4] Lista arkiverade uppgifter");
            Console.WriteLine("[0] Avsluta");

            // ta in svar från skärmen
            string menySvar = Console.ReadLine();
            return menySvar;
        }
        private void NyUppgift()
        {   
            // inhämtning av info om ny uppgift
            Console.Write("Lägg upp ny uppgift! ");
            Console.WriteLine("'*' är obligatoriskt");
            Console.Write("Beskrivning(*): ");
            string beskrivning = Console.ReadLine(); 
            Console.Write("Beräknad tidsåtgång (timmar): ");
            string tidx = Console.ReadLine();

            // tidsåtgång ej ifyllt = skapa klass cUppgift
            // tidsåtgång ifyllt = skapa klass cUppgiftTid
            if (tidx == null) {
                cUppgift uppgift = new cUppgift(beskrivning);
                lista.Add(uppgift);
            } else {
                int tid = Convert.ToInt32(tidx);
                cUppgiftTid uppgiftTid = new cUppgiftTid(beskrivning, tid);
                lista.Add(uppgiftTid);
            }            
        }
        private void Arkivera()
        {
            cGodis godisbit = new cGodis();
            godisbit.InitData();
            listaGodis.Add(godisbit);           
        }
        private void ListaUppgifter()
        {
            cPipes pipe = new cPipes();
            pipe.InitData();
            listaPipes.Add(pipe); 
        }

        private void ListaArkiverade()
        {
            Console.WriteLine("Detta är beställt så här långt:");

            // utskrift av beställda bilar
            foreach (cBilar rad in listaBilar)
            {
                rad.VisaData();
            }

            // utskrift av beställt godis
            foreach (cGodis rad in listaGodis)
            {
                rad.VisaData();
            }

            // utskrift av beställda rör
            foreach (cPipes rad in listaPipes)
            {
                rad.VisaData();
            }

            // utskrift av beställd mjölk
            foreach (cMjolk rad in listaMjolk)
            {
                rad.VisaData();
            }
        }
        static void Avsluta()
        {
            Console.WriteLine("hej då, tack för idag!");            
        }
        static void FelaktigtVal()
        {
            Console.WriteLine("Val 1-6 är möjliga");           
        }
    }
}
