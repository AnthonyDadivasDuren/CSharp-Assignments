using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;



class Bil
{
    public string RegistreringsNummer;  // Här sparas varje bils registreringsnummer
    public string Tillverkare;          // Här sparas varje bils tillverkare
    public int Årtal;                   // Här sparas varje bils tillverkningsår
    public bool Besiktad;               // Här sparas information huruvida bilen är besiktad

    public Bil(string _registrering, string _tillverkare, int _årtal, bool _besiktad) // Här startar bilens konstruktor
    {
        RegistreringsNummer = _registrering;          // Mottaget registreringsnummer tilldelas till objektets registreringsnummer
        Tillverkare = _tillverkare;                   // Mottaget tillverkare tilldelas till objektets tillverkare
        Årtal = _årtal;                               // Mottaget årtal tilldelas till objektets årtal
        Besiktad = _besiktad;                         // Mottagen besiktningsinformation tilldelas till objektets besiktning
    }

    public override string ToString() // Här börjar Bilklassens ToString. Dess standardiserade utskrift
    {
        if (Besiktad)                                                // En utskrift om bilen är besiktad

            return "\n\t\t" + Tillverkare + " (" + Årtal + ")"
            + "\n\t\t" + RegistreringsNummer
            + "\n\t\tBesiktad";

        else
        // En utskrift om bilen är obesiktad
            return "\n\t\t" + Tillverkare + " (" + Årtal + ")"
            + "\n\t\t" + RegistreringsNummer
            + "\n\t\tObesiktad";
    }
}

class Program
{
    static void Main(string[] args)
    {
        /* Bil nyBil = new Bil("ABC123", "Volvo", 1991, false);

         Console.WriteLine(nyBil);

         nyBil.Årtal = 1997;

         Console.WriteLine(nyBil);

         Bil GammalBil = new Bil("NMB777", "Toyota", 1993, true);


         if (nyBil.Årtal > GammalBil.Årtal)
             Console.WriteLine(GammalBil);
         else
             Console.WriteLine(GammalBil);
        */

        bool isRunning = true;
        List<Bil> bilLista = new List<Bil>();

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("\n -------------------------------------"
                + "\n - Välkommen till Transportstyrelsen -"
                + "\n -------------------------------------"
                + "\n >> [1] Registrera ny bil"
                + "\n >> [2] Visa Billistan"
                + "\n >> [3] Massregistrera bilar"
                + "\n >> [4] Avsluta ");


            if (Int32.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        string registreringsNummer = "";
                        string tillverkare = "";
                        int årtal = 0;
                        bool besiktad = false;

                        while (registreringsNummer.Length != 6)
                        {
                            Console.Clear();
                            Console.WriteLine("\n - Ange bilens registreringsnummer. 6 symboler -");
                            registreringsNummer = Console.ReadLine().ToUpper();
                            if (registreringsNummer.Length != 6)
                                ErrorMessage("- Felaktigt registreringsNummer, Vänligen ange 6 symboler utan mellanrum -");

                        }

                        while (string.IsNullOrEmpty(tillverkare))
                        {
                            Console.Clear();
                            Console.WriteLine("\n - Ange bilens tillverkare -");
                            tillverkare = Console.ReadLine().ToUpper();
                            if (string.IsNullOrEmpty(tillverkare))
                                ErrorMessage(" - Bilens Tillverkare kan inte vara tom, Vänligen ange igen -");

                        }

                        while (årtal < 1900 || årtal > DateTime.Now.Year)
                        {
                            Console.Clear();
                            Console.WriteLine("\n - Ange bilens tillverknings år");
                            if (Int32.TryParse(Console.ReadLine(), out årtal))
                            {
                                if (årtal < 1900 || årtal > DateTime.Now.Year)
                                    ErrorMessage("Tillverknings år måste vara mellan 1900 och " + DateTime.Now.Year);

                            }
                        }

                        string input = "";
                        while (input == "")
                        {
                            Console.Clear();
                            Console.WriteLine("\n - Är bilen besiktad "
                                + "\n -  Ange Ja eller Nej -");

                            input = Console.ReadLine();
                            if (input.Length > 0)
                            {
                                if (input.ToLower() == "ja")
                                {
                                    besiktad = true;

                                }
                                else if (input.ToLower() == "nej")
                                {
                                    besiktad = false;
                                }
                                else
                                {
                                    input = "";
                                    ErrorMessage("Svara endast med, Ja eller Nej");

                                }


                            }
                            else
                            {
                                ErrorMessage("Du angav inget svar ");

                            }
                        }

                        Bil nyBil = new Bil(registreringsNummer, tillverkare, årtal, besiktad);

                        bilLista.Add(nyBil);


                        break;


                    case 2:

                        if (bilLista.Count > 0)
                        {
                            Console.Clear();

                            foreach (Bil bil in bilLista)
                            {
                                Console.WriteLine(bil);
                            }
                            if (bilLista.Count == 1)
                            {
                                Console.WriteLine("\n - " + bilLista.Count + " bil är registrerad. -");
                                Console.WriteLine("Tryck enter för att forsätta");
                                Console.ReadLine();
                            } else if (bilLista.Count > 1)
                            {
                                Console.WriteLine("\n - " + bilLista.Count + " bilar är registrerade. -");
                                Console.WriteLine("Tryck enter för att forsätta");
                                Console.ReadLine();
                            }

                        }
                        else
                        {
                            ErrorMessage("Det finns inga registrerade bilar");
                        }
                        break;


                    case 3:


                        Random newRandom = new Random();

                        string alfabete = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";

                        string[] randomBokstav = alfabete.Select(c => c.ToString()).ToArray();

                        string[] tillverkaretyper = new string[] { "Nissan", "Toyota", "Volvo", "BMW", "Ford", "Mitsubishi", "Kia", "Hyundai", "Opel", "Subaru", "Peugeot" };

                        Console.WriteLine("\n - Hur många bilar vill du registrera -");

                        if (Int32.TryParse(Console.ReadLine(), out int antaBilar) && antaBilar > 0)
                        {
                            for (int i = 0; i < antaBilar; i++)
                            {
                                string randomRegNr = GenereraRandomRegNr(newRandom, alfabete);
                                string randomTillverkare = GenereraRandomTillverkare(newRandom, tillverkaretyper);

                                int randomÅrtal = newRandom.Next(1900, (DateTime.Now.Year + 1));

                                bool randomBesiktning = false;
                                if (newRandom.Next(0, 3) != 0) // 33% chans för obesiktad
                                {
                                    randomBesiktning = true;
                                }
                                bilLista.Add(new Bil(randomRegNr, randomTillverkare, randomÅrtal, randomBesiktning));
                            }
                                Console.WriteLine("\n - " + antaBilar + " bilar registrerade -");
                                Console.ReadLine();
                            
                        }
                        else
                        {
                            ErrorMessage("Felaktigt antal");
                        }
                        

                break;

                    case 4:
                    isRunning = false;
                    break;

                }
            }
            else
            {
                ErrorMessage("Felaktigt val");
            }
        }

        static void ErrorMessage(string message)
        {
            Console.WriteLine("\n - " + message + " -");

            Console.WriteLine("\n - Tryck Enter för att fortsätta");
            Console.ReadLine();
        }

        static string GenereraRandomRegNr(Random random, string bokstäver)
        {

            string randomRegNr = "";


            for (int i = 0; i < 3; i++)
            {
                randomRegNr += bokstäver[random.Next(0, bokstäver.Length)];
            }
            for (int j = 0; j < 3; j++)
            {
                randomRegNr += random.Next(0, 10);
            }

            return randomRegNr;
        }

        static string GenereraRandomTillverkare(Random random, string[] tillverkareLista)
        {
            return tillverkareLista[random.Next(tillverkareLista.Length)];
        }

       
    }
}

