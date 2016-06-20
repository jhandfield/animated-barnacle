using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ROMSharp
{
    public class Password
    {
        public static bool MeetsComplexityRequirements(string pass)
        {
            pass = pass.Trim();

            return pass.Length > 6 && Regex.IsMatch(pass, "[a-z]") && Regex.IsMatch(pass, "[A-Z]") && Regex.IsMatch(pass, "[^a-zA-Z]");
        }
    }
}
