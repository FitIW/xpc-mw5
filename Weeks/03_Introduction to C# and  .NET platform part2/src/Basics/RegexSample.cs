using System.Text.RegularExpressions;

namespace Basics
{
    public class RegexSample : ISample
    {
        public void Run()
        {
            var regex = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.        
            var text = "The the quick brown fox  fox jumps over the lazy dog dog.";

            // Find matches.
            var matches = regex.Matches(text);
        }
    }
}