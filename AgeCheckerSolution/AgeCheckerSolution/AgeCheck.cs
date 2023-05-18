using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AgeCheckerSolution
{
    public static class AgeCheck
    {
        public static string Agee()
        { 
        int age = 0;
            if (age > 18)
            {
                string agee = "ADULT";
            }
            else
            {
                string agee = "NON-ADULT";
            }
            return agee;
        }
        
    }
}
