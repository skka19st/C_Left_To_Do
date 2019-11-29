using System;
using System.Collections.Generic;

namespace C_Left_To_Do
{
    class Program
    {
        // lista som lagrar samtliga registrerade uppgifter 
        // static = klassmetod/instansmetod, utan skapat objekt
        static private List<cUppgift> lista = new List<cUppgift>();
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
        // static = klassmetod/instansmetod, utan skapat objekt
        static private string HanteraMeny()
        {
            Console.WriteLine(" ");
            Console.WriteLine("SKRIV IN FÖRKLARANDE TEXT");
            Console.WriteLine("[1] Lägg till ny uppgift");
            Console.WriteLine("[2] Arkivera utförda uppgifter");
            Console.WriteLine("[3] Lista dagens uppgifter");
            Console.WriteLine("[4] Lista arkiverade uppgifter");
            Console.WriteLine("[0] Avsluta");
            Console.WriteLine(" ");

            // ta in svar från skärmen
            string menySvar = Console.ReadLine();
            return menySvar;
        }
        // upplägg av ny uppgift
        // static = klassmetod/instansmetod, utan skapat objekt
        static private void NyUppgift()
        {   
            // inhämtning av info om ny uppgift
            Console.WriteLine("Lägg upp ny uppgift! ");
            Console.Write("Beskrivning (obligatorisk): ");
            string beskrivning = Console.ReadLine(); 
            Console.Write("Beräknad tidsåtgång (timmar): ");
            string tidx = Console.ReadLine();

            // tidsåtgång ej ifyllt = skapa klass cUppgift
            // tidsåtgång ifyllt = skapa klass cUppgiftTid
            if (tidx == "") {
                cUppgift uppgift = new cUppgift(beskrivning);
                lista.Add(uppgift);
            } else {
                int tid = Convert.ToInt32(tidx);
                cUppgiftTid uppgiftTid = new cUppgiftTid(beskrivning, tid);
                lista.Add(uppgiftTid);
            }  
            // kvittens till användaren
            Console.WriteLine("uppgiften upplagd.");          
        }
        // arkiverar uppgifter - alla med status 'K' (klar)
        // static = klassmetod/instansmetod, utan skapat objekt
        static private void Arkivera()
        {
            // urval med hjälp av loop genom listan
            foreach (cUppgift rad in lista)
            {
                if (rad.Status == "K") {
                    rad.StatusArkivera();
                    //listaArkiverade.Add(rad);
                    //lista.Remove(rad);
                    //lista.
                }
            }
            // kvittens till användare
            Console.WriteLine("Arkivering av uppgifter utförd");
            Console.WriteLine("");
        }
        // utskrift av samtliga uppgifter, utom de arkiverade
        // möjlighet att ändra status
        // static = klassmetod/instansmetod, utan skapat objekt
        static private void ListaUppgifter()
        {
            // loop som avslutas med val '0' - Tillbaka till menyn
            bool changeStatus = true;            
            while (changeStatus)
            {
                Console.WriteLine("Dagens uppgifter:");
                Console.WriteLine("");

                // urval till utskriften med hjälp av loop genom listan
                // ett radnr (skapat mha list-index) läggs till vid utskrift
                for (int ind = 0 ; ind < lista.Count ; ind++)
                //foreach (cUppgift rad in lista)
                {
                    if (lista[ind].Status != "A") {
                        string utskrift = "radnr ";
                        utskrift += (ind + 1);
                        utskrift += ": ";
                        utskrift += lista[ind].SkapaUtskriftRad();
                        Console.WriteLine(utskrift);
                    }
                }

                // möjlighet att ändra status på uppgifterna
                // loop tills '0' (tillbaka till menyn) anges
                string val = BehandlaStatus();
                if (val == "0") {
                    changeStatus = false;
                }
            }

        }
        // möjlighet att ändra status på uppgifter (ej arkiverade)
        static private string BehandlaStatus() {
            Console.WriteLine(" ");
            Console.WriteLine("För att ändra status, ange radnr");
            Console.WriteLine("[0] för att komma tillbaka till menyn");
            Console.WriteLine(" ");

            // ta in svar från skärmen
            string valx = Console.ReadLine();

            // tillbaka till menyn
            if (valx == "0") {
                return valx;
            }

            // index till listan = angivet radnr - 1
            // angivet radnr måste vara inom rätt intervall
            int val = Convert.ToInt32(valx);
            val--;
            if (val > lista.Count) {
                Console.WriteLine("felaktigt radnr!");
                return valx;
            }

            // ändra status för angiven rad
            //rad.StatusChange();
            lista[val].StatusChange();
            //lista[val].Status = lista[val].StatusChange();
            return valx;
        }

        // utskrift av arkiverade uppgifter
        // static = klassmetod/instansmetod, utan skapat objekt
        static private void ListaArkiverade()
        {
            Console.WriteLine("Arkiverade uppgifter:");
            Console.WriteLine("");

            // urval till utskriften med hjälp av loop genom listan
            foreach (cUppgift rad in lista)
            {
                if (rad.Status == "A") {
                    string utskrift = rad.SkapaUtskriftRad();
                    Console.WriteLine(utskrift);
                }
            }
        }
        // static = klassmetod/instansmetod, utan skapat objekt
        static void Avsluta()
        {
            Console.WriteLine("hej då, tack för idag!");            
        }
        static void FelaktigtVal()
        {
            Console.WriteLine("Val 0-4 är möjliga");           
        }
    }
}
