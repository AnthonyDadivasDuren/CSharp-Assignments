
/*
 * Insåg i efter hand att jag hade kunnat loopa vid ogiltiga svar då det blev lite jobbigt att börja om varje gång det blev nåt fel
 * 
 */

namespace Övning_Bokhyllan
{
    class Program
    {
        //  Lista Som lagrar alla objekt (med typen Bok eller underklass)
        static List<Bok> bokLista = new List<Bok>();

        static void Main(string[] args)
        {
            // Oändlig loop som visar menyn tills användaren avslutar 
            while (true)
            {
                Console.Clear(); // rensar konsolen 
                Console.WriteLine("\n\tVälkommen till Bokhyllan");
                Console.WriteLine("\n\t  >> [1.] Lägg till en bok");
                Console.WriteLine("\n\t  >> [2.] Visa alla böcker");
                Console.WriteLine("\n\t  >> [3.] Rensa bokhyllan");
                Console.WriteLine("\n\t  >> [4.] Avsluta");
                Console.WriteLine("\n\t     Välj ett alternativ: ");

                // sparar användarens val
                string val = Console.ReadLine();

                // väljer funktion baserat på användarens val
                switch (val)
                {
                    case "1":
                        LäggTillBok();  
                        break;

                    case "2":
                        VisaBöcker();
                        break;

                    case "3":
                        Rensalistan();
                        break;
                    case "4":
                        bokLista.Clear();
                        return; // Avslutar Programmet
                       

                    default:    // felhantering om användaren ger ett ogiltigt svar
                        ErrorMessage("\n\tOgilitgt val försök igen");
                        break;
                }

            }

        }

        // Metod för att lägga till en ny bok i boklistan
        static void LäggTillBok()
        {
            Console.Clear();
            //  Frågar om författare
            Console.WriteLine("\n\tTitel: ");
            string titel = Console.ReadLine();

            // Fel hantering om titeln är tom
            if (string.IsNullOrWhiteSpace(titel))
            {
                ErrorMessage("\n\tDu måste ange en titel, Boken läggs inte till");
                return; //  Avslutar Metoden tidigt
            }

            Console.Clear();
            //Frågar efter författare
            Console.WriteLine("\n\tFörfattare: ");
            string författare = Console.ReadLine();
            
            // Fel hantering om författaren är tom
            if (string.IsNullOrWhiteSpace(författare))
            {
                ErrorMessage("\n\tDu måste ange en författare, Boken läggs inte till");
                return; //  Avslutar Metoden tidigt
            }

            Console.Clear();

            // Frågar efter utgivnings år
            Console.WriteLine("\n\tVilket är utgivningsåret för boken");
            // sparar input som en string
            string input = Console.ReadLine();

            //variabel för år
            int år;

            // försöker konvertera stringen till ett heltal
            bool lyckades = int.TryParse(input, out år);

            // Kontrollerar om konvertereringen misslyckades eller om året är ogiltigt
            // ogiltiga årtal är år som är större än året vi är i nu eller negativa år 
            // finns riktigt gamla böcker så lämnade lägsta till år 0 pga d
            if (!lyckades || år > DateTime.Now.Year || år < 0)
            {
                //felmeddelande och avslutar metoden tidigt
                ErrorMessage("\n\tOgilitgt årtal, Boken läggs inte till");
                return;

            }

            Console.Clear();
            // Frågar om Bok typ
            Console.WriteLine("\n\tTyp av bok:[1] Roman [2] Tidskrift [3] Novellsamling");
            string typVal = Console.ReadLine();

       
            

            Bok nyBok;  // Gör en ny variabel  för nya boken
                
            // skapar objektet utav boktypen användaren väljer
            switch (typVal)
            {
                case "1":
                    nyBok = new Roman (titel, författare, år);
                    break;
                case "2":
                    nyBok = new Tidsskrift(titel, författare, år);
                    break;
                case "3":
                    nyBok = new Novellsamling(titel, författare, år);
                    break;
                default:
                    ErrorMessage("\n\tOgiltigt val, Boken läggs inte till.");
                    return; //  Avslutar Metoden tidigt

            }

            // Lägger till nya boken i boklistan
            bokLista.Add(nyBok);

            Console.Clear ();
            Console.WriteLine("\n\tBoken har lagts till.");

            Console.WriteLine("\n\tTryck Enter för att fortsätta");


        }

        // Metod för att visa alla böcker i listan
        static void VisaBöcker()
        {   
            // Om listan är tom , visa felmeddelande och återvänd till menyn
            if (bokLista.Count == 0)
            {
                ErrorMessage("\n\tInga böcker finns i bokhyllan");
                return;
            } else if (bokLista.Count >= 1) 
            {
                Console.Clear();
                Console.WriteLine("\n\tLista över bokhyllans böcker: ");

                // loopar igenom alla böker och använder VisaInfo metoden som skriver ut Bok info
                foreach (Bok bok in bokLista)
                {
                    bok.VisaInfo();
                    Console.WriteLine("\n"); 
                }
            }

            // Pausar Programmet för låta anvädaren hinna se böckerna innan programmet återvänder till menyn
            Console.WriteLine("\n\tTryck Enter för att gå tillbaka till menyn");
            Console.ReadLine();

        }
        
        // Metod för Felmeddelanden 
        static void ErrorMessage(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Console.WriteLine("\n\tTryck Enter för att fortsätta");
            Console.ReadLine();
            
        }

        // Metod för att rensa boklistan
        static void Rensalistan()
        {
            Console.Clear(); 

            if (bokLista.Count > 0)
            {
                bokLista.Clear(); // rensar boklistan
                Console.WriteLine("\n\tBokhyllan har rensats");
                Console.WriteLine("\n\tTryck enter för att fortsätta");
                Console.ReadLine();
            }else // felhantering om boklistan är tom 
            {
                ErrorMessage("\n\tBokhyllan är redan tom");
            }
            
        }

            

    }
}
