namespace AllAboutGames.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Censor
    {
        public static readonly IList<string> CensoredWords = new List<string>
        {
            "fuck", "shit", "bullshit", "sisterfucker", "fatherfucker", "effing", "Jesus fuck", "motherfucker", "bitch",
            "cunt", "holy shit", "nigga", "slut", "son of a bitch", "twat", "fucking", "niga",
        };

        public string CensorText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            string censoredText = text;

            foreach (string censoredWord in CensoredWords)
            {
                string regularExpression = this.ToRegexPattern(censoredWord);

                censoredText = Regex.Replace(
                    censoredText,
                    regularExpression,
                    StarCensoredMatch,
                  RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            }

            return censoredText;
        }

        private static string StarCensoredMatch(Match m)
        {
            string word = m.Captures[0].Value;

            return new string('*', word.Length);
        }

        private string ToRegexPattern(string wildcardSearch)
        {
            string regexPattern = Regex.Escape(wildcardSearch);

            regexPattern = regexPattern.Replace(@"\*", ".*?");
            regexPattern = regexPattern.Replace(@"\?", ".");

            if (regexPattern.StartsWith(".*?"))
            {
                regexPattern = regexPattern.Substring(3);
                regexPattern = @"(^\b)*?" + regexPattern;
            }

            regexPattern = @"\b" + regexPattern + @"\b";

            return regexPattern;
        }
    }
}
