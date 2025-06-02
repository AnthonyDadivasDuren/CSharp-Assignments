using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *  Basklassen Bok
 *  som representerar en bok med titel,författare, typ
 * 
 */
namespace Övning_Bokhyllan
{
    class Bok
    {
        // Egenskap för boktitel
        public string Titel { get; set; }

        // Egenskap för författarens namn
        public string Författare { get; set; }

        // Egenskap för boktypen
        public string Typ { get; set; }

        //  Egenskap för utgivningsår
        public int År { get; set; }

        //Konstruktor som initialiserar titel, författare och typ
        // typ har standard värdet Allmänn om inget anges
        public Bok(string titel, string författare, string typ = "Allmänn" , int år = 0)
        {
            Titel = titel;
            Författare = författare;
            Typ = typ;
            År = år;
        }

        // metod för att visa bok info
        public virtual void VisaInfo()
        {
            // skriver ut titel, författare och typ
            Console.WriteLine($"\n\t\"{Titel}\" av {Författare}, ( {Typ}, utgiven år {År} )"); 
        }
    }
}
