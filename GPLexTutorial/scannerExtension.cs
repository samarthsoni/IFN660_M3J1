using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial
{
    public sealed partial class Scanner : ScanBase
    {
        public string GetStringValue(string input)
        {
            return input.Substring(1, input.Length - 2);
        }
    }
}
