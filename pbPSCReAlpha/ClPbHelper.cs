using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbPSCReAlpha
{
    public static class ClPbHelper
    {
        public static String RemoveQuotes(String s)
        {
            String sR = s;
            if (s.StartsWith("\"") && s.EndsWith("\""))
            {
                sR = s.Substring(1, s.Length - 2);
            }
            else if (s.StartsWith("'") && s.EndsWith("'"))
            {
                sR = s.Substring(1, s.Length - 2);
            }
            return sR;
        }
    }
}
