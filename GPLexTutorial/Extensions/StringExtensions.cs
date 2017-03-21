using System.Linq;

namespace GPLexTutorial.Extensions
{
    public static class StringExtensions
    {
        public static bool EndsWith(this string obj, string[] endings)
        {
            return endings.Any(x => obj.EndsWith(x));
        }
    }
}
