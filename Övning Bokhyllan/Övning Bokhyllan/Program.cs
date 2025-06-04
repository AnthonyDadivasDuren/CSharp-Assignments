
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
                string val = Console.ReadLine() ?? "";

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

            // Fråga om titel
            string titel = FrågaAnvändare("\n\tTitel: ");

            // Fel hantering om titeln är tom
            if (ErrorTomtSvar(titel, "titel"))
            {
                return; //  Avslutar Metoden tidigt
            }


            //Frågar efter författare
            string författare = FrågaAnvändare("\n\tFörfattare: ");


            // Fel hantering om författaren är tom
            if (ErrorTomtSvar(författare, "författare"))
            {
                return; //  Avslutar Metoden tidigt
            }


            // Frågar efter utgivnings år
            int år = FrågaEfterÅr("\n\tVilket är utgivningsåret för boken");
            if (år == -1) return;

            // Frågar om Bok typ
            string typVal = FrågaAnvändare("\n\tTyp av bok:[1] Roman [2] Tidskrift [3] Novellsamling");


            Bok nyBok;  // Gör en ny variabel  för nya boken

            // skapar objektet utav boktypen användaren väljer
            switch (typVal)
            {
                case "1":
                    nyBok = new Roman(titel, författare, år);
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

            InfoMessage("\n\tBoken har lagts till.");


        }

        // Metod för att visa alla böcker i listan
        static void VisaBöcker()
        {
            // Om listan är tom , visa felmeddelande och återvänd till menyn
            if (bokLista.Count == 0)
            {
                ErrorMessage("\n\tInga böcker finns i bokhyllan");
                return;
            }

            Console.Clear();
            Console.WriteLine("\n\tLista över bokhyllans böcker: ");

            // loopar igenom alla böker och använder VisaInfo metoden som skriver ut Bok info
            foreach (Bok bok in bokLista)
            {
                bok.VisaInfo();
                Console.WriteLine("\n");
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

        static void InfoMessage(string msg)
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
                string svar = FrågaAnvändare("\n\tÄr du säker på att du vill rensa bokhyllan? (Ja/Nej)");
                if (svar.ToLower() == "ja")
                {
                    bokLista.Clear(); // rensar boklistan
                    InfoMessage("\n\tBokhyllan har rensats");
                }
                else if (svar.ToLower() == "nej")
                {
                    
                    InfoMessage("\n\tRensning avbruten");
                    
                }else
                {
                    ErrorMessage("\n\tOgiltigt svar rensning avbruten");
                }
                
            }
            else // felhantering om boklistan är tom 
            {
                ErrorMessage("\n\tBokhyllan är redan tom");
            }

        }

        static string FrågaAnvändare(string fråga)
        {

            Console.Clear();
            Console.WriteLine($"\n\t{fråga}");


            return Console.ReadLine() ?? "";

        }

        static bool ErrorTomtSvar(string svar, string fältnamn)
        {

            if (string.IsNullOrWhiteSpace(svar))
            {
                ErrorMessage($"\n\tDu måste ange en {fältnamn}, Boken läggs inte till");
                return true;
            }
            return false;
        }

        static int FrågaEfterÅr(string fråga)
        {

            // Frågar efter utgivnings år
            // och sparar input som en string
            string input = FrågaAnvändare(fråga);
            //variabel för år
            int år;

            // försöker konvertera stringen till ett heltal
            bool lyckades = int.TryParse(input, out år);

            // Kontrollerar om konvertereringen misslyckades eller om året är ogiltigt
            // ogiltiga årtal är år som är större än året vi är i nu eller negativa år 
            // finns riktigt gamla böcker så lämnade lägsta till år 0 pga d

            if (!lyckades || år > DateTime.Now.Year || år < 0)
            {
                ErrorMessage("\n\tOgiltigt årtal, Boken läggs inte till");
                return -1; // signalerar ogiltigt år
            }

            return år;
        }
    }
}
