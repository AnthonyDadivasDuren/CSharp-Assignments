using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *  Underklass för boktypen Roman
 *  som ärver från basklassen Bok
 */
namespace Övning_Bokhyllan
{
    class Roman : Bok
    {
        //Konstruktor som tar emot titel och författare och skickar det vidare till basklassen konstruktor
        public Roman(string titel, string författare, int år) : base(titel, författare, "Roman", år) 
        {
           
            
        }
    }
}
