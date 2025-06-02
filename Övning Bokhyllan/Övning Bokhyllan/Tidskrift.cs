using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Underklass för boktypen Tidskrift
 *  som ärver från basklassen Bok
 */
namespace Övning_Bokhyllan
{
    class Tidsskrift : Bok
    {
        //Konstruktor som tar emot titel och författare och skickar det vidare till basklassen konstruktor
        public Tidsskrift(string titel, string författare, int år) : base(titel, författare, "Tidsskrift", år)
        {
            
            
        }
        
        // överskriver basklassens visa info
        public override void VisaInfo()
        {
            Console.WriteLine($"\n\t\"{Titel}\" av {Författare}, utgiven {År} ( {Typ} )");
        }
    }
}
