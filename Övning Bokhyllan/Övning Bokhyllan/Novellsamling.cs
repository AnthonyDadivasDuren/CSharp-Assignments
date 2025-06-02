using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Underklass för boktypen Novellsamling
 *  som ärver från basklassen Bok
 */
namespace Övning_Bokhyllan
{
    class Novellsamling : Bok
    {
        //Konstruktor som tar emot titel och författare och skickar det vidare till basklassen konstruktor
        public Novellsamling(string titel, string författare, int år) : base(titel, författare,"Novellsamling", år)
        {
           
        }
    }
}
